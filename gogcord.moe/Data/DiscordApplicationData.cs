using System.IO;

namespace gogcord.moe.Data
{
  public static class DiscordApplicationData
  {
    public static string Id { get; } = "962874982663331870";

    public static string GetClientSecret()
    {
      return File.ReadAllText("./discord.secret");
    }
  }
}
