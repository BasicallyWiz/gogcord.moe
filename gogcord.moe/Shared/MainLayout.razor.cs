using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using gogcord.moe.Data.Discord;
using DiscordOAuth2Helper;


namespace gogcord.moe.Shared
{
  public partial class MainLayout
  {
    public bool IsLoggedIn = false;
    public string Username = "Not Logged in.";
    public string AvatarURL = "";

    public static DiscordUser? CurrentUser;

    private bool UserCardExpanded = false;

    private string? UserCardHidden => !UserCardExpanded ? "card-hidden" : null;

    private void ToggleUserCard() { UserCardExpanded = !UserCardExpanded; }
    private void HideUserCard() { UserCardExpanded = false; }

    async Task TestForTokenCookie(bool firstRender)
    {
      if (!firstRender) return;
      //  Get cookies
      string? accessCode = await GetCookie("discord_access_code");
      Console.WriteLine(accessCode);
      if (accessCode != null)
      {
        /*
        HttpClient client = new HttpClient();

        var form = new Dictionary<string, string>
        {
          { "client_id", "962874982663331870" },
          { "client_secret", "FjmPMQtAdgiMsfHalBLTNFyG7f06Q665" },
          { "grant_type", "authorization_code" },
          { "code", $"{accessCode}" },
          { "redirect_uri", NavManager.BaseUri + "Profile/" },
        };

        HttpResponseMessage response = await client.PostAsync("https://discord.com/api/v8/oauth2/token", new FormUrlEncodedContent(form));

        Console.WriteLine(await response.Content.ReadAsStringAsync());

        var content = await response.Content.ReadAsStringAsync();

        //  Remove unwanted characters
        content = content.Replace("{", "");
        content = content.Replace("}", "");
        content = content.Replace("\"", "");

        //  bind data 
        string access_token = String.Empty;

        foreach (string item in content.Split(","))
        {
          if (item.Trim().Split(":")[0].Trim() == "access_token")
          {
            access_token = item.Split(":")[1].Trim();
          }
        }
        */

        //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");

        //response = await client.GetAsync("https://discord.com/api/v8/oauth2/@me");

        //Console.WriteLine(await response.Content.ReadAsStringAsync());

        //DiscordThing thing = JsonSerializer.Deserialize<DiscordThing>(await response.Content.ReadAsStringAsync());

        //JS.InvokeVoidAsync("window.ClientProfile.setProfileDisplay");
      }
    }
  }
}
