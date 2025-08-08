using System.Collections.Generic;

namespace Spigol.Core.Domain
{
    // Клас для покупця
    public class Customer : User
    {
        public List<Order> Orders { get; private set; }
        public List<Product> Wishlist { get; private set; }

        public Customer() : base() { }

        public Customer(string name, string email) : base(name, email)
        {
            Orders = new List<Order>();
            Wishlist = new List<Product>();
        }

        public void AddToWishlist(Product product)
        {
            if (!Wishlist.Contains(product))
            {
                Wishlist.Add(product);
            }
        }

        public void RemoveFromWishlist(Product product)
        {
            Wishlist.Remove(product);
        }

        public override string GetRole()
        {
            return "Customer";
        }
    }
}