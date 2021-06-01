using System;
using System.Collections.Generic;
using ApplicationCore.Models.Characters;

namespace ApplicationCore.Models.Services
{
  public class Advertisement : ICreatingDate
  {
    private int _id;
    
    public string Title { get; set; }
    public Customer Author { get; }
    public DateTime CreatingDate { get; }
    public List<Photo> Photos { get; set; }
    public RealEstate.RealEstate RealEstate { get; }
    public string Description { get; set; }
    public List<Comment> Comments { get; set; }

    public Advertisement(string title, Customer author, RealEstate.RealEstate realEstate)
    {
      Title = title;
      Author = author;
      RealEstate = realEstate;
      Photos = new List<Photo>();
      Comments = new List<Comment>();
    }
  }
}