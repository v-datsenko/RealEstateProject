using System;
using ApplicationCore.Models.Services;
using System.Text.Json.Serialization;

namespace ApplicationCore.Models.Characters
{
    public class Person : User , ICreatingDate
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        [JsonIgnore]
        public Photo Avatar { get; set; }
        [JsonIgnore]
        public DateTime CreatingDate { get; }

        public Person() { }
        public Person(string login, string password, string firstName, string secondName, string email, int age) : base(login, password)
        {
        FirstName = firstName;
        SecondName = secondName;
        Email = email;
        Age = age;
        CreatingDate = DateTime.Now;
        }
        public Person(int id,string login, string password, string firstName, string secondName, string email, int age, DateTime creatingDate) : base(login, password)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Email = email;
            Age = age;
            CreatingDate = creatingDate;
        }
    }
}