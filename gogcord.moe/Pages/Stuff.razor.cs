using Microsoft.AspNetCore.Components;

using gogcord.moe.AdvancedUI;

namespace gogcord.moe.Pages
{
  public partial class Stuff
  {
    public List<CardItemData> Cards = new();

    public string? SetLinks()
    {
      Cards.Add(new CardItemData($"{NavManager.BaseUri}images/Bluemonkey.png", "Title", "Description", new List<string>() { NavManager.BaseUri }));

      return null;
    }
  }
}
