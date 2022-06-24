namespace gogcord.moe.Client.Data
{
  public class TechItemData : ITechItemData
  {
    public string LogoUrl { get; set; }
    public string ClickUrl { get; set; }
    public string Title { get; set; }
    public string Developer { get; set; }

    public TechItemData(string LogoUrl, string ClickUrl, string Title, string Developer)
    {
      this.LogoUrl = LogoUrl;
      this.ClickUrl = ClickUrl;
      this.Title = Title;
      this.Developer = Developer;
    }
  }
}
