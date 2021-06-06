using System;

namespace ApplicationCore.Models.RealEstate
{
  public class House : RealEstate , ILivingQuarters, IRoomCounter
  {
    private int _amountRooms;

    public TypeHouse TypeHouse { get; }
    public double LivingArea { get; set; }
    public int AmountSleepingPlaces { get; set; }
    public TypeHeating TypeHeating { get; set; }
    public int AmountFloors { get; }
    public int AmountRooms
    {
      get => _amountRooms;
      set
      {
        if (value <= 0)
         throw new ArgumentException("Amount rooms cannot be less than or equal to zero.");
         _amountRooms = value;
      }
    }

    public House(Address address, double area,double livingArea, double price, TypeHouse typeHouse,int amountFloors) : base(address, area, price)
    {
      LivingArea = livingArea;
      TypeHouse = typeHouse;
      AmountFloors = amountFloors;
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"This is a {TypeHouse switch{TypeHouse.Duplex=>"duplex ",TypeHouse.Townhouse=>"townhouse ",_=>string.Empty}}house.\n");
    }
  }
}