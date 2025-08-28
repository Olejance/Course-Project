using Spigol.Core.Data;
using Spigol.Core.Domain;
using System.Linq;

namespace Spigol.API.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Переконуємось, що база даних створена. Якщо ні - вона буде створена.
            context.Database.EnsureCreated();

            // Перевіряємо, чи є вже товари в базі даних.
            // Якщо так, то нічого не робимо.
            if (context.Products.Any())
            {
                return;
            }

            // Список тестових товарів
            var products = new Product[]
            {
                new Product("Laptop Pro", 45999.99m, "Laptops", "Powerful laptop for professionals.", true),
                new Product("Smartphone X", 23499.50m, "Smartphones", "Latest generation smartphone.", true),
                new Product("Wireless Mouse", 1200.00m, "Peripherals", "Ergonomic wireless mouse.", false)
            };

            // Додаємо товари до контексту
            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            // Зберігаємо зміни в базі даних
            context.SaveChanges();
        }
    }
}