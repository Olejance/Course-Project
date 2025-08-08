using Spigol.Core.Domain;
using System.Collections.Generic;

namespace Spigol.Core.Interfaces
{
    // Інтерфейс для сервісу серіалізації/десеріалізації даних
    public interface IDataSerializerService
    {
        // Експортує список товарів у файл
        void ExportProducts(IEnumerable<Product> products, string filePath);

        // Імпортує список товарів із файлу
        List<Product> ImportProducts(string filePath);
    }
}