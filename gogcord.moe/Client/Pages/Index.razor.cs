using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

using gogcord.moe.Client.Data.Discord;
using gogcord.moe.Shared.Discord;
using gogcord.moe.Client.Data.Loaders;

namespace gogcord.moe.Client.Pages
{
  public partial class Index
  {

    public string? backGroundUri;
    public bool hasStateChangedOnce = false;

    GuildInfo? guildInfo = null;

    protected async override Task OnInitializedAsync()
    {


      guildInfo = await Http.GetFromJsonAsync<GuildInfo>("api/GuildInfo");
    }
  }
}

//  TODO: Port Gogcord.moe to WebAssembly for better performance.