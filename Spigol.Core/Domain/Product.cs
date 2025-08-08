namespace Spigol.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; private set; }
        public string Category { get; set; } = string.Empty;
        public bool InStock { get; private set; }

        // Конструктор для створення продукту
        public Product(string name, decimal price, string category, string description = "", bool inStock = true)
        {
            Name = name;
            Price = price;
            Category = category;
            Description = description;
            InStock = inStock;
        }

        // Метод для оновлення ціни з валідацією
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice >= 0)
            {
                Price = newPrice;
            }
        }

        // Метод для оновлення статусу наявності
        public void UpdateStock(bool newStatus)
        {
            InStock = newStatus;
        }
    }
}