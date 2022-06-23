using gogcord.moe.Client.Data;
using gogcord.moe.Client.Shared;

using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using DiscordOAuth2Helper;

namespace gogcord.moe.Client
{
  public partial class Profile
  {
    [Inject]
    NavigationManager? NavManager { get; set; }

    [Inject]
    IJSRuntime? JS { get; set; }
    [Inject]
    HttpClient? Http { get; set; }

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

    //  INFO: CORS BLOCKS SIGNIN FROM CLIENT; SIGN IN ON SERVER
    //  Also it's a security thing
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (firstRender && GetCodeFromUri() != await JS.InvokeAsync<string>("ClientUser.getOldAuth", null) || GetCodeFromUri() != null)
      {
        //  Get and populate access token
        HttpResponseMessage resp = await Http.PostAsync($"api/DiscordUser/Token?value={GetCodeFromUri()}&baseUrl={NavManager.BaseUri}", null);

        await JS.InvokeVoidAsync("ClientUser.setToken", JsonSerializer.Deserialize<CallbackToken>(await resp.Content.ReadAsStringAsync()));


        //  Get and populate user data
        resp = await Http.PostAsync($"api/DiscordUser/CurrentUser?tokenString={await resp.Content.ReadAsStringAsync()}", null);
        await JS.InvokeVoidAsync( "ClientUser.setUser", JsonSerializer.Deserialize<CallbackUser>(await resp.Content.ReadAsStringAsync()));
      }
    }
  }
}
//  TODO: MOVE ALL PROFILE COMPUTATION TO SERVER, VIA API