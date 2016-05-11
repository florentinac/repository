using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreCore.Repository;

namespace StoreCore.Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [TestMethod]
        public void ShouldAddANewProduct()
        {
            var productRepository = new ProductRepository(@"Repository\Products.txt", "Product");
            productRepository.Add(new Product
            {
                Category = "Food",
                Name = "Bread",
                Price = 10,
                Stock = 4
            });
            
        }
    }
}
