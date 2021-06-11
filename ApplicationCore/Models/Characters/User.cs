namespace ApplicationCore.Models.Characters
{
  public abstract class User
  {
    private int _id;
    
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