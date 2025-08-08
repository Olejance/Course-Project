using System;
using System.Collections.Generic;
using System.Linq;

namespace Spigol.Core.Domain
{
    // Клас для кошика
    public class Cart
    {
        public Guid Id { get; set; }
        public List<Product> Products { get; private set; }

        public Product Product
        {
            get => default;
            set
            {
            }
        }

        public Cart()
        {
            Id = Guid.NewGuid();
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public decimal GetTotal()
        {
            return Products.Sum(p => p.Price);
        }

        public void Clear()
        {
            Products.Clear();
        }
    }
}