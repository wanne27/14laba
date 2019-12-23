using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
namespace _14laba
{
    class Program
    {
        static void BinarySerialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Sport.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован, Binary");
            }
        }
        static void BinaryDeserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Sport.dat", FileMode.OpenOrCreate))
            {
                Mate newmate = (Mate)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                newmate.ToString();
                Console.WriteLine("Объект десериализован binary");
            }
        }
        static void JsonSerialize(object obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Mate));
            using (FileStream fs = new FileStream("Mate.json", FileMode.OpenOrCreate))
            {
                json.WriteObject(fs, obj);
                Console.WriteLine("Объект сериализован,Json");
            }
        }
        static void JsonDeserialize()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Mate));
            using(FileStream fs = new FileStream("Mate.json", FileMode.OpenOrCreate))
            {
                Mate newmate = (Mate)json.ReadObject(fs);
                newmate.ToString();
            }
        }

        static void SOAPSerialize(object obj)
        {
            // создаем объект SoapFormatter
            SoapFormatter formmater = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Mate.soap", FileMode.OpenOrCreate))
            {
                formmater.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован, SOAP");

            }
        }
        static void SOAPDeserialize()
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream("Mate.soap", FileMode.OpenOrCreate))
            {
                Mate newmate = (Mate)formatter.Deserialize(fs);
                Console.WriteLine("Десериализован SOAP");
                newmate.ToString();
            }

        }
        static void XMLSerialize(object obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Mate));
            using (FileStream fs = new FileStream("Mate.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("объект сериализован, XML");
            }
        }

        static void XMLDeserialize()
        {
            XmlSerializer deserialize = new XmlSerializer(typeof(Mate));
            using (FileStream fs = new FileStream("Mate.xml", FileMode.OpenOrCreate))
            {
                Mate newmate = (Mate)deserialize.Deserialize(fs);
                newmate.ToString();
                Console.WriteLine("XML десериализован");
            }
        }

        static void Array_JsonSerialize(object obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Mate[]));
            using (FileStream fs = new FileStream("Mate_array.json", FileMode.OpenOrCreate))
            {
                json.WriteObject(fs, obj);
                Console.WriteLine("Сериализация массива JSON завершена");
            }
        }
        static void Array_JsonDeserialize()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Mate[]));
            using (FileStream fs = new FileStream("Mate_array.json", FileMode.OpenOrCreate))
            {
                Mate[] newmate = (Mate[])json.ReadObject(fs);

                foreach(Mate item in newmate)
                {
                    item.ToString();
                }
                Console.WriteLine("Массив  объектов десериализован, Json");
            }
        }
        static void Array_XMLSerialize(object obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Mate[]));
            using (FileStream fs = new FileStream("Mate_array.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("объект сериализован, XML");
            }
        }

        static void Array_XMLDeserialize()
        {
            XmlSerializer deserialize = new XmlSerializer(typeof(Mate[]));
            using (FileStream fs = new FileStream("Mate_array.xml", FileMode.OpenOrCreate))
            {

                Mate[] newmate = (Mate[])deserialize.Deserialize(fs);
                foreach (Mate item in newmate)
                {
                    item.ToString();
                }
              
                   
                Console.WriteLine("Массив  объектов десериализован, XML");
            }
        }
        static void XPath()

        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:\\OOP\\14laba\\14laba\\bin\\Debug\\netcoreapp2.1\\XPath.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode childnode = xRoot.SelectSingleNode("MATE[name= 'k4']");
            if (childnode!=null)
                Console.WriteLine(childnode.OuterXml);
            else Console.WriteLine("Error");    
            XmlNode childnode1 = xRoot.SelectSingleNode("MATE[mass= 4]");
            if (childnode != null)
                Console.WriteLine(childnode1.OuterXml);
            else Console.WriteLine("Error");
        }
        static void XmlLinq()
        {
            XDocument xDoc = new XDocument(new XElement("OOP", new XElement("LABS", new XElement("Khamichenok"), new XElement("My_github_wanne"), new XElement("Its_all"))));
            if(xDoc!=null)
            xDoc.Save("oop.xml");
            else Console.WriteLine("Error ");
        }
        static void Main(string[] args)
        {
            Mate mate = new Mate("k1", 2, 4, 6, 35);
            Mate mate2 = new Mate("k2", 3, 5, 7, 36);
            Mate mate3 = new Mate("k3", 4, 6, 8, 37);
            Mate mate4 = new Mate("k4", 4, 7, 9, 38);
            Mate[] mates = new Mate[] { mate, mate2, mate3, mate4 };
            BinarySerialize(mate);
            BinaryDeserialize();
            JsonSerialize(mate2);
            JsonDeserialize();
            XMLSerialize(mate4);
            XMLDeserialize();
            Array_JsonSerialize(mates);
            Array_JsonDeserialize();
            Array_XMLSerialize(mates);
            Array_XMLDeserialize();
            XPath();
            XmlLinq(); 
            Console.ReadLine();

        }
    }
}
