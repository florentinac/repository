﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StoreCore.Repository
{
    public class ProductRepository:XMLRepository<Product,int>
    {
        public ProductRepository(string fullPath) : base(fullPath)
        {
        }

        public void UpdateStock(int id)
        {         
            var productToUpdate = this.document.SelectSingleNode("/ArrayOfProduct/Product[@ID='" + id + "']");

            var stock = Int32.Parse(productToUpdate["Stock"].InnerText);
            productToUpdate["Stock"].InnerText = (--stock).ToString();
            
            document.Save(this.fullPath);
        }

        public override void Update(int id, Product product)
        {
            var newProduct = this.document.SelectSingleNode("/ArrayOfProduct/Product[@ID='" + id + "']");
            if (newProduct != null)
            {
                newProduct["Name"].InnerText = product.Name;
                newProduct["Category"].InnerText = product.Category;
                newProduct["Price"].InnerText = product.Price.ToString();
                newProduct["Stock"].InnerText = product.Stock.ToString();
            }
            document.Save(this.fullPath);

        }

        public IEnumerable<Product> GetByCategory(string category)
        {
            //var products = this.document.SelectNodes("/ArrayOfProduct/Product[Category='" + category + "']");
            var products = this.GetAll();
            var result = new List<Product>();
            foreach (var product in products)
            {
                if (product.Category.Equals(category))
                {
                    result.Add(product);
                }
            }
            return result;
        }
    }
}