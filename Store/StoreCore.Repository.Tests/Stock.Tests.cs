using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace StoreCore.Repository.Tests
{
    [TestClass]
    public class Stock
    {
        [TestMethod]
        public void ShouldDisplayAMessageWhenTheStockForAProductIsLimited()
        {          
            var stock= new BusinessLogic.Stock(new Product
            {
                Category = "Food",
                Name = "Bread",
                Price = 10,
                Stock = 4
            });
            var result = stock.GetStockMessage();

            Assert.AreEqual("Few in stock", result);
        }

        [TestMethod]
        public void ShouldDisplayAMessageWhenTheProductIsNotInStock()
        {
            var stock = new BusinessLogic.Stock(new Product
            {
                Category = "Food",
                Name = "Bread",
                Price = 10,
                Stock = 0
            });
            var result = stock.GetStockMessage();

            Assert.AreEqual("Unavailable stock", result);
        }

        [TestMethod]
        public void ShouldDisplayAMessageWhenTheProductIsInStock()
        {
            var stock = new BusinessLogic.Stock(new Product
            {
                Category = "Food",
                Name = "Bread",
                Price = 10,
                Stock = 7
            });
            var result = stock.GetStockMessage();

            Assert.AreEqual("In stock", result);
        }

        [TestMethod]
        public void CheckStockAvailabilityForAProduct()
        {
            var stock = new BusinessLogic.Stock(new Product
            {
                Category = "Food",
                Name = "Bread",
                Price = 10,
                Stock = 7
            });
            var result = stock.CheckStockAvailability();

            result.ShouldBeTrue();
        }

        [TestMethod]
        public void CheckStockAvailabilityForAProductWithUnavailableStock()
        {
            var stock = new BusinessLogic.Stock(new Product
            {
                Category = "Food",
                Name = "Bread",
                Price = 10,
                Stock = 0
            });
            var result = stock.CheckStockAvailability();

            result.ShouldBeFalse();
        }
    }
}
