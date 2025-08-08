using Spigol.Core.Domain;
using System;
using System.Collections.Generic;

namespace Spigol.Core.Interfaces
{
    // Інтерфейс для сервісу керування замовленнями
    public interface IOrderService
    {
        // Розмістити нове замовлення в системі
        void PlaceOrder(Order order);

        // Отримати історію замовлень для конкретного користувача за його Id
        List<Order> GetOrdersForUser(Guid userId);
    }
}