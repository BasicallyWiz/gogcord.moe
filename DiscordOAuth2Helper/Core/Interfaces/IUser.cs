using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordOAuth2Helper
{
  public interface IUser
  {
    public string Id { get; }
    public string Username { get; }
    public string Avatar { get; }
    public string? Avatar_Decoration { get; }
    public string Discriminator { get; }
    public int Public_Flags { get; }
  }
}
