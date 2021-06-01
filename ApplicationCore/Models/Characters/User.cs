namespace ApplicationCore.Models.Characters
{
  public abstract class User
  {
    private int _id;
    
    public string Login { get; set; }
    public string Password { get; set; }

    public User(string login, string password)
    {
      this.Login = login;
      this.Password = password;
    }
  }
}