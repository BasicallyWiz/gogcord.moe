using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using DiscordOAuth2Helper;
using System.Text.Json;
using System.IO;


using gogcord.moe.Data;
namespace gogcord.moe.Shared
{
  public partial class MainLayout
  {
    [Inject]
    IJSRuntime JS { get; set; }

    User activeUser = new("", "Not logged in", "", null, "", 0);

    private bool UserCardExpanded = false;

    private string? UserCardHidden => !UserCardExpanded ? "card-hidden" : null;
#if DEBUG
    private string? DebugOutput { get; set; }
#endif
    private void ToggleUserCard() { UserCardExpanded = !UserCardExpanded; }
    private void HideUserCard() { UserCardExpanded = false; }

    readonly OAuth2Helper helper = new(DiscordApplicationData.Id, DiscordApplicationData.GetClientSecret());

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (!NavManager.Uri.Contains("Profile/") && firstRender || NavManager.Uri.Contains("Profile") && !NavManager.Uri.Contains("code=") && firstRender)
      {
        string clientTokenCallback = await JS.InvokeAsync<string>("ClientUser.getToken");

        if (clientTokenCallback == null) return;

        string[] clientTokenItems = clientTokenCallback.Split(", ");
        CallbackToken token = new(clientTokenItems[0], int.Parse(clientTokenItems[1]), clientTokenItems[2], clientTokenItems[3], clientTokenItems[4]);


        //  Old Token

        await helper.SetBearerHeader(token);
        CallbackUser user = await helper.GetCurrentUser();

        Console.WriteLine("- - Using OLD token: " + user.User.Username);

        // New token
        if (user == null)
        {
          token = (CallbackToken) await helper.GetRefreshedToken(token);
          await helper.SetBearerHeader(token);

          await JS.InvokeVoidAsync("ClientUser.setToken", token);

          user = await helper.GetCurrentUser();
          Console.WriteLine("- - Using NEW token: " + user.User.Username);
        }

        await JS.InvokeVoidAsync("ClientUser.setUser", user);
        //  TODO: If first GetCurrentUser attempt fails, Try again with refresh token. If that fails, a manual sign-in may be required.
      }
    }
  }
}
