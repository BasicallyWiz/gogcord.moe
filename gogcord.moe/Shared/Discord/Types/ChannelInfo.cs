using System.Text.Json.Serialization;

namespace gogcord.moe.Shared.Discord
{
  public class ChannelInfo : IChannelInfo
  {
    [JsonPropertyName("id")]
    public string Id { get; }
    [JsonPropertyName("name")]
    public string Name { get; }
    [JsonPropertyName("position")]
    public int Position { get; }

    public ChannelInfo(string id, string name, int position)
    {
      Id = id;
      Name = name;
      Position = position;
    }
  }
}
