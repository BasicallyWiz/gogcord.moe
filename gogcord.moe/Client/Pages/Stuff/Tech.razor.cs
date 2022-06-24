using gogcord.moe.Client.Data;

namespace gogcord.moe.Client
{
  public partial class Tech
  {
    List<TechItemData>? Items;

    protected async override Task OnInitializedAsync()
    {
      Items = new()
      {
        new TechItemData($"{NavManager.BaseUri}images/icons/c-sharp.svg", "https://docs.microsoft.com/en-us/dotnet/csharp/", "DotNet C#", "Microsoft"),
        new TechItemData($"{NavManager.BaseUri}images/icons/Blazor.svg", "https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor", "ASPNet Core Blazor", "Microsoft"),
        new TechItemData($"{NavManager.BaseUri}images/icons/visual-studio-2022.svg", "https://visualstudio.microsoft.com/vs/", "Visual Studio 2022", "Microsoft"),
        new TechItemData($"{NavManager.BaseUri}images/icons/discord.svg", "https://discord.com/developers/docs/topics/oauth2", "OAuth2 Login", "Discord")
      };
    } 
  }
}
