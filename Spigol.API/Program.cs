using Microsoft.EntityFrameworkCore;
using Spigol.Core.Data;
using Spigol.Core.Interfaces;
using Spigol.Core.Services;

// --- 1. Налаштування сервісів (Dependency Injection) ---

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSwagger",
        policy =>
        {
            policy.WithOrigins("http://localhost:5069")
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowSwagger");

app.UseAuthorization();

app.MapControllers();

app.Run();
