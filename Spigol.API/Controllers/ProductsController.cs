using Microsoft.AspNetCore.Mvc;
using Spigol.Core.Interfaces;

namespace Spigol.API.Controllers
{
    [ApiController]
    [Route("api/products")] // Всі методи в цьому класі будуть доступні за адресою /api/products
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        // Конструктор, який отримує IProductService завдяки налаштуванням DI у Program.cs
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // Цей метод буде реагувати на GET-запит на адресу /api/products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAll();
            // Повертаємо список товарів у форматі JSON з кодом 200 OK
            return Ok(products);
        }

        // Цей метод буде реагувати на GET-запит на адресу /api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound(); // Якщо товар не знайдено, повертаємо помилку 404
            }
            return Ok(product);
        }
    }
}