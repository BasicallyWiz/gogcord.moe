namespace gogcord.moe.Data.Discord
{
  public class DiscordThing
  {
    public DiscordApplication application { get; }

    public string[] scopes { get; }
    public string expires { get; }

    public DiscordUser user { get; }

    public DiscordThing(DiscordApplication application, string[] scopes, string expires, DiscordUser user)
    {
      this.application = application;
      this.scopes = scopes;
      this.expires = expires;
      this.user = user;
    }
  }
}
