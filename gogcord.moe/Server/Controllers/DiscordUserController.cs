using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using DiscordOAuth2Helper;
using gogcord.moe.Shared.Discord;
namespace gogcord.moe.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DiscordUserController : ControllerBase
  {
    //GET: api/<DiscordUserController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "hi!", "I use this to test if this api endpoint works.", "Pogger" };
    }

    // GET api/<DiscordUserController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //  return "value";
    //}

    // POST api/<DiscordUserController>
    [HttpPost("Token")]
    public string GetToken(string value, string baseUrl)
    {
      Console.WriteLine(baseUrl);
      OAuth2Helper helper = new(DiscordApplicationData.Id, DiscordApplicationData.GetClientSecret());
      return JsonSerializer.Serialize((CallbackToken)helper.GetAccessToken(value, "https://localhost:7063/Profile/").Result);
    }

    [HttpPost("CurrentUser")]
    public string GetUser(string tokenString)
    {
      CallbackToken token = JsonSerializer.Deserialize<CallbackToken>(tokenString);
      OAuth2Helper helper = new(DiscordApplicationData.Id, DiscordApplicationData.GetClientSecret());
      helper.SetBearerHeader(token);
      CallbackUser user = helper.GetCurrentUser().Result;
      return JsonSerializer.Serialize(user);
    }

    // PUT api/<DiscordUserController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    // DELETE api/<DiscordUserController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
  }
}
