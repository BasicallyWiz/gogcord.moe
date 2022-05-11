﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DiscordOAuth2Helper
{
  public class CallbackUser : ICallbackUser
  {
    [JsonPropertyName("application")]
    public Application Application { get; }
    [JsonPropertyName("scopes")]
    public string[] Scopes { get; }
    [JsonPropertyName("expires")]
    public string expires { get; }
    [JsonPropertyName("user")]
    public User User { get; }

    public CallbackUser(Application application, string[] scopes, string expires, User User)
    {
      this.Application = application;
      this.Scopes = scopes;
      this.expires = expires;
      this.User = User;
    }
  }
}
