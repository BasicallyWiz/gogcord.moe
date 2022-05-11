namespace gogcord.moe.Data
{
  public class DiscordOAuthData
  {
    public string Access_Token { get; set; }
    public string Refresh_Token { get; set; }
    public string Expires_In { get; set; }
    public string Scope { get; set; }
    public string Token_Type { get; set; }

    public DiscordOAuthData(string access_token, string refresh_token, string expires_in, string scope, string token_type)
    {
      this.Access_Token = access_token;
      this.Refresh_Token = refresh_token;
      this.Expires_In = expires_in;
      this.Scope = scope;
      this.Token_Type = token_type;
    }
  }
}
