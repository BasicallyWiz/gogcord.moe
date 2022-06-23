using System.IO;

namespace gogcord.moe.Shared.Discord
{
  public static class DiscordApplicationData
  {
    public static string Id { get; } = "962874982663331870";

    public static string GetClientSecret()
    {
      if (File.Exists("discord.secret")) return File.ReadAllText("discord.secret");
      else return Directory.GetCurrentDirectory() + "/discord.secret does not exist";
    }
  }
}