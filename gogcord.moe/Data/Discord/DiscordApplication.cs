namespace gogcord.moe.Data.Discord
{
  public class DiscordApplication
  {
    public string id { get; }
    public string name { get; }
    public string? icon { get; }
    public string description { get; }
    public string summary { get; }
    public string? type { get; }
    public bool? hook { get; }
    public string custom_install_url { get; }
    public string verify_key { get; }

    public DiscordApplication(string id, string name, string? icon, string description, string summary, string? type, bool? hook, string custom_install_url, string verify_key)
    {
      this.id = id;
      this.name = name;
      this.icon = icon;
      this.description = description;
      this.summary = summary;
      this.type = type;
      this.hook = hook;
      this.custom_install_url = custom_install_url;
      this.verify_key = verify_key;
    }
  }
}
