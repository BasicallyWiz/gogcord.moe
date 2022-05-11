window.ClientUser = {

  // Methods
  setUserDisplay: function (user) {
    console.log(args);
    document.getElementById("profile_avatar").src = `https://cdn.discordapp.com/avatars/${user.id}/${user.avatar}`;
    document.getElementById("profile_username").innerHTML = user.username;
  },

  setUser: function (user) {

    DotNet.invokeMethodAsync("gogcord.moe", "setCurrentUser");
    this.setUserDisplay(user);
  },

  removeUser: function (args) {

  }
}