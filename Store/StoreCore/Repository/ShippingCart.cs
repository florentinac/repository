using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoreCore.Repository
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
