namespace gogcord.moe.Client.AdvancedUI
{
  public class CardItemData : ICardItemData
  {
    public string Thumbnail { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public List<string> Links { get; private set; }

        public CardItemData(string Thumbnail, string Title, string Desciption, List<string> Links)
    {
      this.Thumbnail = Thumbnail;
      this.Title = Title;
      this.Description = Desciption;
      this.Links = Links;
    }
  }
}
