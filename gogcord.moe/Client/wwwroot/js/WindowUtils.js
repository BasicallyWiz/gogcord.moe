window.WindowUtils = {
  setUri: function (uri) {
    window.location.href = uri;
  },
  browserInfo: function() {
    navigator["appCodeName"]
    navigator["appName"]
    navigator["appMinorVersion"]
    navigator["cpuClass"]
    navigator["platform"]
    navigator["plugins"]
    navigator["opsProfile"]
    navigator["userProfile"]
    navigator["systemLanguage"]
    navigator["userLanguage"]
    navigator["appVersion"]
    navigator["userAgent"]
    navigator["onLine"]
    navigator["cookieEnabled"]
    navigator["mimeTypes"]

    return navigator;
  },
  isDarkTheme: function () {
    return window.matchMedia("(prefers-color-scheme: dark)").matches
  },
  removeModal: function (modalElement) {
    if (modalElement.id == "modal-background") {
      console.log("gogey");
      DotNet.invokeMethodAsync('gogcord.moe.Client', 'StaticHideModal');
    }
  }
}