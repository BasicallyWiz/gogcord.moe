namespace gogcord.moe.Shared.Discord
{
  public class GameInfo : IGameInfo
  {
    public string Name { get; }

    public GameInfo(string name)
    {
      Name = name;
    }
  }
}
