

namespace ApplicationCore.Models.Characters
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}