using Microsoft.AspNetCore.Components;

using gogcord.moe.Data.Discord;
namespace gogcord.moe.Shared
{
  public partial class DiscordMember
  {
    [Parameter]
    public MemberInfo memberInfo { get; set; }

    string? GetStatusColorClass(string userActivity)
    {
      switch(userActivity)
      {
        default: return null;
        case "online": return "status-online";
        case "idle": return "status-idle";
        case "dnd": return "status-dnd";
      }
    }
  }
}
