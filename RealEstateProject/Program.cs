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
                Console.WriteLine("Application is running...");

                ValidationPersonService validation = new ValidationPersonService();
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
                    DatabasePersonRepository repository = new DatabasePersonRepository(@"Data Source=.\SQLEXPRESS;Initial Catalog=datsenkodb;Integrated Security=True");

                    //Заполнение базы данных людьми из списка
                    foreach(var p in people)
                    {
                        repository.Create(p);
                    }
                    //Сохранение изменений в базе данных
                    repository.Save();

                    //Получение людей из базы данных
                    people = repository.GetPeopleList() as List<Person>;
                    Console.WriteLine("\nUsers in the database:");
                    foreach (var p in people)
                    {
                        Console.WriteLine($"{p.Id}) Log: {p.Login}, Pass: {p.Password}, Name: {p.FirstName} {p.SecondName}, Email: {p.Email}, Age: {p.Age}");
                    }

                    //Получение человека из базы данных и изменение его свойств
                    var person = repository.GetPerson(3);
                    person.Login = "Login333";
                    person.Email = "newemail@gmail.com";
                    repository.Save();

                    //Обновление человека в базе данных
                    repository.Update(new Person(2,"LoginId2", "231qwer", "Valerii", "Datsenko", "dvs1403@gmail.com", 21,DateTime.Now));
                    //Удаление человека с индексом 5 из базы данных
                    repository.Delete(5);
                    repository.Save();

                    //Получение людей из базы данных после изменений
                    people = repository.GetPeopleList() as List<Person>;
                    Console.WriteLine("\nUsers in the database after changes:");
                    foreach (var p in people)
                    {
                        Console.WriteLine($"{p.Id}) Log: {p.Login}, Pass: {p.Password}, Name: {p.FirstName} {p.SecondName}, Email: {p.Email}, Age: {p.Age}");
                    }

                    Console.WriteLine("\nPress any key to close application!");
                    Console.ReadKey();
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