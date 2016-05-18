using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreCore.Repository;
using Should;

namespace StoreCore.Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [TestMethod]
        public void ShouldAddANewProduct()
        {
            var xmlString = "<ArrayOfProduct></ArrayOfProduct>";
            var repository = new XMLRepository<Product,int>(xmlString, "ArrayOfProduct");
            repository.Add(new Product
            {
                Category = "Food",
                Name = "Bread",
                Price = 10,
                Stock = 4
            });                      
        }       
        [TestMethod]
        public void ShouldGetAllProduct()
        {
            var xmlString = "<ArrayOfProduct></ArrayOfProduct>";
            var repository = new XMLRepository<Product, int>(xmlString, "ArrayOfProduct");
            repository.Add(new Product
            {
                Category = "Food",
                Name = "Bread",
                Price = 10,
                Stock = 4
            });
            var actualResult = repository.GetAll();
            Assert.AreEqual(3, actualResult.Count());
        }

        [TestMethod]
        public void ShouldGetAProductById()
        {
            var productRepository = new ProductRepository(@"Repository\Products.txt", "Product");
            var actualResult = productRepository.GetById(2);
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void ShouldDeleteAProduct()
        {
            var productRepository = new ProductRepository(@"Repository\Products.txt", "Product");
            productRepository.Delete(2);
            Assert.AreEqual(2,productRepository.GetAll().Count());
        }

        [TestMethod]
        public void ShouldUpdateAProduct()
        {
            var productRepository = new ProductRepository(@"Repository\Products.txt", "Product");
            productRepository.Update(2,new Product
            {
                Category = "Fruits",
                Name = "Appel",
                Price = 12,
                Stock = 3
            });
            var products = productRepository.GetAll().ToArray();
            Assert.AreEqual("Appel",products[1].Name);
        }

        [TestMethod]
        public void ShouldUpdateTheStockForProduct()
        {
            var productRepository = new ProductRepository(@"Repository\Products.txt", "Product");
           // productRepository.UpdateStock(2);
            var products = productRepository.GetAll().ToArray();
            Assert.AreEqual(2, products[1].Stock);
        }
    }
}
