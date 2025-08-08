namespace Spigol.Core.Domain
{
    // Клас для адміністратора
    public class Admin : User
    {
        public Admin() : base() { }

        public Admin(string name, string email) : base(name, email) { }

        public override string GetRole()
        {
            return "Admin";
        }
    }
}