﻿using gogcord.moe.Data;
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
      if (GetCodeFromUri() != null && GetCodeFromUri() != await JS.InvokeAsync<string>("ClientUser.getOldAuth"))
      {
        OAuth2Helper Helper = new(DiscordApplicationData.Id, DiscordApplicationData.GetClientSecret());

        CallbackToken token = await Helper.GetAccessToken(GetCodeFromUri(), NavManager.BaseUri + "Profile/") as CallbackToken;
        await Helper.SetBearerHeader(token);

        CallbackUser callbackUser = (CallbackUser)await Helper.GetCurrentUser();

        await JS.InvokeVoidAsync("ClientUser.setUser", callbackUser);
        await JS.InvokeVoidAsync("ClientUser.setToken", token);
        await JS.InvokeVoidAsync("ClientUser.storeOldAuth", GetCodeFromUri());
      }
      else if (GetCodeFromUri() != null && GetCodeFromUri() == await JS.InvokeAsync<string>("ClientUser.getOldAuth"))
      {
          string clientTokenCallback = await JS.InvokeAsync<string>("ClientUser.getToken");

          if (clientTokenCallback == null) return;

          string[] clientTokenItems = clientTokenCallback.Split(", ");
          CallbackToken token = new(clientTokenItems[0], int.Parse(clientTokenItems[1]), clientTokenItems[2], clientTokenItems[3], clientTokenItems[4]);

          OAuth2Helper Helper = new(DiscordApplicationData.Id, DiscordApplicationData.GetClientSecret());

          //  Old Token
          await Helper.SetBearerHeader(token);
          CallbackUser user = await Helper.GetCurrentUser();

          Console.WriteLine("- - Using OLD token: " + user.User.Username);

          // New token
          if (user == null)
          {
            token = (CallbackToken)await Helper.GetRefreshedToken(token);
            await Helper.SetBearerHeader(token);

            await JS.InvokeVoidAsync("ClientUser.setToken", token);

            user = await Helper.GetCurrentUser();
            Console.WriteLine("- - Using NEW token: " + user.User.Username);
          }

          await JS.InvokeVoidAsync("ClientUser.setUser", user);
        }
      }
    }
  }