using System;
using System.Diagnostics;

namespace ApplicationCore.Models.RealEstate
{
  public class Apartment : BuildingPremises , ILivingQuarters
  {
    public double LivingArea { get; set; }
    public int AmountSleepingPlaces { get; set; }
    
    public Apartment(AddressPremises addressPremises, double area,double livingArea, double price, int amountRooms, int floor) : base(addressPremises, area, price, amountRooms, floor)
    {
      LivingArea = livingArea;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"This is an apartment with an living area of {LivingArea}. There " +
                        $"{AmountSleepingPlaces switch{0=>"are not sleeping places",1=>"is a sleeping place",_=>$"are {AmountSleepingPlaces} sleeping places"}}\n");
    }
  }
}