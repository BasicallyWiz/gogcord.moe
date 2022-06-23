window.ClientUser = {
  // Profile & User
  setUserDisplay: function (user) {
    document.getElementById("profile_avatar").src = `https://cdn.discordapp.com/avatars/${user.id}/${user.avatar}`;
    document.getElementById("profile_username").innerHTML = user.username;
  },

  setUser: function (callbackUser) {

    document.cookie = `user = ${callbackUser.user.id}, ${callbackUser.user.username}, ${callbackUser.user.avatar}; path=/; secure= true; SameSite=Strict;`
    this.setUserDisplay(callbackUser.user);
  },
  getUser: function () {
    var cookies = document.cookie.split(";");
    for (var i = 0; i < cookies.length; i++) {
      if (cookies[i].startsWith("user=")) {
        return cookies[i].replace("user=", "");
      }
    }
  },
  clearUser: function () {
    var cookies = document.cookie.split(";");
    for (var i = 0; i < cookies.length; i++) {
      document.cookie = cookies[i] + ";expires=Thu, 22 Jun 2022 08: 22: 00 GMT;";
    }
  },

  // Token
  setToken: function (token) {
    document.cookie = `access_token = ${token.access_token}, ${token.expires_in}, ${token.refresh_token}, ${token.scope}, ${token.token_type}; path=/;secure=true;SameSite=Strict;`
  },
  getToken: function () {
    var cookies = document.cookie.split("; ");
    for (let i = 0; i < cookies.length; i++) {
      if (cookies[i].startsWith("access_token=")) {
        cookies[i] = cookies[i].replace("access_token=", "");

        SplitCookie = cookies[i].split(", ");
        return `{"access_token":"${SplitCookie[0]}","expires_in":${SplitCookie[1]},"refresh_token":"${SplitCookie[2]}","scope":"${SplitCookie[3]}","token_type":"${SplitCookie[4]}"}`;
      }
    }
  },

  storeOldAuth: function (AuthCode) {
    document.cookie = `old_auth= ${AuthCode}; path=/; secure= true; samesite= Strict;`
  },
  getOldAuth: function () {
    var cookies = document.cookie.split("; ");
    for (let i = 0; i < cookies.length; i++) {
      if (cookies[i].startsWith("old_auth=")) {
        return cookies[i].replace("old_auth=", "");
      }
    }
  },
}