using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreCore.Models;

namespace StoreCore.Repository.Tests
{
    [TestClass]
    public class ViewProduct
    {
        [TestMethod]
        public void ShouldGetAllProductByASpecifiedCategory()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Category = "Food",
                    Name = "Bread",
                    Price = 10,
                    Stock = 4
                },
                new Product
                {
                    Category = "Fruits",
                    Name = "Appel",
                    Price = 10,
                    Stock = 4
                },
                new Product
                {
                    Category = "Fruits",
                    Name = "Kiwi",
                    Price = 10,
                    Stock = 4
                }
            };
            var viewProduct = new BusinessLogic.ViewProduct(products);
            var result = viewProduct.GetByCategory("Fruits");
            Assert.AreEqual(2,result.Count());
        }
        [TestMethod]
        public void ShouldReturnZeroProductsIfTheCategoryDoesntExists()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Category = "Food",
                    Name = "Bread",
                    Price = 10,
                    Stock = 4
                },
                new Product
                {
                    Category = "Fruits",
                    Name = "Appel",
                    Price = 10,
                    Stock = 4
                },
                new Product
                {
                    Category = "Fruits",
                    Name = "Kiwi",
                    Price = 10,
                    Stock = 4
                }
            };
            var viewProduct = new BusinessLogic.ViewProduct(products);
            var result = viewProduct.GetByCategory("Test");
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void ShouldReturnAllTheCategory()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Category = "Food",
                    Name = "Bread",
                    Price = 10,
                    Stock = 4
                },
                new Product
                {
                    Category = "Fruits",
                    Name = "Appel",
                    Price = 10,
                    Stock = 4
                },
                new Product
                {
                    Category = "Fruits",
                    Name = "Kiwi",
                    Price = 10,
                    Stock = 4
                }
            };
            var viewProduct = new BusinessLogic.ViewProduct(products);
            var result = viewProduct.GetAllCategory();
            Assert.AreEqual(2, result.Count());
        }        
    }
}
