using gogcord.moe.Data;
using gogcord.moe.Shared;

using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using DiscordOAuth2Helper;

namespace gogcord.moe.Pages
{
  public partial class Profile
  {
    [Inject]
    NavigationManager NavManager { get; set; }

    [Inject] 
    IJSRuntime JS { get; set; }


    string? GetCodeFromUri()
    {
      string[] baseRemovedUri = NavManager.Uri.Split("?");
      if (baseRemovedUri.Length <= 1) return null;

      foreach (string urlParam in baseRemovedUri[1].Split(";"))
      {
        if (urlParam.Trim().Split("=")[0] == "code")
        {
          return urlParam.Trim().Split("=")[1];
        }
      }
      return null;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (GetCodeFromUri() != null)
      {
        OAuth2Helper Helper = new(DiscordApplicationData.Id, DiscordApplicationData.GetClientSecret());

        CallbackToken token = await Helper.GetAccessToken(GrantType.AuthorizationCode, GetCodeFromUri(), NavManager.BaseUri + "Profile/") as CallbackToken;
        await OAuth2Helper.SetBearerHeader(token);

        CallbackUser callbackUser = (CallbackUser)await Helper.GetCurrentUser();

        await JS.InvokeVoidAsync("ClientUser.setUser", callbackUser);
        await JS.InvokeVoidAsync("ClientUser.setToken", token);
      }
    }
  }
}
