namespace ApplicationCore.Models.Services
{
  public class Photo
  {
    private int _id;
    
    public string Url { get; set; }

    public Photo(string url)
    {
      Url = url;
    }
  }
}