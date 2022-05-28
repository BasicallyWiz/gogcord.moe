namespace gogcord.moe.Data.Discord
{
  public class GameInfo : IGameInfo
  {
    public string Name { get; }

    public GameInfo(string name)
    {
      this.Name = name;
    }
  }
}
