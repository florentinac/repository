using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace StoreCore.Repository
{
    internal class XMLHelper
    {

        internal string Serialize<T>(T item)
        {
            string result;
            var serializer = new XmlSerializer(typeof(T));
            var xmlWriterSettings = new XmlWriterSettings
            {           
                CloseOutput = false,
                OmitXmlDeclaration = true,
                Indent = true
            };
            var xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("","");
             
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
                {
                    serializer.Serialize(xmlWriter, item, xmlNameSpace);
                    result = stringWriter.ToString();
                }
            }

            return result;
        }        

        internal T Deserialize<T>(string serializedItem)
        {
            T item;
            var serializer = new XmlSerializer(typeof(T));

            using (var stringReader = new StringReader(serializedItem))
            {
                item = (T)serializer.Deserialize(stringReader);
            }

            return item;
        }
    }
}
