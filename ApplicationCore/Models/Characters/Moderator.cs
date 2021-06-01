using ApplicationCore.Models.Services;

namespace ApplicationCore.Models.Characters
{
  public class Moderator : Person
  {
    public Moderator(string login, string password, string firstName, string secondName, string email, int age) : base(login, password, firstName, secondName, email, age)
    {
    }
  }
}