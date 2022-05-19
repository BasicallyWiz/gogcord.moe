using System.Text.Json;

namespace DiscordOAuth2Helper
{
  public class OAuth2Helper
  {
    public HttpClient Client { get; set; }

    public string ClientId { get; private set; }
    public string ClientSecret { get; private set; }

    public OAuth2Helper(string ClientId, string ClientSecret)
    {
      this.Client = new HttpClient();

      this.ClientId = ClientId;
      this.ClientSecret = ClientSecret;
    }

    //  Modify client
    public Task SetBearerHeader(CallbackToken callbackToken)
    {
      if (!Client.DefaultRequestHeaders.Contains("Authorization"))
      {
        Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {callbackToken.Access_Token}");
      }
      else
      {
        Client.DefaultRequestHeaders.Remove("Authorization");
        Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {callbackToken.Access_Token}");
      }
      return Task.CompletedTask;
    }

    // Wield Client
    /// <summary>
    /// Uses GET to request an access token for further access of an API.
    /// </summary>
    /// <param name="AuthorizationCode">
    ///   The actual code to be sent.
    ///   <para>
    ///     You should have collected this earlier. This code should be impossible to get, unless your user has previously provided it.
    ///   </para>
    /// </param>
    /// <param name="RedirectUri">
    ///   The RedirectURI for your OAuth.
    ///   <para>
    ///     In your app settings, this should be set to somewhere in your site.
    ///   </para>
    ///   <para>
    ///     If your user doesn't authenticate on a page that matches both a RedirectURI in your app settings AND the expected URI in this call, the OAuth2 flow will fail.
    ///   </para>
    /// </param>
    /// <returns>An <see cref="ICallbackToken"/> Populated with the access token and other required objects</returns>
    public async Task<ICallbackToken> GetAccessToken(string AuthorizationCode, string RedirectUri)
    {
      var form = new Dictionary<string, string>
        {
          { "client_id", ClientId },
          { "client_secret", ClientSecret },
          { "grant_type", GrantType.AuthorizationCode },
          { "code", AuthorizationCode },
          { "redirect_uri", RedirectUri },
        };

      HttpResponseMessage response = await Client.PostAsync("https://discord.com/api/v8/oauth2/token", new FormUrlEncodedContent(form));

      return JsonSerializer.Deserialize<CallbackToken>(await response.Content.ReadAsStringAsync());
    }
    /// <summary>
    /// Uses POST to post a refresh token in attempt to recieve a new token, in the case the old token expires.
    /// </summary>
    /// <param name="RefreshToken">
    ///   The actual code to be sent.
    ///   <para>
    ///     You should have collected this earlier. This code should be impossible to get, unless your user has previously provided it.
    ///   </para>
    /// </param>
    /// <param name="RedirectUri">
    ///   The RedirectURI for your OAuth.
    ///   <para>
    ///     In your app settings, this should be set to somewhere in your site.
    ///   </para>
    ///   <para>
    ///     If your user doesn't authenticate on a page that matches both a RedirectURI in your app settings AND the expected URI in this call, the OAuth2 flow will fail.
    ///   </para>
    /// </param>
    /// <returns>An <see cref="ICallbackToken"/> Populated with the access token and other required objects</returns>
    public async Task<ICallbackToken> GetRefreshedToken(CallbackToken token)
    {
      var form = new Dictionary<string, string>
        {
          { "client_id", ClientId },
          { "client_secret", ClientSecret },
          { "grant_type", GrantType.RefreshToken },
          { "refresh_token", token.Refresh_Token },
        };

      HttpResponseMessage response = await Client.PostAsync("https://discord.com/api/v8/oauth2/token", new FormUrlEncodedContent(form));

      Console.WriteLine(await response.Content.ReadAsStringAsync());

      return JsonSerializer.Deserialize<CallbackToken>(await response.Content.ReadAsStringAsync());
    }
    public async Task<CallbackUser>? GetCurrentUser()
    {
      HttpResponseMessage response = await Client.GetAsync("https://discord.com/api/v8/oauth2/@me");

      //Console.WriteLine(await response.Content.ReadAsStringAsync());

      return JsonSerializer.Deserialize<CallbackUser>(await response.Content.ReadAsStringAsync());
    }
  }
}