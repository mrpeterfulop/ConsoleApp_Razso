using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _11._23.Karsa_16_Bin_Files__In_Memory_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FileStream fs1 = new FileStream("data.bin", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs1);

            var textToBin = "Tesztszöveg írása";

            bw.Write(textToBin);

            fs1.Flush();
            bw.Close();
            fs1.Close();
            

            FileStream fs2 = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs2);

            Console.WriteLine(br.ReadString());

            fs2.Flush();
            br.Close();
            fs2.Close();


            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);

            sw.WriteLine(125493);
            sw.Flush();

            FileStream fs = File.Create("memory.txt");
            ms.WriteTo(fs);

            sw.Close();
            ms.Close();
            fs.Flush();
            fs.Close();
            Console.WriteLine("'memory.txt' feltöltve a memóriában tárolt adatokkal!");



            // XML fájlok olvasása
            Console.Clear();
            XmlReader xml_read = XmlReader.Create("shopping.xml");

            while (xml_read.Read())
            {
                switch (xml_read.NodeType)
                {
                    case XmlNodeType.Element :
                        Console.WriteLine($"<{xml_read.Name}>");
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(xml_read.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.WriteLine($"<{xml_read.Name}>");
                        break;
                    default:
                        break;
                }

                if (xml_read["quantity"] !=null)
                {
                    Console.WriteLine(xml_read["quantity"]);
                }
            }

            xml_read.Close();


            // XML fájlok írása
            Console.Clear();

            XmlTextWriter  xml_writer = new XmlTextWriter("pelda.xml", Encoding.UTF8);
            xml_writer.Formatting = Formatting.Indented;

            xml_writer.WriteStartDocument();

            xml_writer.WriteComment("Első komment");
            xml_writer.WriteStartElement("Autó");
            xml_writer.WriteAttributeString("év", "4");
            xml_writer.WriteElementString("kocsim", "opel");

            xml_writer.WriteEndElement();

            xml_writer.Close();

            Console.ReadKey();
        }
    }
}
