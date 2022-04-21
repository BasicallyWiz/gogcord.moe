namespace gogcord.moe.Data
{
  public class ClientQueueObject
  {
    public readonly string TargetFunction;
    public readonly List<string> Args;

    public ClientQueueObject(string TargetFunction, List<string> Args)
    {
      this.TargetFunction = TargetFunction;
      this.Args = Args;
    }
    public ClientQueueObject(string TargetFunction)
    {
      this.TargetFunction = TargetFunction;
      this.Args = new();
    }
  
    public void AddArg(string Arg)
    {
      Args.Add(Arg);
    }
    public void AddArgsBulk(List<string> Args)
    {
      foreach (string Arg in Args)
      {
        this.Args.Add(Arg);
      }
    }
    public void RemoveArg(string Arg)
    {
      Args.RemoveAt(Args.IndexOf(Arg));
    }
    public void RemoveArgsBulk(List<string> Args)
    {
      foreach (string Arg in Args)
      {
        this.Args.RemoveAt(Args.IndexOf(Arg));
      }
    }
  }
}
