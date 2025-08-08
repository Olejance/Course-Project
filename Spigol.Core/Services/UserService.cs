using Spigol.Core.Data;
using Spigol.Core.Domain;
using Spigol.Core.Interfaces;
using System.Linq;

namespace Spigol.Core.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // У реальному проєкті тут має бути логіка хешування паролю
        public User Login(string email, string password)
        {
            // Для курсового проєкту просто шукаємо за email
            return _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public void Register(User user)
        {
            // Перевіряємо, чи користувач з таким email вже існує
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }
    }
}