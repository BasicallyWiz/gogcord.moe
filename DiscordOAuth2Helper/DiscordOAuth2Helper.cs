using System.Text.Json;

namespace DiscordOAuth2Helper
{
  public class OAuth2Helper
  {
    static HttpClient Client { get; set; }

    public string ClientId { get; private set; }
    public string ClientSecret { get; private set; }

    public OAuth2Helper(string ClientId, string ClientSecret)
    {
      Client = new HttpClient();

      this.ClientId = ClientId;
      this.ClientSecret = ClientSecret;
    }

    //  Modify client
    public static Task SetBearerHeader(CallbackToken callbackToken)
    {
      Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {callbackToken.Access_Token}");

      return Task.CompletedTask;
    }

    //  Test client
    public bool DoesClientExist()
    {
      if (ClientId != null) return true;
      else return false;
    }

    //  Use client
    public async Task<ICallbackToken> GetAccessToken(string GrantType, string AuthorizationCode, string RedirectUri)
    {
      var form = new Dictionary<string, string>
        {
          { "client_id", ClientId },
          { "client_secret", ClientSecret },
          { "grant_type", GrantType },
          { "code", AuthorizationCode },
          { "redirect_uri", RedirectUri },
        };

      HttpResponseMessage response = await Client.PostAsync("https://discord.com/api/v8/oauth2/token", new FormUrlEncodedContent(form));

      return JsonSerializer.Deserialize<CallbackToken>(await response.Content.ReadAsStringAsync());
    }
    public async Task<ICallbackUser> GetCurrentUser()
    {
      return JsonSerializer.Deserialize<CallbackUser>(await Client.GetStringAsync("https://discord.com/api/v8/oauth2/@me"));
    }
  }
}