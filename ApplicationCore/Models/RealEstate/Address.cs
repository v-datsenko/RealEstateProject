namespace ApplicationCore.Models.RealEstate
{
  public class Address
  {
    public string City { get; }
    public string Street { get; }
    public string Number { get; }

    public Address(string city, string street, string number)
    {
      this.City = city;
      this.Street = street;
      this.Number = number;
    }
  }
}