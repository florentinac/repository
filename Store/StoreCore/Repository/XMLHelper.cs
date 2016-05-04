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
    internal class XMLHelper<T>
    {       
        private string fileName;
        public XMLHelper(string fileName)
        {
            this.fileName = fileName;              
        }

        internal void Serialize(T item)
        {                   
            using (var stream = new FileStream(fileName, FileMode.Append))
            {
                var serializer = new XmlSerializer(typeof (T));
                serializer.Serialize(stream, item);
            }
        }

        internal List<T> DeserializeList()
        {
            var products = new List<T>();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                products = (List<T>)serializer.Deserialize(stream);

                return products;
            }
        }        
    }
}
