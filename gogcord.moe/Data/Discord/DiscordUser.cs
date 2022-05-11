using System.Text.Json;
using System.Text.Json.Serialization;

namespace gogcord.moe.Data.Discord
{
  public class DiscordUser
  {
    public string id { get; }
    public string username { get; }
    public string avatar { get; }
    public string? avatar_decoration { get; }
    public string discriminator { get; }
    public int public_flags { get; }

    public DiscordUser(string id, string username, string avatar, string? avatar_decoration, string discriminator, int public_flags)
    {
      this.id = id;
      this.username = username;
      this.avatar = avatar;
      this.avatar_decoration = avatar_decoration;
      this.discriminator = discriminator;
      this.public_flags = public_flags;
    }

    //public string GetAvatarUrl()
    //{
    //  return $"https://cdn.discordapp.com/avatars/{id}/{avatar}";
    //}
  }
}
