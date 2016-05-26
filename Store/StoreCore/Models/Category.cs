using System.Xml.Serialization;
using StoreCore.Repository;

namespace StoreCore.Models
{   
    public class Category : IIndexable
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
