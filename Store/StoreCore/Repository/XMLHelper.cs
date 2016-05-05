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
            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {             
                var serializer = new XmlSerializer(typeof (T));
                serializer.Serialize(stream, item);
            }
        }

        internal T DeserializeList()
        {
            T products;
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(T));
                products = (T)serializer.Deserialize(stream);

                return products;
            }
        }

        internal void UpdateXmlSerialize(T item)
        {
            var itemsUpdate = new List<T>();

            var repozitory = new XMLRepository<List<T>, int>(fileName);
            var items = DeserializeList();
            
            itemsUpdate.Add(items);
            itemsUpdate.Add(item);
            
            repozitory.Add(itemsUpdate);
        }

    }
}
