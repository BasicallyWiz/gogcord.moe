namespace gogcord.moe.Data.Discord
{
  public class ChannelInfo : IChannelInfo
  {
    public string Id { get; }
    public string Name { get; }
    public int Position { get; }

    public ChannelInfo(string id, string name, int position)
    {
      this.Id = id;
      this.Name = name;
      this.Position = position;
    }
  }
}
