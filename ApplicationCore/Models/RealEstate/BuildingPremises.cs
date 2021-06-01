using System;

namespace ApplicationCore.Models.RealEstate
{
  public abstract class BuildingPremises : RealEstate
  {
    private int _amountRooms;
    private int _floor;

    public TypeBalcony TypeBalcony { get; set; }

    public int AmountRooms
    {
      get => _amountRooms;
      set
      {
        if(value <= 0)
          throw new ArgumentNullException("Amount rooms cannot be less than or equal to zero.");
        _amountRooms = value;
      }
    }

    public int Floor
    {
      get => _floor;
      set
      {
        if(value <= 0)
          throw new ArgumentNullException("Floor cannot be less than zero.");
        _floor = value;
      }
    }


    public BuildingPremises(AddressPremises addressPremises, double area,double price,int amountRooms,int floor) : base(addressPremises,area,price)
    {
      this.AmountRooms = amountRooms;
      this.Floor = floor;
    }
  }
}