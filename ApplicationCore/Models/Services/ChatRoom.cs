using System;
using System.Collections.Generic;
using ApplicationCore.Models.Characters;

namespace ApplicationCore.Models.Services
{
  public class ChatRoom : ICreatingDate
  {
    private int _id;
    
    public Advertisement Advertisement { get; }
    public List<Person> People { get; set; }
    public List<Message> Messages { get; }
    public DateTime CreatingDate { get; }

    public ChatRoom(Advertisement advertisement, List<Person> people)
    {
      Advertisement = advertisement;
      People = people;
      Messages = new List<Message>();
      CreatingDate = DateTime.Now;
    }


  }
}