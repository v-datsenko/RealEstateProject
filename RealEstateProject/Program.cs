using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Models.Characters;
using ApplicationCore.Models.RealEstate;
using ApplicationCore.Services;

namespace RealEstateProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                ValidationPersonService validation = new ValidationPersonService();
                SerializationService<List<Person>> serializationPeople = new SerializationService<List<Person>>(new JsonSerializerOptions { WriteIndented = true });
                Person Tom = new Person("Login231", "231qwer", "Valerii", "Datsenko", "dbs1420@gmail.com", 21);
                List<Person> people = new List<Person> { new Person("Login231", "231qwer", "Valerii", "Datsenko", "dbs1420@gmail.com", 21),
                new Person("Login231", "231qwer", "Valerii", "Datsenko", "dbs1420@gmail.com", 21),
                new Person("Login1403", "231qwer", "Valerii", "Datsenko", "dvs1403@gmail.com", 21),
                new Person("Login231", "231qwer", "Valerii", "Datsenko", "dvs0901@gmail.com", 21),
                new Person("dvs1403", "231qwer", "Valerii", "Datsenko", "dq23@gmail.com", 21),
                new Person("Login231", "231qwer", "Valerii", "Datsenko", "dls1@gmail.com", 21)};
                bool isValid = true;
                foreach(var p in people)
                {
                    if (!validation.Valid(p))
                        isValid = false;
                }
                if (isValid)
                {
                    SQLPersonRepository repository = new SQLPersonRepository(@"Data Source=.\SQLEXPRESS;Initial Catalog=peopledb;Integrated Security=True");
                    
                    foreach(var p in people)
                    {
                        repository.Create(p);
                    }
                    repository.Save();

                }
                else
                {
                    Console.WriteLine("Error input data!");
                }
            }catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}