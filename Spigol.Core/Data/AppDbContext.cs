using Microsoft.EntityFrameworkCore;
using Spigol.Core.Domain;

namespace Spigol.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet<T> представляє таблицю в базі даних для вказаного класу
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Налаштування зв'язку "один-до-багатьох" між Customer та Order
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders) // У Customer є багато Orders
                .WithOne(o => o.Customer) // У кожного Order є один Customer
                .HasForeignKey("CustomerId"); // Вказуємо, що буде створено зовнішній ключ CustomerId
        }
    }
}