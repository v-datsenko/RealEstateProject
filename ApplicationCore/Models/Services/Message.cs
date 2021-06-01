using System;
using ApplicationCore.Models.Characters;

namespace ApplicationCore.Models.Services
{
  public class Message : ICreatingDate
  {
    private int _id;
    
    public Person Author { get; }
    public string Content { get; set; }
    public DateTime CreatingDate { get; }

    public Message(Person author, string content)
    {
      Author = author;
      Content = content;
      CreatingDate = DateTime.Now;
    }


  }
}