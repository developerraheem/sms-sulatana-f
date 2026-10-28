using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace TestApp
{
    public class SimpleZipWriter
    {
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

        public static void CreateZipFile(string zipPath, Dictionary<string, byte[]> files)
        {
            using (FileStream fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                List<ZipEntryInfo> entries = new List<ZipEntryInfo>();

                // Write local headers and data
                foreach (KeyValuePair<string, byte[]> kv in files)
                {
                    ZipEntryInfo entry = new ZipEntryInfo();
                    entry.Name = kv.Key.Replace('\\', '/');
                    entry.UncompressedSize = (uint)kv.Value.Length;
                    entry.Crc32 = ComputeCrc32(kv.Value);
                    entry.LocalHeaderOffset = (uint)fs.Position;

                    // Compress using DeflateStream
                    using (MemoryStream msComp = new MemoryStream())
                    {
                        using (DeflateStream def = new DeflateStream(msComp, CompressionMode.Compress, true))
                        {
                            def.Write(kv.Value, 0, kv.Value.Length);
                        }
                        entry.CompressedData = msComp.ToArray();
                    }
                    entry.CompressedSize = (uint)entry.CompressedData.Length;
                    entry.CompressionMethod = 8; // Deflated

                    byte[] nameBytes = Encoding.UTF8.GetBytes(entry.Name);

                    // Local file header (0x04034b50)
                    bw.Write((uint)0x04034b50);
                    bw.Write((ushort)20); // version needed
                    bw.Write((ushort)0);  // general purpose bit flag
                    bw.Write(entry.CompressionMethod);
                    bw.Write((ushort)0);  // last mod file time
                    bw.Write((ushort)0);  // last mod file date
                    bw.Write(entry.Crc32);
                    bw.Write(entry.CompressedSize);
                    bw.Write(entry.UncompressedSize);
                    bw.Write((ushort)nameBytes.Length);
                    bw.Write((ushort)0);  // extra field length
                    bw.Write(nameBytes);
                    bw.Write(entry.CompressedData);

                    entries.Add(entry);
                }

                uint centralDirOffset = (uint)fs.Position;

                // Central directory headers
                foreach (ZipEntryInfo entry in entries)
                {
                    byte[] nameBytes = Encoding.UTF8.GetBytes(entry.Name);
                    bw.Write((uint)0x02014b50); // central file header signature
                    bw.Write((ushort)20); // version made by
                    bw.Write((ushort)20); // version needed to extract
                    bw.Write((ushort)0);  // general purpose bit flag
                    bw.Write(entry.CompressionMethod);
                    bw.Write((ushort)0);  // last mod file time
                    bw.Write((ushort)0);  // last mod file date
                    bw.Write(entry.Crc32);
                    bw.Write(entry.CompressedSize);
                    bw.Write(entry.UncompressedSize);
                    bw.Write((ushort)nameBytes.Length);
                    bw.Write((ushort)0);  // extra field length
                    bw.Write((ushort)0);  // file comment length
                    bw.Write((ushort)0);  // disk number start
                    bw.Write((ushort)0);  // internal file attributes
                    bw.Write((uint)0);    // external file attributes
                    bw.Write(entry.LocalHeaderOffset);
                    bw.Write(nameBytes);
                }

                uint centralDirSize = (uint)(fs.Position - centralDirOffset);

                // End of central directory record (0x06054b50)
                bw.Write((uint)0x06054b50);
                bw.Write((ushort)0); // number of this disk
                bw.Write((ushort)0); // disk where central dir starts
                bw.Write((ushort)entries.Count); // number of central directory records on this disk
                bw.Write((ushort)entries.Count); // total number of central directory records
                bw.Write(centralDirSize);
                bw.Write(centralDirOffset);
                bw.Write((ushort)0); // comment length
            }
        }
    }

    class TestWriter
    {
        static void Main()
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
    <sheet name=""Fine Template"" sheetId=""1"" r:id=""rId1"" xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships""/>
  </sheets>
</workbook>");

            // Sheet using inlineStr for headers & text, numbers for fine!
            files["xl/worksheets/sheet1.xml"] = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<worksheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">
  <sheetData>
    <row r=""1"">
      <c r=""A1"" t=""inlineStr""><is><t>Student ID</t></is></c>
      <c r=""B1"" t=""inlineStr""><is><t>Student Name</t></is></c>
      <c r=""C1"" t=""inlineStr""><is><t>Class Name</t></is></c>
      <c r=""D1"" t=""inlineStr""><is><t>Fine</t></is></c>
      <c r=""E1"" t=""inlineStr""><is><t>Reason</t></is></c>
    </row>
    <row r=""2"">
      <c r=""A2"" t=""inlineStr""><is><t>2093</t></is></c>
      <c r=""B2"" t=""inlineStr""><is><t>SYEDA KINZA BIBI</t></is></c>
      <c r=""C2"" t=""inlineStr""><is><t>PM-1G</t></is></c>
      <c r=""D2""><v>200</v></c>
      <c r=""E2"" t=""inlineStr""><is><t>Late Fee</t></is></c>
    </row>
  </sheetData>
</worksheet>");

            SimpleZipWriter.CreateZipFile("scratch/generated_template.xlsx", files);
            Console.WriteLine("Successfully created scratch/generated_template.xlsx!");
        }
    }
}
