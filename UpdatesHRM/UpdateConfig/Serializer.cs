using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace UpdatesHRM
{
    public class Serializer
    {
        internal class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }
        public static string SerializeToString(object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            TextWriter textWriter = new Utf8StringWriter();

            xmlSerializer.Serialize(textWriter, obj);
            return textWriter.ToString();
        }

        public static object DeserializeFromString(string xmlSource, Type type)
        {
            StringReader xmlSourceReader = new StringReader(xmlSource);
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            return xmlSerializer.Deserialize(xmlSourceReader);
        }

        public static void SerializeToXmlFile(object obj, string path)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (TextWriter writer = new StreamWriter(path))
                serializer.Serialize(writer, obj);
        }

        public static T DeserializeFromXmlFile<T>(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (XmlReader reader = XmlReader.Create(path))
                return (T)ser.Deserialize(reader);
        }
    }
}
