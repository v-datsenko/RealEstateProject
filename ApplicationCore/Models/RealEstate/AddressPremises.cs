namespace ApplicationCore.Models.RealEstate
{
  public class AddressPremises : Address
  {
    public string NumberPremises { get; }
    public AddressPremises(string city, string street, string number, string numberPremises) : base(city, street, number)
    {
      this.NumberPremises = numberPremises;
    }
  }
}