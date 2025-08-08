using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Spigol.Core.Data
{
    // Цей клас використовується тільки інструментами EF Core (напр., для міграцій)
    // Він не використовується під час роботи самого додатку
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Створюємо налаштування для нашої бази даних
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Вказуємо, що будемо використовувати SQLite і задаємо ім'я файлу бази даних
            // Цей рядок підключення буде використовуватися ТІЛЬКИ для створення міграцій
            optionsBuilder.UseSqlite("Data Source=design_time.db");

            // Створюємо і повертаємо екземпляр нашого AppDbContext
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}