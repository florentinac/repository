using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace StoreCore.Repository
{
    public class ProductRepository:XMLRepository<Product,int>
    {
        public ProductRepository(string fullPath, string tabelName) : base(fullPath, tabelName)
        {
        }

        public void UpdateStock(int id)
        {         
            var productToUpdate = this.document.SelectSingleNode("/ArrayOfProduct/Product[@ID='" + id + "']");

            var stock = int.Parse(productToUpdate["Stock"].InnerText);
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

        public BitmapImage GetImageByID(int id)
        {
            var products = this.GetAll();
            var image = new BitmapImage();

            foreach (var product in products)
            {
                if (product.Id.Equals(id))
                {
                    image.BeginInit();
                    image.UriSource = new Uri(Directory.GetCurrentDirectory() + product.Image);
                    image.EndInit();
                    return image;
                }
            }     
                         
            return image;
        }

        public IEnumerable<string> GetAllCategory()
        {
            var products = this.GetAll();
            var result = new List<string>();

            foreach (var product in products)
            {
                if (!result.Contains(product.Category))
                {
                    result.Add(product.Category);
                }
            }

            return result;
        }
    }
}
