namespace gogcord.moe.AdvancedUI
{
  public interface ICardItemData
  {
    public string Thumbnail { get; }
    public string Title { get; }
    public string Description { get; }
    public List<string> Links { get; }

  }
}
