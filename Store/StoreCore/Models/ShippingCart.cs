using System.Xml.Serialization;
using StoreCore.Repository;

namespace StoreCore.Models
{
    [XmlRoot("Product")]
    public class ShippingCart:IIndexable
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlElement("IdProduct")]
        public string IdProduct { get; set; }
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}
