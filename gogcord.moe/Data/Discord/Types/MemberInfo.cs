using System.Text.Json.Serialization;

namespace gogcord.moe.Data.Discord
{
  public class MemberInfo : IMemberInfo
  {
    public string Id { get; }
    public string Username { get; }
    public string Discriminator { get; }
    public object? Avatar { get; }
    public string Status { get; }
    public string Avatar_Url { get; }
    [JsonExtensionData]
    public Dictionary<string, object> ExtentionData { get; }

    public MemberInfo(string id, string username, string discriminator, object? avatar, string status, string avatar_url)
    {
      this.Id = id;
      this.Username = username;
      this.Discriminator = discriminator;
      this.Avatar = avatar;
      this.Status = status;
      this.Avatar_Url = avatar_url;
    }
  }
}
