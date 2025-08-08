using Spigol.Core.Domain;

namespace Spigol.Core.Interfaces
{
    // Інтерфейс для сервісу керування користувачами
    public interface IUserService
    {
        void Register(User user);
        User Login(string email, string password); // Пароль тут для прикладу, в реальності потрібне хешування
    }
}