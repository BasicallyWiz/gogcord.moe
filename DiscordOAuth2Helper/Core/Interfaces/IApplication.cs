using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordOAuth2Helper
{
  public interface IApplication
  {
    public string Id { get; }
    public string Name { get; }
    public string? Icon { get; }
    public string Description { get; }
    public string Summary { get; }
    public string? Type { get; }
    public bool Hook { get; }
    public string Custom_Install_Url { get; }
    public string Verify_Key { get; }
  }
}
