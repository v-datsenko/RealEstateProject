namespace ApplicationCore.Models.Services
{
  public class Photo
  {
    private int _id;
    
    public string url { get; set; }

    public Photo(string url)
    {
      this.url = url;
    }
  }
}