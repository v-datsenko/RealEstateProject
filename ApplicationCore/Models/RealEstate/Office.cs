using System;

namespace ApplicationCore.Models.RealEstate
{
  public class Office : BuildingPremises
  {
    public bool IsVentilation = false;
    public Office(AddressPremises addressPremises, double area, double price, int amountRooms, int floor) : base(addressPremises, area, price, amountRooms, floor)
    {
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine("This is an office.\n");
    }
  }
}