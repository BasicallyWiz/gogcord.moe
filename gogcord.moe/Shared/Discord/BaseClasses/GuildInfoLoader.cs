using System.Text.Json;
namespace gogcord.moe.Shared.Discord
{
  public class GuildInfoLoader
  {
    public HttpClient Client { get; }
    public string GuildId { get; }

    public GuildInfoLoader(string guildId)
    {
      GuildId = guildId;

      Client = new();
    }

    public async Task<GuildInfo> GetGuildInfo()
    {
      HttpResponseMessage response = await Client.GetAsync($"https://discord.com/api/guilds/{GuildId}/widget.json");
      return JsonSerializer.Deserialize<GuildInfo>(await response.Content.ReadAsStringAsync());

    }
  }
}
