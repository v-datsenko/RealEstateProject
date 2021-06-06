using System;
using System.Collections.Generic;
using ApplicationCore.Models.RealEstate;

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
                realEstates.Add(new Apartment(new AddressPremises("Kharkiv", "Cilinogradska", "12a", "45"), 56.5, 25, 9000, 2, -1) { AmountSleepingPlaces = 3 });
                realEstates.Add(new Ground(new Address("Kharkiv", "Pobedy", "17"), 250, 20000));
                realEstates.Add(new House(new Address("Kharkiv", "Pobedy", "89"), 90, 40, 15000, TypeHouse.Separate, 2) { AmountSleepingPlaces = 3 });
                realEstates.Add(new Office(new AddressPremises("Kharkiv", "Cilinogradska", "44", "440"), 210, 30000, 4, 9));
                realEstates.Add(new House(new Address("Kharkiv", "Pobedy", "89"), 90, 40, 15000, TypeHouse.Duplex, 2) { AmountSleepingPlaces = 3 });

                realEstates.ForEach((x) => x.DisplayInfo());
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