using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindProducts.Infrastructure;
using NorthwindProducts.Infrastructure.Services;
using NorthwindProducts.Core.Model;
using System.Collections.Generic;
using System.Linq;
using EF = NorthwindProducts.Infrastructure.Data;

namespace NorthwindProducts.Test.Integration
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public void GetAllProducts_Returns_Count()
        {
            // Arrange
            var productService = new ProductService(new UnitOfWork(new EF.NorthwindEntities()));
            var products = new List<Product>();

            // Act
            products = productService.GetAllProducts().ToList();

            // Assert
            Assert.AreEqual(products.Count, 77);
        }
    }
}
