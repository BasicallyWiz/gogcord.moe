using Microsoft.AspNetCore.Components;
using gogcord.moe.Shared.Discord;

namespace gogcord.moe.Client.Data.Discord
{
  public partial class DiscordChannel
  {
    [Parameter]
    public ChannelInfo ChannelInfo { get; set; }
  }
}
