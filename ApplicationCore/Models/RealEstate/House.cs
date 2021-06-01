using System;

namespace ApplicationCore.Models.RealEstate
{
  public class House : RealEstate , ILivingQuarters
  {
    public TypeHouse TypeHouse { get; }
    public double LivingArea { get; set; }
    public int AmountSleepingPlaces { get; set; }
    public TypeHeating TypeHeating { get; set; }
    public int AmountFloors { get; }
    public House(Address address, double area,double livingArea, double price, TypeHouse typeHouse,int amountFloors) : base(address, area, price)
    {
      this.LivingArea = livingArea;
      this.TypeHouse = typeHouse;
      this.AmountFloors = amountFloors;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"This is a {TypeHouse switch{TypeHouse.Duplex=>"duplex ",TypeHouse.Townhouse=>"townhouse ",_=>string.Empty}}house.\n");
    }
  }
}