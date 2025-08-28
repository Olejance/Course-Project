using Microsoft.EntityFrameworkCore;
using Spigol.Core.Data;
using Spigol.Core.Interfaces;
using Spigol.Core.Services;
using Microsoft.Extensions.Logging;
using System;

// --- 1. Налаштування сервісів (Dependency Injection) ---

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Додаємо контролери
builder.Services.AddControllers();

// Додаємо Swagger для тестування API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Реєстрація сервісів ---

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDataSerializerService, JsonDataSerializerService>();

// --- 2. Налаштування додатку ---
var app = builder.Build();

// --- БЛОК ДЛЯ ЗАПОВНЕННЯ БАЗИ ДАНИХ ---
// Створюємо тимчасову "область видимості", щоб безпечно отримати доступ до наших сервісів
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Отримуємо екземпляр AppDbContext
        var context = services.GetRequiredService<Spigol.Core.Data.AppDbContext>();
        // Викликаємо наш метод для заповнення
        Spigol.API.Data.DataSeeder.Seed(context);
    }
    catch (Exception ex)
    {
        // Якщо щось пішло не так, виводимо помилку до консолі
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
// --- КІНЕЦЬ БЛОКУ ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
