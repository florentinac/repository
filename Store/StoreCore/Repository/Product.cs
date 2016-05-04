
using System.ComponentModel;
using System.Xml.Serialization;

namespace StoreCore.Repository
{
    [XmlRoot("Product")]
    public class Product: IIndexable
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Price")]
        public double Price { get; set; }
        [XmlElement("Category")]
        public string Category { get; set; }
        [XmlElement("Stock")]
        public int Stock { get; set; }
    }
}
