using System;

namespace ApplicationCore.Models.RealEstate
{
  public class Garage : RealEstate
  {
    public int AmountParkingPlaces { get; set; } = 1;
    public Garage(Address address, double area, double price) : base(address, area, price)
    {
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"This is a garage with {AmountParkingPlaces switch{1=>"one parking place",_=>$"{AmountParkingPlaces} parking places"}}\n");
    }
  }
}