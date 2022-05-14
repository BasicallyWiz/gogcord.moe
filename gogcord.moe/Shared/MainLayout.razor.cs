using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using DiscordOAuth2Helper;
using System.Text.Json;
using System.IO;


using gogcord.moe.Data;
namespace gogcord.moe.Shared
{
  public partial class MainLayout
  {
    [Inject]
    IJSRuntime JS { get; set; }

    User activeUser = new User("", "Not logged in", "", null, "", 0);

    private bool UserCardExpanded = false;

    private string? UserCardHidden => !UserCardExpanded ? "card-hidden" : null;
#if DEBUG
    private string? DebugOutput { get; set; }
#endif
    private void ToggleUserCard() { UserCardExpanded = !UserCardExpanded; }
    private void HideUserCard() { UserCardExpanded = false; }



    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      try
      {
        OAuth2Helper Helper = new(DiscordApplicationData.Id, File.ReadAllText("discord.secret"));
      }
      catch (Exception ex) { DebugOutput = $"{DateTime.Now} {ex.Message}"; }
    }
  }
}
