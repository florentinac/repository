using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace StoreCore.Repository
{
    public class ProductRepository:XMLRepository<Product,int>
    {
        public ProductRepository(string fullPath, string tabelName) : base(fullPath, tabelName)
        {
        }

        public override void Update(int id, Product product)
        {
            var item = (from node in doc.Root.Elements("Product")
                        where node.Attribute("ID").Value == id.ToString()
                        select node).Single();

            if (item != null)
            {
                item.Element("Name").Value = product.Name;
                item.Element("Category").Value = product.Category;
                item.Element("Price").Value = product.Price.ToString();
                item.Element("Stock").Value = product.Stock.ToString();
                item.Element("Image").Value = product.Image;
            }

            doc.Save(this.fullPath);
        }

        public override void Delete(int id)
        {
            var item = (from node in doc.Root.Elements("Product")
                        where node.Attribute("ID").Value == id.ToString()
                        select node);
            item.Remove();
            UpdateIdNodes(id);
            doc.Save(this.fullPath); ;
        }
        private void UpdateIdNodes(int id)
        {
            var items = (doc.Root.Elements("Product")
                .Where(xml2 => string.Compare(xml2.Attribute("ID").Value, id.ToString(), StringComparison.Ordinal) > 0));
            foreach (var item in items)
            {
                item.Attribute("ID").Value = (int.Parse(item.Attribute("ID").Value) - 1).ToString();
            }
        }
    }
}
