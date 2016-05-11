using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoreCore.Repository
{   
    public class Category : IIndexable
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
