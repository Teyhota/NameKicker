using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using System.Net;

namespace NameKicker
{
    public class NameKicker : RocketPlugin<NameKickerConfig>
    {
        #region Vars
        public string pluginName = "NameKicker";
        public string pluginVersion = "1.1.1";
        public string pluginDev = "Teyhota";
        public string pluginSite = "Plugins.4Unturned.tk";
        public string unturnedVersion = "3.17.16.0";

        #region New Update Checker
        public static WebClient myWebClient = new WebClient();
        string nextVersion1 = "1.1.2";
        string nextVersion2 = "1.2";
        string nextVersion3 = "2.0";
        string True = "true";
        string newUpdateSite = myWebClient.DownloadString("http://plugins.4unturned.tk/updatehandler/name-kicker/1.1.1");
        string oldVersionSite = myWebClient.DownloadString("http://plugins.4unturned.tk/oldversion/name-kicker/1.1.1");
        #endregion

        public static NameKicker Instance;
        public static string[] ProhibitedNames;
        #endregion

        #region Load
        protected override void Load()
        {
            base.Load();
            Instance = this;
            Rocket.Core.Logging.Logger.Log(" Loading...");
            Rocket.Core.Logging.Logger.LogWarning("Plugin by: " + pluginDev);
            Rocket.Core.Logging.Logger.LogWarning("Plugin Version: " + pluginVersion);
            Rocket.Core.Logging.Logger.LogWarning("For Unturned Version: " + unturnedVersion);
            Rocket.Core.Logging.Logger.LogWarning("Support: " + pluginSite);

            U.Events.OnPlayerConnected += Events_OnPlayerConnected;

            #region New Update Checker
            using (var client = new WebClient())
            {
                #region Next Version 1
                if (newUpdateSite.Contains(nextVersion1))
                {
                    Rocket.Core.Logging.Logger.LogWarning("------");
                    Rocket.Core.Logging.Logger.LogError("A new version is available!");
                    Rocket.Core.Logging.Logger.LogError("Please update to version " + nextVersion1);
                    Rocket.Core.Logging.Logger.LogError("now, by going to...");
                    Rocket.Core.Logging.Logger.LogError("github.com/Teyhota/" + pluginName + "/releases/");
                    Rocket.Core.Logging.Logger.LogWarning("------");
                }
                #endregion

                #region Next Version 2
                else if (newUpdateSite.Contains(nextVersion2))
                {
                    Rocket.Core.Logging.Logger.LogWarning("------");
                    Rocket.Core.Logging.Logger.LogError("A new version is available!");
                    Rocket.Core.Logging.Logger.LogError("Please update to version " + nextVersion2);
                    Rocket.Core.Logging.Logger.LogError("now, by going to...");
                    Rocket.Core.Logging.Logger.LogError("github.com/Teyhota/" + pluginName + "/releases/");
                    Rocket.Core.Logging.Logger.LogWarning("------");
                }
                #endregion

                #region Next Version 3
                else if (newUpdateSite.Contains(nextVersion3))
                {
                    Rocket.Core.Logging.Logger.LogWarning("------");
                    Rocket.Core.Logging.Logger.LogError("A new version is available!");
                    Rocket.Core.Logging.Logger.LogError("Please update to version " + nextVersion3);
                    Rocket.Core.Logging.Logger.LogError("now, by going to...");
                    Rocket.Core.Logging.Logger.LogError("github.com/Teyhota/" + pluginName + "/releases/");
                    Rocket.Core.Logging.Logger.LogWarning("------");
                }
                #endregion

                #region Up To Date
                else
                {
                    Rocket.Core.Logging.Logger.LogWarning("------");
                    Rocket.Core.Logging.Logger.LogError(pluginName + " is up to date!");
                    Rocket.Core.Logging.Logger.LogWarning("------");
                }
                #endregion

                Rocket.Core.Logging.Logger.Log(" Loaded!");
            }
            #endregion
        }
        #endregion

        #region Unload
        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            base.Unload();
            Rocket.Core.Logging.Logger.Log(" Unloaded!");
        }
        #endregion

        #region Translations
        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList()
                {
                    {"kick_reason", "Please change your username!"}
                };
            }
        }
        #endregion

        #region OnPlayerConnected
        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            string charName = player.CharacterName;

            //player joins that is *not* admin
            if (!player.IsAdmin)
            {
                #region Kick Players With Blocked Names
                foreach (string name in Instance.Configuration.Instance.BlockedNames)
                {
                    if (charName.Contains(name))
                    {
                        if (Instance.Configuration.Instance.BanPlayer)
                        {
                            player.Ban("reason", Instance.Configuration.Instance.BanDuration);
                        }
                        else
                        {
                            player.Kick(Translations.Instance.Translate("reason"));
                        }
                        return;
                    }

                    else
                    {
                        Rocket.Core.Logging.Logger.LogWarning(player.CharacterName + " has an ok name!");
                    }
                }
                #endregion
            }

            //player joins that is admin
            else
            {
                Rocket.Core.Logging.Logger.LogWarning(player.CharacterName + " is excused because they are an admin!");
            }
        }
        #endregion
    }
}