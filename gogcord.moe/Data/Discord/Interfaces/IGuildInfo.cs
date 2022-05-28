namespace gogcord.moe.Data.Discord
{
  public interface IGuildInfo
  {
    public string Id { get; }
    public string Name { get; }
    public string Instant_Invite { get; }
    public ChannelInfo[] Channels { get; }
    public MemberInfo[] Members { get; }
    public int Presence_Count { get; }
  }
}
