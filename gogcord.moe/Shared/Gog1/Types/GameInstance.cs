using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gogcord.moe.Shared.Gog1
{
  internal class GameInstance : IGameInstance
  {
    //  Public info
    public bool IsPublic { get; set; }
    public string Name { get; }
    public Player GameOwner { get; }
    public List<Player> Players { get; private set; }
    DateTime TimeStarted { get; set; }
    public TimeSpan GetDuration()
    {
      return DateTime.Now.Subtract(TimeStarted);
    }

    //  Game Data
    public GameInstance()
    {
      TimeStarted = DateTime.Now;
    }
  }
}
