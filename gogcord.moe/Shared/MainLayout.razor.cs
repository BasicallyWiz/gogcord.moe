using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using DiscordOAuth2Helper;


namespace gogcord.moe.Shared
{
  public partial class MainLayout
  {
    User activeUser = new User("", "Not logged in", "", null, "", 0);

    private bool UserCardExpanded = false;

    private string? UserCardHidden => !UserCardExpanded ? "card-hidden" : null;

    private void ToggleUserCard() { UserCardExpanded = !UserCardExpanded; }
    private void HideUserCard() { UserCardExpanded = false; }

    [JSInvokable]
    public User GetCurrentUser() {
      return this.activeUser;
    }

    [JSInvokable]
    public void SetCurrentUser(User user)
    {
      this.activeUser = user;
    }
  }
}
