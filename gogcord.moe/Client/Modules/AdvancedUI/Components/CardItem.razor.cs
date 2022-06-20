using Microsoft.JSInterop;

using Microsoft.AspNetCore.Components;

namespace gogcord.moe.Client.AdvancedUI
{
    public partial class CardItem
  {
    [Parameter]
    public CardItemData CardData { get; set; }

    [Parameter]
    public XboxLikeCardGridSystem MotherGrid { get; set; }
  }
}
