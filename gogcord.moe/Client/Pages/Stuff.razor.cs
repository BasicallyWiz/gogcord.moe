using Microsoft.AspNetCore.Components;

using gogcord.moe.Client.AdvancedUI;

namespace gogcord.moe.Client
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
