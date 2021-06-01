using System;

namespace ApplicationCore.Models.RealEstate
{
  public abstract class RealEstate
  {
    private readonly int _id;
    private double _priceInMonth;
    
    public Address Address { get; }
    public double Area { get; }
    public double PriceInMonth
    {
      get => _priceInMonth;
      set
      {
        if(value <= 0)
          throw new ArgumentNullException("Price cannot be less than or equal to zero.");
        _priceInMonth = value;
      }
    }

    public RealEstate(Address address, double area,double price)
    {
      this.Area = area;
      this.Address = address;
      this.PriceInMonth = price;
    }

    public virtual void DisplayInfo()
    {
      Console.WriteLine($"This object is located at {Address.City}, {Address.Street}, {Address.Number}.");
    }
  }
}