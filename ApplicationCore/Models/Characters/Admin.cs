namespace ApplicationCore.Models.Characters
{
    public class Admin : User
    {
        public Admin() { }
        public Admin(string login, string password) : base(login, password)
        {}
    }
}