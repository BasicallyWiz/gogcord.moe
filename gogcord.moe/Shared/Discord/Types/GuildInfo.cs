using System.Text.Json.Serialization;

namespace gogcord.moe.Shared.Discord
{
  public class GuildInfo : IGuildInfo
  {
    [JsonPropertyName("id")]
    public string Id { get; private set; }
    [JsonPropertyName("name")]
    public string Name { get; private set; }
    [JsonPropertyName("instant_invite")]
    public string Instant_Invite { get; private set; }
    [JsonPropertyName("channels")]
    public ChannelInfo[] Channels { get; private set; }
    [JsonPropertyName("members")]
    public MemberInfo[] Members { get; private set; }
    [JsonPropertyName("presence_count")]
    public int Presence_Count { get; private set; }

    public GuildInfo(string id, string name, string instant_invite, ChannelInfo[] channels, MemberInfo[] members, int presence_count)
    {
      Id = id;
      Name = name;
      Instant_Invite = instant_invite;
      Channels = channels;
      Members = members;
      Presence_Count = presence_count;
    }
  }
}
