window.ClientUser = {

  // Profile & User
  setUserDisplay: function (user) {
    console.log(user);
    document.getElementById("profile_avatar").src = `https://cdn.discordapp.com/avatars/${user.id}/${user.avatar}`;
    document.getElementById("profile_username").innerHTML = user.username;
  },

  setUser: function (callbackUser) {

    document.cookie = `user = ${callbackUser.user.id}, ${callbackUser.user.username}, ${callbackUser.user.avatar}; path=/; secure= true;`
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
      if (cookies[i].startsWith("user=")) {
        document.cookie = "user=; path=/; secure= true;";
        document.cookie = `access_token=; path=/; secure= true;`;
        document.cookie = `old_auth=; path=/; secure= true;`;
      }
    }
  },

  // Token
  setToken: function (token) {
    document.cookie = `access_token = ${token.access_token}, ${token.expires_in}, ${token.refresh_token}, ${token.scope}, ${token.token_type}; path=/; secure= true;`
  },
  getToken: function () {
    var cookies = document.cookie.split("; ");
    for (let i = 0; i < cookies.length; i++) {
      console.log(cookies[i]);
      if (cookies[i].startsWith("access_token=")) {
        return cookies[i].replace("access_token=", "");
      }
    }
  },

  storeOldAuth: function (AuthCode) {
    document.cookie = `old_auth= ${AuthCode}; path=/; secure= true;`
  },
  getOldAuth: function () {
    var cookies = document.cookie.split("; ");
    for (let i = 0; i < cookies.length; i++) {
      console.log(cookies[i]);
      if (cookies[i].startsWith("old_auth=")) {
        return cookies[i].replace("old_auth=", "");
      }
    }
  },
}