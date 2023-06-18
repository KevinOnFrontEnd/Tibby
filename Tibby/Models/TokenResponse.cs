namespace Tibby.Models
{
  public class TokenResponse
  {
    public string Asset_id { get; set; }
    public string pair_id { get; set; }
    public string name { get; set; }
    public string short_name { get; set; }
    public bool verified { get; set; }
    public string image_url { get; set; }
  }
}