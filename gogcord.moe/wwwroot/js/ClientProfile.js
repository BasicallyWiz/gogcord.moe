window.ClientProfile = {

  // Methods
  setProfileDisplay: function (args) {
    console.log(args);
    document.getElementById("profile_avatar").src = `https://cdn.discordapp.com/avatars/${args.id}/${args.avatar}`;
    document.getElementById("profile_username").innerHTML = args.username;
  },

  setClientProfile: function (args, access_token) {

    console.log(access_token);
    document.cookie = `discord_access_code = ${access_token}; path=/`;
    this.setProfileDisplay(args);
  },

  removeClientProfile: function (args) {

  }
}