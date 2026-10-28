using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace TestApp
{
    public class SimpleZipEntry
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }

    public static class SimpleZip
    {
        public static Dictionary<string, byte[]> ExtractAll(string zipPath)
        {
            Dictionary<string, byte[]> entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
            using (FileStream fs = new FileStream(zipPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BinaryReader br = new BinaryReader(fs))
            {
                // Find End of Central Directory Record (0x06054b50)
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
                    fs.Seek(6, SeekOrigin.Current); // skip version, flags
                    ushort method = br.ReadUInt16();
                    fs.Seek(8, SeekOrigin.Current); // skip time, date, crc
                    uint compSize = br.ReadUInt32();
                    uint uncompSize = br.ReadUInt32();
                    ushort nameLen = br.ReadUInt16();
                    ushort extraLen = br.ReadUInt16();
                    ushort commentLen = br.ReadUInt16();
                    fs.Seek(8, SeekOrigin.Current); // skip disk, attrs
                    uint localHeaderOffset = br.ReadUInt32();

                    byte[] nameBytes = br.ReadBytes(nameLen);
                    string name = Encoding.UTF8.GetString(nameBytes).Replace('\\', '/');
                    fs.Seek(extraLen + commentLen, SeekOrigin.Current);

                    long savedPos = fs.Position;
                    // Read local header
                    fs.Seek(localHeaderOffset, SeekOrigin.Begin);
                    if (br.ReadUInt32() == 0x04034b50)
                    {
                        fs.Seek(22, SeekOrigin.Current);
                        ushort locNameLen = br.ReadUInt16();
                        ushort locExtraLen = br.ReadUInt16();
                        fs.Seek(locNameLen + locExtraLen, SeekOrigin.Current);

                        byte[] data = null;
                        if (method == 0) // Stored
                        {
                            data = br.ReadBytes((int)compSize);
                        }
                        else if (method == 8) // Deflated
                        {
                            byte[] compData = br.ReadBytes((int)compSize);
                            using (MemoryStream msIn = new MemoryStream(compData))
                            using (DeflateStream def = new DeflateStream(msIn, CompressionMode.Decompress))
                            using (MemoryStream msOut = new MemoryStream((int)uncompSize))
                            {
                                byte[] buf = new byte[4096];
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
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "scratch/test_fine.xlsx";
            Dictionary<string, byte[]> files = SimpleZip.ExtractAll(path);
            Console.WriteLine("Extracted files: " + files.Count);
            foreach (string k in files.Keys)
            {
                Console.WriteLine(" - " + k + " (" + files[k].Length + " bytes)");
            }

            // Parse shared strings
            List<string> sharedStrings = new List<string>();
            if (files.ContainsKey("xl/sharedStrings.xml"))
            {
                using (MemoryStream ms = new MemoryStream(files["xl/sharedStrings.xml"]))
                using (XmlReader xr = XmlReader.Create(ms))
                {
                    while (xr.Read())
                    {
                        if (xr.NodeType == XmlNodeType.Element && xr.LocalName == "t")
                        {
                            sharedStrings.Add(xr.ReadElementContentAsString());
                        }
                    }
                }
            }

            Console.WriteLine("Shared strings count: " + sharedStrings.Count);

            // Parse sheet1.xml
            if (files.ContainsKey("xl/worksheets/sheet1.xml"))
            {
                using (MemoryStream ms = new MemoryStream(files["xl/worksheets/sheet1.xml"]))
                using (XmlReader xr = XmlReader.Create(ms))
                {
                    while (xr.Read())
                    {
                        if (xr.NodeType == XmlNodeType.Element && xr.LocalName == "row")
                        {
                            Console.WriteLine("Row " + xr.GetAttribute("r") + ":");
                        }
                        else if (xr.NodeType == XmlNodeType.Element && xr.LocalName == "c")
                        {
                            string cellRef = xr.GetAttribute("r");
                            string cellType = xr.GetAttribute("t");
                            xr.Read();
                            if (xr.LocalName == "v")
                            {
                                string val = xr.ReadElementContentAsString();
                                int sIdx;
                                if (cellType == "s" && int.TryParse(val, out sIdx) && sIdx >= 0 && sIdx < sharedStrings.Count)
                                {
                                    val = sharedStrings[sIdx];
                                }
                                Console.WriteLine("  " + cellRef + " = " + val);
                            }
                        }
                    }
                }
            }
        }
    }
}
