using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DiscordOAuth2Helper
{
  public class Application : IApplication
  {
    [JsonPropertyName("id")]
    public string Id { get; }
    [JsonPropertyName("name")]
    public string Name { get; }
    [JsonPropertyName("icon")]
    public string? Icon { get; }
    [JsonPropertyName("description")]
    public string Description { get; }
    [JsonPropertyName("summary")]
    public string Summary { get; }
    [JsonPropertyName("type")]
    public string? Type { get; }
    [JsonPropertyName("hook")]
    public bool Hook { get; }
    [JsonPropertyName("custom_install_url")]
    public string Custom_Install_Url { get; }
    [JsonPropertyName("verify_key")]
    public string Verify_Key { get; }
  }
}
