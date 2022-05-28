namespace gogcord.moe.Data.Discord
{
  public interface IMemberInfo
  {
    public string Id { get; }
    public string Username { get; }
    public string Discriminator { get; }
    public object? Avatar { get; } // I don't know what this is
    public string Status { get; }
    public string Avatar_Url { get; }
    public Dictionary<string, object> ExtentionData { get; }
  }
}
