using Spigol.Core.Domain;
using System.Collections.Generic;

namespace Spigol.Core.Interfaces
{
    // Інтерфейс для сервісу керування товарами
    public interface IProductService
    {
        // Отримати список всіх доступних товарів
        List<Product> GetAll();

        // Отримати товар за його унікальним ідентифікатором
        Product GetById(int id);

        // Додати новий товар до системи (для адміністратора)
        void Add(Product product);

        // Видалити товар із системи за його ідентифікатором (для адміністратора)
        void Remove(int id);
    }
}