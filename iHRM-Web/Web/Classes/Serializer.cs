using System;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections;
using System.ComponentModel;

namespace iHRM.WebPC.Classes
{
	internal class Utf8StringWriter : StringWriter
	{ 
		public override Encoding Encoding 
		{ 
			get { return Encoding.UTF8; } 
		} 
	}
    
    public class iSerializer
    {
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

    public static class iSerializeStatic
    {
        public static void Serialize(Type staticClass, string fileName)
        {
            XmlTextWriter xmlWriter = null;

            try
            {
                xmlWriter = new XmlTextWriter(fileName, null);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                Serialize(staticClass, xmlWriter);
                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
        }

        static void Serialize(string name, object obj, XmlTextWriter xmlWriter)
        {
            Type type = obj.GetType();
            XmlAttributeOverrides xmlAttributeOverrides = new XmlAttributeOverrides();
            XmlAttributes xmlAttributes = new XmlAttributes();
            xmlAttributes.XmlRoot = new XmlRootAttribute(name);
            xmlAttributeOverrides.Add(type, xmlAttributes);
            XmlSerializer xmlSerializer = new XmlSerializer(type, xmlAttributeOverrides);

            xmlSerializer.Serialize(xmlWriter, obj);
        }

        static bool Serialize(Type staticClass, XmlTextWriter xmlWriter)
        {
            FieldInfo[] fieldArray = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);

            xmlWriter.WriteStartElement(staticClass.Name);

            foreach (FieldInfo fieldInfo in fieldArray)
            {
                if (fieldInfo.IsNotSerialized)
                    continue;

                string fieldName = fieldInfo.Name;
                string fieldValue = null;
                Type fieldType = fieldInfo.FieldType;
                object fieldObject = fieldInfo.GetValue(fieldType);

                if (fieldObject != null)
                {
                    if (fieldType.GetInterface("IDictionary") != null || fieldType.GetInterface("IList") != null)
                    {
                        Serialize(fieldName, fieldObject, xmlWriter);
                    }
                    else
                    {
                        TypeConverter typeConverter = TypeDescriptor.GetConverter(fieldInfo.FieldType);
                        fieldValue = typeConverter.ConvertToString(fieldObject);

                        xmlWriter.WriteStartElement(fieldName);
                        xmlWriter.WriteString(fieldValue);
                        xmlWriter.WriteEndElement();
                    }
                }
            }

            xmlWriter.WriteEndElement();

            return true;
        }

        public static void Deserialize(Type staticClass, string fileName)
        {
            using (var xmlReader = new XmlTextReader(fileName))
            {
                FieldInfo[] fieldArray = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);
                string currentElement = null;

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.EndElement)
                        continue;

                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        currentElement = xmlReader.Name;
                    }

                    foreach (FieldInfo fieldInfo in fieldArray)
                    {
                        string fieldName = fieldInfo.Name;
                        Type fieldType = fieldInfo.FieldType;
                        object fieldObject = fieldInfo.GetValue(fieldType);

                        if (fieldInfo.IsNotSerialized)
                            continue;

                        if (fieldInfo.Name == currentElement)
                        {
                            if (typeof(IDictionary).IsAssignableFrom(fieldType) || typeof(IList).IsAssignableFrom(fieldType))
                            {
                                fieldObject = Deserialize(fieldName, fieldType, xmlReader);

                                fieldInfo.SetValueDirect(__makeref(fieldObject), fieldObject);
                            }
                            else if (xmlReader.NodeType == XmlNodeType.Text)
                            {
                                TypeConverter typeConverter = TypeDescriptor.GetConverter(fieldType);
                                object value = typeConverter.ConvertFromString(xmlReader.Value);

                                fieldInfo.SetValue(fieldObject, value);
                            }
                        }
                    }
                }
            }
        }

        static object Deserialize(string name, Type type, XmlReader xmlReader)
        {
            XmlAttributeOverrides xmlAttributeOverrides = new XmlAttributeOverrides();
            XmlAttributes xmlAttributes = new XmlAttributes();
            xmlAttributes.XmlRoot = new XmlRootAttribute(name);
            xmlAttributeOverrides.Add(type, xmlAttributes);
            XmlSerializer xmlSerializer = new XmlSerializer(type, xmlAttributeOverrides);

            return xmlSerializer.Deserialize(xmlReader);
        }

    }
}