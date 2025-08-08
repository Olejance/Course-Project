using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spigol.Core.Domain;
using Spigol.Core.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Spigol.Tests
{
    [TestClass]
    public class JsonDataSerializerServiceTests
    {
        private string _testFilePath = null!;

        [TestInitialize]
        public void Setup()
        {
            // Створюємо унікальний шлях до файлу перед кожним тестом
            _testFilePath = $"{System.Guid.NewGuid()}.json";
        }

        // Метод, що виконується після кожного тесту для очищення
        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestMethod]
        public void ExportProducts_ShouldCreateJsonFile()
        {
            // Arrange
            var service = new JsonDataSerializerService();
            var products = new List<Product>
            {
                // ВИКОРИСТОВУЄМО НОВИЙ КОНСТРУКТОР
                new Product("Test Product", 99.99m, "Testing")
            };

            // Act
            service.ExportProducts(products, _testFilePath);

            // Assert
            Assert.IsTrue(File.Exists(_testFilePath));
            var jsonContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(jsonContent.Contains("Test Product"));
        }

        [TestMethod]
        public void ImportProducts_ShouldReadProductsFromFile()
        {
            // Arrange
            var service = new JsonDataSerializerService();
            var productsToExport = new List<Product>
            {
                new Product("Laptop", 1500m, "Electronics")
            };
            service.ExportProducts(productsToExport, _testFilePath);

            // Act
            var importedProducts = service.ImportProducts(_testFilePath);

            // Assert
            Assert.IsNotNull(importedProducts);
            Assert.AreEqual(1, importedProducts.Count);
            Assert.AreEqual("Laptop", importedProducts.First().Name);
        }
    }
}