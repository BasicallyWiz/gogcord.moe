using Microsoft.AspNetCore.Components;
using gogcord.moe.Shared.Discord;

namespace gogcord.moe.Client.Data.Discord
{
  public partial class DiscordMember
  {
    [Parameter]
    public MemberInfo memberInfo { get; set; }

    string? GetStatusColorClass(string userActivity)
    {
      switch (userActivity)
      {
        default: return null;
        case "online": return "status-online";
        case "idle": return "status-idle";
        case "dnd": return "status-dnd";
      }
    }
  }
}