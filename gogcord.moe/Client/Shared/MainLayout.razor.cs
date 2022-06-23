using DiscordOAuth2Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

using gogcord.moe.Shared.Discord;
using gogcord.moe.Client.Data;
namespace gogcord.moe.Client
{
  public partial class MainLayout
  {
    [Inject]
    IJSRuntime? JS { get; set; }

    [Inject]
    HttpClient Http { get; set; }

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
      StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
      try {
        //  Try to log in
        if (!NavManager.Uri.Contains("/Profile") && activeUser.Username == "Not logged in" && await JS.InvokeAsync<string>("ClientUser.getToken", null) != null)
        {
          HttpResponseMessage resp = await Http.PostAsync($"api/DiscordUser/CurrentUser?tokenString={await JS.InvokeAsync<string>("ClientUser.getToken", null)}", null);
          CallbackUser user = JsonSerializer.Deserialize<CallbackUser>(await resp.Content.ReadAsStringAsync());
          activeUser = user.User;

          JS.InvokeVoidAsync("ClientUser.setUser", user);
        }
      }
      catch(Exception e)
      {
        Console.WriteLine($"There was an error with signin.\n{e}");
      }
    }
  }
}
