using System;
using System.Collections.Generic;
using ApplicationCore.Models.Services;

namespace ApplicationCore.Models.Characters
{
  public class Customer : Person
  {
    public List<Advertisement> Advertisements { get; set; }
    public Customer(string login, string password, string firstName, string secondName, string email, int age) : base(login, password, firstName, secondName, email, age)
    {
      Advertisements = new List<Advertisement>();
    }
  }
}