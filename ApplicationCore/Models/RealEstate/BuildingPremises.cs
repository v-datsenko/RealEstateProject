using System;

namespace ApplicationCore.Models.RealEstate
{
  public abstract class BuildingPremises : RealEstate, IRoomCounter, IBuildingPremise
  {
    private int _amountRooms;
    private int _numberfloor;

    public TypeBalcony TypeBalcony { get; set; }

    public int AmountRooms
    {
      get => _amountRooms;
      set
      {
        if(value <= 0)
          throw new ArgumentException("Amount rooms cannot be less than or equal to zero.");
        _amountRooms = value;
      }
    }

    public int NumberFloor
    {
      get => _numberfloor;
      set
      {
        if(value <= -1)
          throw new ArgumentException("Floor cannot be less than zero.");
        _numberfloor = value;
      }
    }

    public BuildingPremises(AddressPremises addressPremises, double area,double price,int amountRooms,int floor) : base(addressPremises,area,price)
    {
      AmountRooms = amountRooms;
      NumberFloor = floor;
    }
  }
}