﻿using System.Text.Json.Serialization;

namespace gogcord.moe.Data.Discord
{
  public class MemberInfo : IMemberInfo
  {
    [JsonPropertyName("id")]
    public string Id { get; }
    [JsonPropertyName("username")]
    public string Username { get; }
    [JsonPropertyName("discriminator")]
    public string Discriminator { get; }
    [JsonPropertyName("avatar")]
    public object? Avatar { get; }
    [JsonPropertyName("status")]
    public string Status { get; }
    [JsonPropertyName("avatar_url")]
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
