using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spigol.Core.Domain;
using System.Linq;

namespace Spigol.Tests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void AddProduct_ShouldAddProductToCart()
        {
            // Arrange
            var cart = new Cart();
            var product = new Product("Laptop", 1500m, "Electronics");

            // Act
            cart.AddProduct(product);

            // Assert
            Assert.AreEqual(1, cart.Products.Count);
            Assert.IsTrue(cart.Products.Contains(product));
        }

        [TestMethod]
        public void GetTotal_ShouldReturnCorrectSum()
        {
            // Arrange
            var cart = new Cart();
            var product1 = new Product("Laptop", 1500.50m, "Electronics");
            var product2 = new Product("Mouse", 50.50m, "Peripherals");
            cart.AddProduct(product1);
            cart.AddProduct(product2);

            // Act
            decimal total = cart.GetTotal();

            // Assert
            Assert.AreEqual(1551.00m, total);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllProductsFromCart()
        {
            // Arrange
            var cart = new Cart();
            cart.AddProduct(new Product("Product A", 100m, "Category A"));
            cart.AddProduct(new Product("Product B", 200m, "Category B"));

            // Act
            cart.Clear();

            // Assert
            Assert.AreEqual(0, cart.Products.Count);
        }
    }
}