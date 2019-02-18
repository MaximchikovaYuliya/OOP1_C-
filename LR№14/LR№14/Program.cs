using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using LR_5_6_7;

namespace LR_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Captain john = new Captain("John", 28);
            Captain jack = new Captain("Jack", 30);
            Captain travis = new Captain("Travis", 40);
            Captain sam = new Captain("Sam", 23);
            Captain george = new Captain("George", 28);

            Captain[] captains = { john, jack, travis, sam, george };

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream file = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(file, john);
                binaryFormatter.Serialize(file, captains);
            }
            using (FileStream file = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                Captain newJonh = (Captain)binaryFormatter.Deserialize(file);
                Captain[] newCaptains = (Captain[])binaryFormatter.Deserialize(file);
            }

            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream file = new FileStream("sfile.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(file, john);
                soapFormatter.Serialize(file, captains);
            }
            using (FileStream file = new FileStream("sfile.soap", FileMode.OpenOrCreate))
            {
                Captain newJonhSOAP = (Captain)soapFormatter.Deserialize(file);
                Captain[] newCaptainsSOAP = (Captain[])soapFormatter.Deserialize(file);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Captain));
            using (FileStream file = new FileStream("xfile.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, john);
            }
            using (FileStream file = new FileStream("xfile.xml", FileMode.OpenOrCreate))
            {
                Captain newJonhXML = (Captain)xmlSerializer.Deserialize(file);
            }

            DataContractSerializer dataContract = new DataContractSerializer(typeof(Captain));
            using (FileStream file = new FileStream("jfile.json", FileMode.OpenOrCreate))
            {
                dataContract.WriteObject(file, john);
            }
            using (FileStream file = new FileStream("jfile.json", FileMode.OpenOrCreate))
            {
                Captain newJonhJSON = (Captain)dataContract.ReadObject(file);
            }

            XML.CreateXML();
            XML.LinqToXML();
            XML.XPath();

            Console.ReadKey();
        }
    }
}
