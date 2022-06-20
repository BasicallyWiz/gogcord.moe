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
      try
      {
        guildInfo = await Http.GetFromJsonAsync<GuildInfo>("api/GuildInfo");
      } catch (Exception err) { Console.WriteLine(err); }

      Random random = new();
      if (await JS.InvokeAsync<bool>("WindowUtils.isDarkTheme", null))
      {
        string[] backgrounds = new string[] 
        { 
          "ape.jpg" ,
          "gog-master-wallpaper.png",
          "tufted-capuchin.jfif",
          "tufted-capuchin-sees.jfif"
        };

        backGroundUri = $"{NavManager.BaseUri}images/backgrounds/dark/{backgrounds[random.Next(backgrounds.Length)]}";
      }
      else
      {
        string[] backgrounds = new string[]
        {
          "tufted-capuchin-close.webp",
          "Vervet_Monkey_Gorongosa_National_Park.jpg"
        };

        backGroundUri = $"{NavManager.BaseUri}images/backgrounds/light/{backgrounds[random.Next(backgrounds.Length)]}";
      }
    }
  }
}

//  TODO: Port Gogcord.moe to WebAssembly for better performance.