using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace School
{
    public static class ExcelHelper
    {
        #region ZIP Extraction & Creation

        private static readonly uint[] CrcTable = MakeCrcTable();

        private static uint[] MakeCrcTable()
        {
            uint[] table = new uint[256];
            for (uint i = 0; i < 256; i++)
            {
                uint c = i;
                for (int j = 0; j < 8; j++)
                {
                    if ((c & 1) != 0)
                        c = 0xEDB88320 ^ (c >> 1);
                    else
                        c = c >> 1;
                }
                table[i] = c;
            }
            return table;
        }

        public static uint ComputeCrc32(byte[] data)
        {
            uint crc = 0xFFFFFFFF;
            for (int i = 0; i < data.Length; i++)
            {
                crc = CrcTable[(crc ^ data[i]) & 0xFF] ^ (crc >> 8);
            }
            return crc ^ 0xFFFFFFFF;
        }

        public static Dictionary<string, byte[]> ExtractZip(string zipPath)
        {
            Dictionary<string, byte[]> entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
            using (FileStream fs = new FileStream(zipPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BinaryReader br = new BinaryReader(fs))
            {
                long length = fs.Length;
                if (length < 22) return entries;
                long searchLimit = Math.Max(0, length - 65557);
                long eocdPos = -1;

                for (long p = length - 22; p >= searchLimit; p--)
                {
                    fs.Seek(p, SeekOrigin.Begin);
                    if (br.ReadUInt32() == 0x06054b50)
                    {
                        eocdPos = p;
                        break;
                    }
                }
                if (eocdPos == -1) return entries;

                fs.Seek(eocdPos + 10, SeekOrigin.Begin);
                ushort entryCount = br.ReadUInt16();
                uint cdSize = br.ReadUInt32();
                uint cdOffset = br.ReadUInt32();

                fs.Seek(cdOffset, SeekOrigin.Begin);
                for (int i = 0; i < entryCount; i++)
                {
                    if (br.ReadUInt32() != 0x02014b50) break;
                    fs.Seek(6, SeekOrigin.Current);
                    ushort method = br.ReadUInt16();
                    fs.Seek(8, SeekOrigin.Current);
                    uint compSize = br.ReadUInt32();
                    uint uncompSize = br.ReadUInt32();
                    ushort nameLen = br.ReadUInt16();
                    ushort extraLen = br.ReadUInt16();
                    ushort commentLen = br.ReadUInt16();
                    fs.Seek(8, SeekOrigin.Current);
                    uint localHeaderOffset = br.ReadUInt32();

                    byte[] nameBytes = br.ReadBytes(nameLen);
                    string name = Encoding.UTF8.GetString(nameBytes).Replace('\\', '/');
                    fs.Seek(extraLen + commentLen, SeekOrigin.Current);

                    long savedPos = fs.Position;
                    fs.Seek(localHeaderOffset, SeekOrigin.Begin);
                    if (br.ReadUInt32() == 0x04034b50)
                    {
                        fs.Seek(22, SeekOrigin.Current);
                        ushort locNameLen = br.ReadUInt16();
                        ushort locExtraLen = br.ReadUInt16();
                        fs.Seek(locNameLen + locExtraLen, SeekOrigin.Current);

                        byte[] data = null;
                        if (method == 0)
                        {
                            data = br.ReadBytes((int)compSize);
                        }
                        else if (method == 8)
                        {
                            byte[] compData = br.ReadBytes((int)compSize);
                            using (MemoryStream msIn = new MemoryStream(compData))
                            using (DeflateStream def = new DeflateStream(msIn, CompressionMode.Decompress))
                            using (MemoryStream msOut = new MemoryStream((int)uncompSize))
                            {
                                byte[] buf = new byte[8192];
                                int read;
                                while ((read = def.Read(buf, 0, buf.Length)) > 0)
                                {
                                    msOut.Write(buf, 0, read);
                                }
                                data = msOut.ToArray();
                            }
                        }
                        if (data != null)
                        {
                            entries[name] = data;
                        }
                    }
                    fs.Seek(savedPos, SeekOrigin.Begin);
                }
            }
            return entries;
        }

        private class ZipEntryInfo
        {
            public string Name;
            public byte[] CompressedData;
            public uint Crc32;
            public uint UncompressedSize;
            public uint CompressedSize;
            public ushort CompressionMethod;
            public uint LocalHeaderOffset;
        }

        public static void CreateZip(string zipPath, Dictionary<string, byte[]> files)
        {
            using (FileStream fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                List<ZipEntryInfo> entries = new List<ZipEntryInfo>();

                foreach (KeyValuePair<string, byte[]> kv in files)
                {
                    ZipEntryInfo entry = new ZipEntryInfo();
                    entry.Name = kv.Key.Replace('\\', '/');
                    entry.UncompressedSize = (uint)kv.Value.Length;
                    entry.Crc32 = ComputeCrc32(kv.Value);
                    entry.LocalHeaderOffset = (uint)fs.Position;

                    using (MemoryStream msComp = new MemoryStream())
                    {
                        using (DeflateStream def = new DeflateStream(msComp, CompressionMode.Compress, true))
                        {
                            def.Write(kv.Value, 0, kv.Value.Length);
                        }
                        entry.CompressedData = msComp.ToArray();
                    }
                    entry.CompressedSize = (uint)entry.CompressedData.Length;
                    entry.CompressionMethod = 8;

                    byte[] nameBytes = Encoding.UTF8.GetBytes(entry.Name);

                    bw.Write((uint)0x04034b50);
                    bw.Write((ushort)20);
                    bw.Write((ushort)0);
                    bw.Write(entry.CompressionMethod);
                    bw.Write((ushort)0);
                    bw.Write((ushort)0);
                    bw.Write(entry.Crc32);
                    bw.Write(entry.CompressedSize);
                    bw.Write(entry.UncompressedSize);
                    bw.Write((ushort)nameBytes.Length);
                    bw.Write((ushort)0);
                    bw.Write(nameBytes);
                    bw.Write(entry.CompressedData);

                    entries.Add(entry);
                }

                uint centralDirOffset = (uint)fs.Position;

                foreach (ZipEntryInfo entry in entries)
                {
                    byte[] nameBytes = Encoding.UTF8.GetBytes(entry.Name);
                    bw.Write((uint)0x02014b50);
                    bw.Write((ushort)20);
                    bw.Write((ushort)20);
                    bw.Write((ushort)0);
                    bw.Write(entry.CompressionMethod);
                    bw.Write((ushort)0);
                    bw.Write((ushort)0);
                    bw.Write(entry.Crc32);
                    bw.Write(entry.CompressedSize);
                    bw.Write(entry.UncompressedSize);
                    bw.Write((ushort)nameBytes.Length);
                    bw.Write((ushort)0);
                    bw.Write((ushort)0);
                    bw.Write((ushort)0);
                    bw.Write((ushort)0);
                    bw.Write((uint)0);
                    bw.Write(entry.LocalHeaderOffset);
                    bw.Write(nameBytes);
                }

                uint centralDirSize = (uint)(fs.Position - centralDirOffset);

                bw.Write((uint)0x06054b50);
                bw.Write((ushort)0);
                bw.Write((ushort)0);
                bw.Write((ushort)entries.Count);
                bw.Write((ushort)entries.Count);
                bw.Write(centralDirSize);
                bw.Write(centralDirOffset);
                bw.Write((ushort)0);
            }
        }

        #endregion

        #region Excel (.xlsx) Reading

        private static int ColumnNameToIndex(string colName)
        {
            int index = 0;
            for (int i = 0; i < colName.Length; i++)
            {
                char c = char.ToUpperInvariant(colName[i]);
                if (c >= 'A' && c <= 'Z')
                {
                    index = index * 26 + (c - 'A' + 1);
                }
            }
            return index - 1;
        }

        private static void ParseCellRef(string cellRef, out int colIdx, out int rowIdx)
        {
            colIdx = 0;
            rowIdx = 0;
            if (string.IsNullOrEmpty(cellRef)) return;
            int split = 0;
            while (split < cellRef.Length && char.IsLetter(cellRef[split])) split++;
            string colPart = cellRef.Substring(0, split);
            string rowPart = cellRef.Substring(split);
            colIdx = ColumnNameToIndex(colPart);
            int.TryParse(rowPart, out rowIdx);
        }

        public static DataTable ReadXlsx(string filePath)
        {
            Dictionary<string, byte[]> zip = ExtractZip(filePath);
            if (zip.Count == 0)
            {
                throw new Exception("Unable to open Excel file. Please ensure it is a valid .xlsx file and not corrupted.");
            }

            // Read shared strings robustly with XmlDocument (handles plain text, rich-text runs, preserved spaces)
            List<string> sharedStrings = new List<string>();
            string ssKey = null;
            foreach (string k in zip.Keys)
            {
                if (k.Equals("xl/sharedStrings.xml", StringComparison.OrdinalIgnoreCase))
                {
                    ssKey = k;
                    break;
                }
            }

            if (ssKey != null && zip.ContainsKey(ssKey))
            {
                try
                {
                    XmlDocument ssDoc = new XmlDocument();
                    using (MemoryStream ms = new MemoryStream(zip[ssKey]))
                    {
                        ssDoc.Load(ms);
                    }

                    XmlNodeList siNodes = ssDoc.SelectNodes("//*[local-name()='si']");
                    if (siNodes != null)
                    {
                        foreach (XmlNode si in siNodes)
                        {
                            StringBuilder sb = new StringBuilder();
                            XmlNodeList tNodes = si.SelectNodes(".//*[local-name()='t']");
                            if (tNodes != null)
                            {
                                foreach (XmlNode t in tNodes)
                                {
                                    sb.Append(t.InnerText);
                                }
                            }
                            sharedStrings.Add(sb.ToString());
                        }
                    }
                }
                catch { }
            }

            // Find sheet1 XML
            byte[] sheetBytes = null;
            foreach (string key in zip.Keys)
            {
                if (key.Equals("xl/worksheets/sheet1.xml", StringComparison.OrdinalIgnoreCase))
                {
                    sheetBytes = zip[key];
                    break;
                }
            }

            if (sheetBytes == null)
            {
                foreach (string key in zip.Keys)
                {
                    if (key.StartsWith("xl/worksheets/sheet", StringComparison.OrdinalIgnoreCase) && key.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        sheetBytes = zip[key];
                        break;
                    }
                }
            }

            if (sheetBytes == null)
            {
                throw new Exception("No worksheet found inside the Excel file.");
            }

            // Parse sheet rows using XmlDocument
            Dictionary<int, SortedDictionary<int, string>> rawRows = new Dictionary<int, SortedDictionary<int, string>>();

            XmlDocument sheetDoc = new XmlDocument();
            using (MemoryStream ms = new MemoryStream(sheetBytes))
            {
                sheetDoc.Load(ms);
            }

            XmlNodeList rowNodes = sheetDoc.SelectNodes("//*[local-name()='row']");
            if (rowNodes != null)
            {
                int autoRowIdx = 0;
                foreach (XmlNode rowNode in rowNodes)
                {
                    autoRowIdx++;
                    int rIdx = autoRowIdx;
                    XmlAttribute rAttr = rowNode.Attributes["r"];
                    if (rAttr != null)
                    {
                        int parsedR;
                        if (int.TryParse(rAttr.Value, out parsedR))
                        {
                            rIdx = parsedR;
                        }
                    }

                    if (!rawRows.ContainsKey(rIdx))
                    {
                        rawRows[rIdx] = new SortedDictionary<int, string>();
                    }

                    int autoColIdx = 0;
                    XmlNodeList cNodes = rowNode.SelectNodes(".//*[local-name()='c']");
                    if (cNodes != null)
                    {
                        foreach (XmlNode cNode in cNodes)
                        {
                            string cRef = cNode.Attributes["r"] != null ? cNode.Attributes["r"].Value : "";
                            string cType = cNode.Attributes["t"] != null ? cNode.Attributes["t"].Value : "";

                            int colIdx = autoColIdx;
                            if (!string.IsNullOrEmpty(cRef))
                            {
                                int dummyR;
                                ParseCellRef(cRef, out colIdx, out dummyR);
                            }

                            string cellValue = "";
                            if (cType == "s")
                            {
                                XmlNode vNode = cNode.SelectSingleNode(".//*[local-name()='v']");
                                if (vNode != null)
                                {
                                    int sIdx;
                                    if (int.TryParse(vNode.InnerText.Trim(), out sIdx) && sIdx >= 0 && sIdx < sharedStrings.Count)
                                    {
                                        cellValue = sharedStrings[sIdx];
                                    }
                                    else
                                    {
                                        cellValue = vNode.InnerText.Trim();
                                    }
                                }
                            }
                            else if (cType == "inlineStr")
                            {
                                XmlNode tNode = cNode.SelectSingleNode(".//*[local-name()='t']");
                                if (tNode != null)
                                {
                                    cellValue = tNode.InnerText;
                                }
                            }
                            else if (cType == "b")
                            {
                                XmlNode vNode = cNode.SelectSingleNode(".//*[local-name()='v']");
                                if (vNode != null)
                                {
                                    cellValue = (vNode.InnerText.Trim() == "1") ? "TRUE" : "FALSE";
                                }
                            }
                            else
                            {
                                XmlNode vNode = cNode.SelectSingleNode(".//*[local-name()='v']");
                                if (vNode != null)
                                {
                                    cellValue = vNode.InnerText.Trim();
                                }
                                else
                                {
                                    XmlNode tNode = cNode.SelectSingleNode(".//*[local-name()='t']");
                                    if (tNode != null)
                                    {
                                        cellValue = tNode.InnerText;
                                    }
                                }
                            }

                            rawRows[rIdx][colIdx] = cellValue != null ? cellValue.Trim() : "";
                            autoColIdx = colIdx + 1;
                        }
                    }
                }
            }

            DataTable dt = new DataTable("ExcelData");
            if (rawRows.Count == 0) return dt;

            // Sort row keys
            List<int> sortedRowKeys = new List<int>(rawRows.Keys);
            sortedRowKeys.Sort();

            // Find header row: skip leading completely empty rows or title rows with only 1 value if next row has multiple columns
            int headerRowKey = sortedRowKeys[0];
            foreach (int rKey in sortedRowKeys)
            {
                SortedDictionary<int, string> rowData = rawRows[rKey];
                int nonEmptyCount = 0;
                foreach (string val in rowData.Values)
                {
                    if (!string.IsNullOrEmpty(val)) nonEmptyCount++;
                }

                if (nonEmptyCount >= 2)
                {
                    headerRowKey = rKey;
                    break;
                }
                else if (nonEmptyCount == 1 && headerRowKey == sortedRowKeys[0])
                {
                    headerRowKey = rKey;
                }
            }

            SortedDictionary<int, string> headerCells = rawRows[headerRowKey];

            int maxCol = 0;
            foreach (KeyValuePair<int, SortedDictionary<int, string>> rowPair in rawRows)
            {
                foreach (int colIdx in rowPair.Value.Keys)
                {
                    if (colIdx > maxCol) maxCol = colIdx;
                }
            }

            // Create columns based on header row
            for (int c = 0; c <= maxCol; c++)
            {
                string colName = "";
                if (headerCells.ContainsKey(c) && !string.IsNullOrEmpty(headerCells[c]))
                {
                    colName = headerCells[c].Trim();
                }
                else
                {
                    colName = "Column" + (c + 1);
                }

                // Ensure unique column names in DataTable
                string uniqueColName = colName;
                int suffix = 1;
                while (dt.Columns.Contains(uniqueColName))
                {
                    uniqueColName = colName + "_" + suffix;
                    suffix++;
                }
                dt.Columns.Add(uniqueColName, typeof(string));
            }

            // Add data rows (starting from row after headerRowKey)
            foreach (int rKey in sortedRowKeys)
            {
                if (rKey <= headerRowKey) continue;

                SortedDictionary<int, string> rowCells = rawRows[rKey];
                DataRow dr = dt.NewRow();
                bool hasAnyData = false;

                for (int c = 0; c <= maxCol; c++)
                {
                    if (rowCells.ContainsKey(c))
                    {
                        string v = rowCells[c];
                        dr[c] = v;
                        if (!string.IsNullOrEmpty(v)) hasAnyData = true;
                    }
                    else
                    {
                        dr[c] = "";
                    }
                }

                if (hasAnyData)
                {
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        #endregion

        #region CSV Reading

        public static DataTable ReadCsv(string filePath)
        {
            DataTable dt = new DataTable("CsvData");
            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                string line = sr.ReadLine();
                if (line == null) return dt;

                char separator = line.Contains("\t") ? '\t' : ',';
                List<string> headers = ParseCsvLine(line, separator);

                for (int i = 0; i < headers.Count; i++)
                {
                    string colName = headers[i].Trim();
                    if (string.IsNullOrEmpty(colName)) colName = "Column" + (i + 1);

                    string uniqueName = colName;
                    int suffix = 1;
                    while (dt.Columns.Contains(uniqueName))
                    {
                        uniqueName = colName + "_" + suffix;
                        suffix++;
                    }
                    dt.Columns.Add(uniqueName, typeof(string));
                }

                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line.Trim())) continue;
                    List<string> fields = ParseCsvLine(line, separator);
                    DataRow dr = dt.NewRow();
                    bool hasData = false;

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i < fields.Count)
                        {
                            dr[i] = fields[i].Trim();
                            if (!string.IsNullOrEmpty(fields[i].Trim())) hasData = true;
                        }
                        else
                        {
                            dr[i] = "";
                        }
                    }
                    if (hasData) dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private static List<string> ParseCsvLine(string line, char sep)
        {
            List<string> result = new List<string>();
            StringBuilder current = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == sep && !inQuotes)
                {
                    result.Add(current.ToString());
                    current.Length = 0;
                }
                else
                {
                    current.Append(c);
                }
            }
            result.Add(current.ToString());
            return result;
        }

        #endregion

        #region Universal Reader

        public static DataTable ReadFile(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLowerInvariant();
            if (ext == ".csv" || ext == ".txt")
            {
                return ReadCsv(filePath);
            }
            else if (ext == ".xlsx")
            {
                return ReadXlsx(filePath);
            }
            else if (ext == ".xls")
            {
                // Try reading as text/CSV/HTML/XML spreadsheet first
                try
                {
                    string firstBytes;
                    using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
                    {
                        char[] buf = new char[512];
                        int r = sr.Read(buf, 0, 512);
                        firstBytes = new string(buf, 0, r);
                    }
                    if (firstBytes.Contains("<?xml") || firstBytes.Contains("<html") || firstBytes.Contains("\t") || firstBytes.Contains(","))
                    {
                        return ReadCsv(filePath);
                    }
                }
                catch { }

                // Fallback: try OleDb if available
                try
                {
                    string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";
                    using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connStr))
                    {
                        conn.Open();
                        DataTable schema = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                        if (schema != null && schema.Rows.Count > 0)
                        {
                            string sheetName = schema.Rows[0]["TABLE_NAME"].ToString();
                            using (System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", conn))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
                catch
                {
                    throw new Exception("Unable to parse .xls format. Please save or export your file as .xlsx or .csv format and import again.");
                }
            }

            throw new NotSupportedException("Unsupported file format: " + ext + ". Please select an .xlsx or .csv file.");
        }

        #endregion

        #region Template & Export Generation

        public static void WriteDataTableToXlsx(DataTable dt, string filePath)
        {
            Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();

            files["[Content_Types].xml"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Types xmlns=""http://schemas.openxmlformats.org/package/2006/content-types"">
  <Default Extension=""rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml""/>
  <Default Extension=""xml"" ContentType=""application/xml""/>
  <Override PartName=""/xl/workbook.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml""/>
  <Override PartName=""/xl/worksheets/sheet1.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml""/>
</Types>");

            files["_rels/.rels"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"" Target=""xl/workbook.xml""/>
</Relationships>");

            files["xl/_rels/workbook.xml.rels"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"" Target=""worksheets/sheet1.xml""/>
</Relationships>");

            files["xl/workbook.xml"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<workbook xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">
  <sheets>
    <sheet name=""Sheet1"" sheetId=""1"" r:id=""rId1"" xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships""/>
  </sheets>
</workbook>");

            StringBuilder sheetXml = new StringBuilder();
            sheetXml.Append(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<worksheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">
  <sheetData>");

            sheetXml.Append(@"<row r=""1"">");
            for (int c = 0; c < dt.Columns.Count; c++)
            {
                string colLetter = GetColumnLetter(c + 1);
                string val = dt.Columns[c].ColumnName.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                sheetXml.AppendFormat(@"<c r=""{0}1"" t=""inlineStr""><is><t>{1}</t></is></c>", colLetter, val);
            }
            sheetXml.Append("</row>");

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                int rowIdx = r + 2;
                sheetXml.AppendFormat(@"<row r=""{0}"">", rowIdx);
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    string colLetter = GetColumnLetter(c + 1);
                    object cellVal = dt.Rows[r][c];
                    if (cellVal != null && cellVal != DBNull.Value)
                    {
                        double num;
                        if (double.TryParse(cellVal.ToString(), out num))
                        {
                            sheetXml.AppendFormat(@"<c r=""{0}{1}""><v>{2}</v></c>", colLetter, rowIdx, num);
                        }
                        else
                        {
                            string s = cellVal.ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                            sheetXml.AppendFormat(@"<c r=""{0}{1}"" t=""inlineStr""><is><t>{2}</t></is></c>", colLetter, rowIdx, s);
                        }
                    }
                }
                sheetXml.Append("</row>");
            }

            sheetXml.Append(@"</sheetData></worksheet>");
            files["xl/worksheets/sheet1.xml"] = Encoding.UTF8.GetBytes(sheetXml.ToString());

            CreateZip(filePath, files);
        }

        private static string GetColumnLetter(int colIndex)
        {
            string div = "";
            while (colIndex > 0)
            {
                int rem = (colIndex - 1) % 26;
                div = (char)(65 + rem) + div;
                colIndex = (colIndex - rem) / 26;
            }
            return div;
        }

        public static void GenerateTemplateXlsx(string filePath)
        {
            Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();

            files["[Content_Types].xml"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Types xmlns=""http://schemas.openxmlformats.org/package/2006/content-types"">
  <Default Extension=""rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml""/>
  <Default Extension=""xml"" ContentType=""application/xml""/>
  <Override PartName=""/xl/workbook.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml""/>
  <Override PartName=""/xl/worksheets/sheet1.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml""/>
</Types>");

            files["_rels/.rels"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"" Target=""xl/workbook.xml""/>
</Relationships>");

            files["xl/_rels/workbook.xml.rels"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"" Target=""worksheets/sheet1.xml""/>
</Relationships>");

            files["xl/workbook.xml"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<workbook xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">
  <sheets>
    <sheet name=""Fee Import Template"" sheetId=""1"" r:id=""rId1"" xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships""/>
  </sheets>
</workbook>");

            files["xl/worksheets/sheet1.xml"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<worksheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">
  <sheetData>
    <row r=""1"">
      <c r=""A1"" t=""inlineStr""><is><t>Student ID</t></is></c>
      <c r=""B1"" t=""inlineStr""><is><t>Student Name</t></is></c>
      <c r=""C1"" t=""inlineStr""><is><t>Class</t></is></c>
      <c r=""D1"" t=""inlineStr""><is><t>Fee Month</t></is></c>
      <c r=""E1"" t=""inlineStr""><is><t>Fee Head</t></is></c>
      <c r=""F1"" t=""inlineStr""><is><t>Amount</t></is></c>
      <c r=""G1"" t=""inlineStr""><is><t>Reason</t></is></c>
    </row>
    <row r=""2"">
      <c r=""A2"" t=""inlineStr""><is><t>2093</t></is></c>
      <c r=""B2"" t=""inlineStr""><is><t>SYEDA KINZA BIBI</t></is></c>
      <c r=""C2"" t=""inlineStr""><is><t>PM-1G</t></is></c>
      <c r=""D2"" t=""inlineStr""><is><t>10 2026</t></is></c>
      <c r=""E2"" t=""inlineStr""><is><t>Monthly Fee</t></is></c>
      <c r=""F2""><v>2500</v></c>
      <c r=""G2"" t=""inlineStr""><is><t>Regular fee</t></is></c>
    </row>
    <row r=""3"">
      <c r=""A3"" t=""inlineStr""><is><t>2093</t></is></c>
      <c r=""B3"" t=""inlineStr""><is><t>SYEDA KINZA BIBI</t></is></c>
      <c r=""C3"" t=""inlineStr""><is><t>PM-1G</t></is></c>
      <c r=""D3"" t=""inlineStr""><is><t>10 2026</t></is></c>
      <c r=""E3"" t=""inlineStr""><is><t>Attendance Fine</t></is></c>
      <c r=""F3""><v>200</v></c>
      <c r=""G3"" t=""inlineStr""><is><t>3 days absent</t></is></c>
    </row>
    <row r=""4"">
      <c r=""A4"" t=""inlineStr""><is><t>2093</t></is></c>
      <c r=""B4"" t=""inlineStr""><is><t>SYEDA KINZA BIBI</t></is></c>
      <c r=""C4"" t=""inlineStr""><is><t>PM-1G</t></is></c>
      <c r=""D4"" t=""inlineStr""><is><t>10 2026</t></is></c>
      <c r=""E4"" t=""inlineStr""><is><t>Fee Concession</t></is></c>
      <c r=""F4""><v>500</v></c>
      <c r=""G4"" t=""inlineStr""><is><t>Sibling discount</t></is></c>
    </row>
    <row r=""5"">
      <c r=""A5"" t=""inlineStr""><is><t>2106</t></is></c>
      <c r=""B5"" t=""inlineStr""><is><t>UROOSA QAYUM</t></is></c>
      <c r=""C5"" t=""inlineStr""><is><t>PM-1G</t></is></c>
      <c r=""D5"" t=""inlineStr""><is><t>10 2026</t></is></c>
      <c r=""E5"" t=""inlineStr""><is><t>Fine</t></is></c>
      <c r=""F5""><v>150</v></c>
      <c r=""G5"" t=""inlineStr""><is><t>Late fee</t></is></c>
    </row>
  </sheetData>
</worksheet>");

            CreateZip(filePath, files);
        }

        public static void GenerateTemplateCsv(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine("Student ID,Student Name,Class,Fee Month,Fee Head,Amount,Reason");
                sw.WriteLine("2093,SYEDA KINZA BIBI,PM-1G,10 2026,Monthly Fee,2500,Regular fee");
                sw.WriteLine("2093,SYEDA KINZA BIBI,PM-1G,10 2026,Attendance Fine,200,3 days absent");
                sw.WriteLine("2093,SYEDA KINZA BIBI,PM-1G,10 2026,Fee Concession,500,Sibling discount");
                sw.WriteLine("2106,UROOSA QAYUM,PM-1G,10 2026,Fine,150,Late fee");
            }
        }

        public static void ExportErrorReportCsv(string filePath, DataTable dtErrors)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dtErrors.Columns.Count; i++)
                {
                    if (i > 0) sb.Append(",");
                    sb.Append("\"" + dtErrors.Columns[i].ColumnName.Replace("\"", "\"\"") + "\"");
                }
                sw.WriteLine(sb.ToString());

                foreach (DataRow row in dtErrors.Rows)
                {
                    sb.Length = 0;
                    for (int i = 0; i < dtErrors.Columns.Count; i++)
                    {
                        if (i > 0) sb.Append(",");
                        string v = row[i] != null ? row[i].ToString() : "";
                        sb.Append("\"" + v.Replace("\"", "\"\"") + "\"");
                    }
                    sw.WriteLine(sb.ToString());
                }
            }
        }

        #endregion
    }
}
