using System;
using System.Collections.Generic;
using System.Linq;

namespace Spigol.Core.Domain
{
    // Клас для замовлення
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; private set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public Customer Customer1
        {
            get => default;
            set
            {
            }
        }

        public Product Product
        {
            get => default;
            set
            {
            }
        }

        public Order()
        {
            Products = new List<Product>();
        }

        public Order(Customer customer)
        {
            Customer = customer;
            Products = new List<Product>();
            CreatedAt = DateTime.Now;
            Status = "Pending";
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public decimal CalculateTotal()
        {
            return Products.Sum(p => p.Price);
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }
    }
}