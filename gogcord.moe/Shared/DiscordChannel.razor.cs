using Microsoft.AspNetCore.Components;

using gogcord.moe.Data.Discord;
namespace gogcord.moe.Shared
{
  public partial class DiscordChannel
  {
    [Parameter]
    public ChannelInfo ChannelInfo { get; set; }
  }
}
