using System;

namespace ApplicationCore.Models.RealEstate
{
  public class Ground : RealEstate
  {
    public Ground(Address address, double area, double price) : base(address, area, price)
    {
    }

    public override void DisplayInfo()
    {
      base.DisplayInfo();
      Console.WriteLine($"This is a ground with an area of {Area} square metres.\n");
    }
  }
}