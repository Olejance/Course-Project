using Spigol.Core.Domain;
using Spigol.Core.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Spigol.Core.Services
{
    public class JsonDataSerializerService : IDataSerializerService
    {
        private readonly JsonSerializerOptions _options;

        public JsonDataSerializerService()
        {
            // Налаштування для красивого форматування JSON файлу (з відступами)
            _options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
        }

        public void ExportProducts(IEnumerable<Product> products, string filePath)
        {
            // Серіалізуємо список товарів у JSON рядок
            string jsonString = JsonSerializer.Serialize(products, _options);
            // Записуємо рядок у файл
            File.WriteAllText(filePath, jsonString);
        }

        public List<Product> ImportProducts(string filePath)
        {
            // Перевіряємо, чи існує файл
            if (!File.Exists(filePath))
            {
                // Якщо файлу немає, повертаємо порожній список
                return new List<Product>();
            }

            // Читаємо весь текст із файлу
            string jsonString = File.ReadAllText(filePath);
            // Десеріалізуємо JSON рядок у список об'єктів Product
            var products = JsonSerializer.Deserialize<List<Product>>(jsonString);

            return products ?? new List<Product>();
        }
    }
}