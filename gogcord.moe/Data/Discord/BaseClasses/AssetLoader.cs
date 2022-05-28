using System.IO;
using Microsoft.AspNetCore.Components;

namespace gogcord.moe.Data
{
  public  class AssetLoader
  {
    NavigationManager NavManager { get; }
    public AssetLoader(NavigationManager NavManager)
    {
      this.NavManager = NavManager;
    }

    public  List<Uri> GetAllSiteBackgrounds()
    {
      List<Uri> siteBackgrounds = new();
      
      foreach (string dir in Directory.EnumerateFileSystemEntries("wwwroot/images/backgrounds/dark/"))
      {
        siteBackgrounds.Add(new Uri(NavManager.BaseUri + dir));
      }

      foreach (string dir in Directory.EnumerateFileSystemEntries("wwwroot/images/backgrounds/dark/"))
      {
        siteBackgrounds.Add(new Uri(NavManager.BaseUri + dir));
      }
      
      return siteBackgrounds;
    }
    public  List<Uri> GetAllSiteBackgrounds(bool IsDarkMode)
    {
      List<Uri> siteBackgrounds = new();

      string bgDir = "images/backgrounds/";
      if (IsDarkMode == true) bgDir += "dark/";
      else bgDir += "light/";

      foreach (string dir in Directory.EnumerateFileSystemEntries("wwwroot/"+ bgDir))
      {
        siteBackgrounds.Add(new Uri(NavManager.BaseUri + dir.Replace("wwwroot/", "")));
      }

      return siteBackgrounds;
    }

    public Uri GetRandomBackground(bool IsDarkMode)
    {
      List<Uri> siteBGs = GetAllSiteBackgrounds(IsDarkMode);

      Random random = new();
      return siteBGs[random.Next(siteBGs.Count)];
    }
  }
}
