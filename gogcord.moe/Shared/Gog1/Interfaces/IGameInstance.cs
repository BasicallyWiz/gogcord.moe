using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gogcord.moe.Shared.Gog1
{
  internal interface IGameInstance
  {
    public bool IsPublic { get; set; }
    public string Name { get; }
    public Player GameOwner { get; }
    public List<Player> Players { get; }
    public TimeSpan GetDuration();
  }
}
