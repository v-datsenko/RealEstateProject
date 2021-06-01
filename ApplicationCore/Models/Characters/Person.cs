using System;
using ApplicationCore.Models.Services;

namespace ApplicationCore.Models.Characters
{
  public class Person : User , ICreatingDate
  {
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public Photo Avatar { get; set; }
    public DateTime CreatingDate { get; }

    public Person(string login, string password, string firstName, string secondName, string email, int age) : base(login, password)
    {
      FirstName = firstName;
      SecondName = secondName;
      Email = email;
      Age = age;
      CreatingDate = DateTime.Now;
    }


  }
}