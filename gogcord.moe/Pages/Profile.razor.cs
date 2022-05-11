﻿using gogcord.moe.Data;
using gogcord.moe.Shared;

using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using DiscordOAuth2Helper;

namespace gogcord.moe.Pages
{
  public partial class Profile
  {

    string? textStuff;


    [Inject]
    NavigationManager NavManager { get; set; }

    [Inject]
    IJSRuntime JS { get; set; }


    string? GetCodeFromUri()
    {
      string[] baseRemovedUri = NavManager.Uri.Split("?");
      if (baseRemovedUri.Count() <= 1) return null;

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
        
        //JS.InvokeVoidAsync("window.ClientProfile.setClientProfile", thing.user, GetCodeFromUri());
        
        OAuth2Helper Helper = new("962874982663331870", "FjmPMQtAdgiMsfHalBLTNFyG7f06Q665");

        CallbackToken token = await Helper.GetAccessToken(GrantType.AuthorizationCode, GetCodeFromUri(), NavManager.BaseUri + "Profile/") as CallbackToken;
        await Helper.SetBearerHeader(token);

        CallbackUser callbackUser = await Helper.GetCurrentUser();

        JS.InvokeVoidAsync("ClientUser.setUser", callbackUser.User);
      }
    }
  }
}