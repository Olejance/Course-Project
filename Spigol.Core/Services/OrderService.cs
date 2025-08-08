using Microsoft.EntityFrameworkCore;
using Spigol.Core.Data;
using Spigol.Core.Domain;
using Spigol.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spigol.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrdersForUser(Guid userId)
        {
            // Знаходимо всі замовлення, де Customer.Id збігається з userId.
            // Include(o => o.Products) - важливо, щоб завантажити товари, які є в замовленні
            return _context.Orders
                           .Where(o => o.Customer.Id == userId)
                           .Include(o => o.Products)
                           .ToList();
        }

        public void PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}