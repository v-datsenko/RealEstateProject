using System;
using System.Collections.Generic;
using System.Text.Json;
using ApplicationCore.Models.Characters;
using ApplicationCore.Models.RealEstate;
using ApplicationCore.Services;

namespace RealEstateProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<RealEstate> realEstates = new List<RealEstate>();
                realEstates.Add(new Apartment(new AddressPremises("Kharkiv", "Cilinogradska", "36b", "23d"), 56.5, 25, 6500, 1, 3));
                realEstates.Add(new Garage(new Address("Kharkiv", "Cilinogradska", "56"), 20.3, 1000));
                realEstates.Add(new Apartment(new AddressPremises("Kharkiv", "Cilinogradska", "12a", "45"), 56.5, 25, 9000, 2, 1) { AmountSleepingPlaces = 3 });
                realEstates.Add(new Ground(new Address("Kharkiv", "Pobedy", "17"), 250, 20000));
                realEstates.Add(new House(new Address("Kharkiv", "Pobedy", "89"), 90, 40, 15000, TypeHouse.Separate, 2) { AmountSleepingPlaces = 3 });
                realEstates.Add(new Office(new AddressPremises("Kharkiv", "Cilinogradska", "44", "440"), 210, 30000, 4, 9));
                realEstates.Add(new House(new Address("Kharkiv", "Pobedy", "89"), 90, 40, 15000, TypeHouse.Duplex, 2) { AmountSleepingPlaces = 3 });

                realEstates.ForEach((x) => x.DisplayInfo());
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
                    serializationPeople.SerializeToFile(people,"C:\\Test","people");
                    people = serializationPeople.DeserializeFromFile("C:\\Test", "people");

                    foreach(var p in people)
                    {
                        Console.WriteLine($"{p.Login} - {p.FirstName} {p.SecondName}");
                    }
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