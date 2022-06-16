using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gogcord.moe.Shared.Discord;

namespace gogcord.moe.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GuildInfoController : ControllerBase
  {
    [HttpGet]
    public GuildInfo Get()
    {
      GuildInfoLoader Loader = new("601549765611749397");
      return (Loader.GetGuildInfo().Result);
    }
  }
}
