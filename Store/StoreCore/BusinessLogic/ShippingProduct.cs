using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCore.Models;
using StoreCore.Repository;

namespace StoreCore.BusinessLogic
{
    public class ShippingProduct
    {
        private IRepository<ShippingCart, int> repository; 
        public ShippingProduct(string path, string tabelName)
        {
            this.repository = new XMLRepository<ShippingCart,int>(path, tabelName);
        }

        public double CalculateTotalShippingPrice()
        {
            var productsCard = repository.GetAll();
            var productRepository = new ProductRepository(@"Repository\Product.txt", "ArrayOfProduct");
            double totalPrice = 0;
            foreach (var product in productsCard)
            {
                var productPrice = productRepository.GetById(int.Parse(product.IdProduct)).Price;
                totalPrice = totalPrice + productPrice;
            }

            return totalPrice;
        }
    }
}
