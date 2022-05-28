using DiscordOAuth2Helper;
using gogcord.moe.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace gogcord.moe.Shared
{
  public partial class MainLayout
  {
    [Inject]
    IJSRuntime? JS { get; set; }

    User activeUser = new("", "Not logged in", "", null, "", 0);

    private bool UserCardExpanded = false;

    private string? UserCardHidden => !UserCardExpanded ? "card-hidden" : null;
    private void ToggleUserCard() { UserCardExpanded = !UserCardExpanded; _ = OnAfterRenderAsync(false); }
    private void HideUserCard() { UserCardExpanded = false; }

    readonly OAuth2Helper helper = new(DiscordApplicationData.Id, DiscordApplicationData.GetClientSecret());

    public async Task LogoutUser()
    {
      await JS.InvokeVoidAsync("ClientUser.clearUser");
      activeUser = new("", "Not logged in", "", null, "", 0);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (!NavManager.Uri.Contains("Profile/") && firstRender || NavManager.Uri.Contains("Profile") && !NavManager.Uri.Contains("code=") && firstRender)
      {
        //  Collect and compile token from client
        string clientTokenCallback = await JS.InvokeAsync<string>("ClientUser.getToken");

        if (clientTokenCallback == null) return;
        if (clientTokenCallback == "") return;

        string[] clientTokenItems = clientTokenCallback.Split(", ");
        CallbackToken token = new(clientTokenItems[0], int.Parse(clientTokenItems[1]), clientTokenItems[2], clientTokenItems[3], clientTokenItems[4]);

        //  Using Old Token
        await helper.SetBearerHeader(token);
        CallbackUser? user = await helper.GetCurrentUser();
        if (user.User == null) return;

        activeUser = user.User;

        if (user.User != null) await JS.InvokeVoidAsync("ClientUser.setUser", user);
      }


      if (activeUser.Username == "Not logged in")
      {
        string clientUserCallback = await JS.InvokeAsync<string>("ClientUser.getUser");
        if (clientUserCallback == null) return;
        if (clientUserCallback == "") return;

        string[] obj = clientUserCallback.Split(", ");

        activeUser = new(obj[0], obj[1], obj[2], null, "", 000);
      }
    }
  }
}
