using Microsoft.AspNetCore.Components;

using gogcord.moe.Data;
using gogcord.moe.Data.Discord;
namespace gogcord.moe.Pages
{
  public partial class Index
  {
    [Inject]
    NavigationManager NavManager { get; set; }

    public string? backGroundUri;
    public bool hasStateChangedOnce = false;

    GuildInfoLoader guildInfoLoader = new("601549765611749397");
    GuildInfo? guildInfo = null;

    public Index()
    {

    }

    public string CheckStateChanged()
    {
      if (hasStateChangedOnce != true)
      {
        hasStateChangedOnce = true;
        StateHasChanged();

        return "";
      }
      return "";
    }



    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (firstRender) {
        AssetLoader loader = new(NavManager);
        backGroundUri = loader.GetRandomBackground(await JS.InvokeAsync<bool>("WindowUtils.isDarkTheme", null)).AbsoluteUri;
      }

      guildInfo = await guildInfoLoader.GetGuildInfo();

      CheckStateChanged();
    }
  }
}
