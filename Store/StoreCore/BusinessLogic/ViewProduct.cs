using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using StoreCore.Repository;

namespace StoreCore.BusinessLogic
{
    public class ViewProduct
    {
        private IEnumerable<Product> products;      

        public ViewProduct(string fullPath, string tabelName)
        {
            var repository = new ProductRepository(fullPath, tabelName);
            this.products = repository.GetAll();
        }

        public ViewProduct(IEnumerable<Product> products)
        {
            this.products = products;
        }

        public IEnumerable<Product> GetByCategory(string category)
        {
            var result = new List<Product>();
            foreach (var product in this.products)
            {
                if (product.Category.Equals(category))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public BitmapImage GetImageById(int id)
        {
            var image = new BitmapImage();

            foreach (var product in this.products)
            {
                if (product.Id.Equals(id))
                {
                    image.BeginInit();
                    image.UriSource = new Uri(product.Image);
                    image.EndInit();
                    return image;
                }
            }

            return image;
        }

        public IEnumerable<string> GetAllCategory()
        {
            var result = new List<string>();

            foreach (var product in this.products)
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
