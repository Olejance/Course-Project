using Spigol.Core.Data;
using Spigol.Core.Domain;
using Spigol.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Spigol.Core.Services
{
    public class ProductService : IProductService
    {
        // _context - це наш доступ до бази даних
        private readonly AppDbContext _context;

        // Конструктор, який приймає екземпляр AppDbContext
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            // Додаємо товар до DbSet і зберігаємо зміни в БД
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            // Повертаємо всі товари з таблиці Products у вигляді списку
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            // Знаходимо товар за його Id. FirstOrDefault поверне null, якщо товар не знайдено.
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            // Знаходимо товар, який потрібно видалити
            var productToRemove = GetById(id);
            if (productToRemove != null)
            {
                // Видаляємо товар і зберігаємо зміни
                _context.Products.Remove(productToRemove);
                _context.SaveChanges();
            }
        }
    }
}