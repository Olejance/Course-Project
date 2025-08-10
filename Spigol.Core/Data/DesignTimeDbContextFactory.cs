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
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // ВАЖЛИВО: використовуємо ТОЧНО ТАКИЙ САМИЙ абсолютний шлях
            optionsBuilder.UseSqlite("Data Source=D:\\SigmaFolder\\University\\2ndYear\\2nd semester\\ООП курсовий\\SpijoniroGolubiroMarketplace\\SpijoniroGolubiroMarketplace\\marketplace.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}