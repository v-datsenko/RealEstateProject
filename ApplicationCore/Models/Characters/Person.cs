using System;
using ApplicationCore.Models.Services;
using System.Text.Json.Serialization;
using System.Data.Linq.Mapping;

namespace ApplicationCore.Models.Characters
{
    public class Person : User , ICreatingDate
    {
        [Column(DbType = "NVarChar(50)")]
        public string FirstName { get; set; }
        [Column(DbType = "NVarChar(50)")]
        public string SecondName { get; set; }
        [Column(DbType = "NVarChar(50)")]
        public string Email { get; set; }
        [Column]
        public int Age { get; set; }
        [Column]
        public DateTime CreatingDate { get; set; }
        [JsonIgnore]
        public Photo Avatar { get; set; }
        

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