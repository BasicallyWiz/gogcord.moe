using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DiscordOAuth2Helper
{
  public class User : IUser
  {
    [JsonPropertyName("id")]
    public string Id { get; }
    [JsonPropertyName("username")]
    public string Username { get; }
    [JsonPropertyName("avatar")]
    public string Avatar { get; }
    [JsonPropertyName("avatar_decoration")]
    public string? Avatar_Decoration { get; }
    [JsonPropertyName("discriminator")]
    public string Discriminator { get; }
    [JsonPropertyName("public_flags")]
    public int Public_Flags { get; }

    public User(string id, string username, string avatar, string? avatar_decoration, string discriminator, int public_flags)
    {
      this.Id = id;
      this.Username = username;
      this.Avatar = avatar;
      this.Avatar_Decoration = avatar_decoration;
      this.Discriminator = discriminator;
      this.Public_Flags = public_flags;
    }
  }
}
