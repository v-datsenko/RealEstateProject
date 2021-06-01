using System;
using ApplicationCore.Models.Characters;

namespace ApplicationCore.Models.Services
{
  public class Comment : ICreatingDate
  {
    private int _id;
    
    public Person Author { get; }
    public string Content { get; set; }
    public DateTime CreatingDate { get; }

    public Comment(DateTime creatingDate, Person author, string content)
    {
      CreatingDate = creatingDate;
      Author = author;
      Content = content;
      CreatingDate = DateTime.Now;
    }


  }
}