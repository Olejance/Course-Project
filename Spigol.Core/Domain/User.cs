using System;

namespace Spigol.Core.Domain
{
    // Абстрактний базовий клас для всіх користувачів
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        protected User() { }

        protected User(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        // Абстрактний метод, що має бути реалізований нащадками
        public abstract string GetRole();
    }
}