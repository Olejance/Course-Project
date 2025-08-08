using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spigol.Core.Data;
using Spigol.Core.Domain;
using Spigol.Core.Services;
using System.Linq;

namespace Spigol.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private AppDbContext _context = null!;
        private ProductService _productService = null!;

        // Цей метод виконується перед кожним тестом
        [TestInitialize]
        public void Setup()
        {
            // Налаштовуємо базу даних у пам'яті
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _productService = new ProductService(_context);
        }

        [TestMethod]
        public void Add_ShouldAddProductToDatabase()
        {
            // Arrange
            var product = new Product("Test Laptop", 1000m, "Laptops", "A test laptop");

            // Act
            _productService.Add(product);

            // Assert
            Assert.AreEqual(1, _context.Products.Count());
            Assert.AreEqual("Test Laptop", _context.Products.First().Name);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllProducts()
        {
            // Arrange
            _context.Products.Add(new Product("Laptop", 1500m, "Laptops", "Gaming laptop"));
            _context.Products.Add(new Product("Mouse", 100m, "Peripherals", "Gaming mouse"));
            _context.SaveChanges();

            // Act
            var products = _productService.GetAll();

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count);
        }

        [TestMethod]
        public void GetById_ShouldReturnCorrectProduct_WhenProductExists()
        {
            // Arrange
            var productToFind = new Product("FindMe Laptop", 2000m, "Laptops");
            _context.Products.Add(productToFind);
            _context.SaveChanges();

            // Отримуємо Id, який присвоїла база даних
            var productId = productToFind.Id;

            // Act
            var foundProduct = _productService.GetById(productId);

            // Assert
            Assert.IsNotNull(foundProduct);
            Assert.AreEqual(productId, foundProduct.Id);
            Assert.AreEqual("FindMe Laptop", foundProduct.Name);
        }

        [TestMethod]
        public void GetById_ShouldReturnNull_WhenProductDoesNotExist()
        {
            // Arrange
            // База даних порожня

            // Act
            var foundProduct = _productService.GetById(999); // Шукаємо неіснуючий Id

            // Assert
            Assert.IsNull(foundProduct);
        }

        [TestMethod]
        public void Remove_ShouldRemoveProductFromDatabase()
        {
            // Arrange
            var productToRemove = new Product("ToDelete Laptop", 500m, "Laptops");
            _context.Products.Add(productToRemove);
            _context.SaveChanges();

            var productId = productToRemove.Id;
            Assert.AreEqual(1, _context.Products.Count(), "Pre-condition failed: product was not added.");

            // Act
            _productService.Remove(productId);

            // Assert
            // Перевіряємо, що товар дійсно видалено
            Assert.AreEqual(0, _context.Products.Count());
            Assert.IsNull(_context.Products.FirstOrDefault(p => p.Id == productId));
        }
    }
}