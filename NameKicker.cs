using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;

namespace NameKicker
{
    public class NameKicker : RocketPlugin<NameKickerConfig>
    {
        #region Vars
        public string pluginName = "NameKicker";
        public string pluginVersion = "1.2";
        public string pluginDev = "Teyhota";
        public string pluginSite = "Plugins.4Unturned.tk";
        public string unturnedVersion = "3.17.16.0";

        public static WebClient myWebClient = new WebClient();
        string newUpdateTrue = "true";
        string oldVersionTrue = "true";
        string newUpdateSite = myWebClient.DownloadString("http://plugins.4unturned.tk/updatehandler/name-kicker/1.1");
        string oldVersionSite = myWebClient.DownloadString("http://plugins.4unturned.tk/oldversion/name-kicker/1.1");
        
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

            ProhibitedNames = new string[Instance.Configuration.Instance.BlockedNames.Count];
            int b = 0;
            foreach (BlockedNames blocked in Instance.Configuration.Instance.BlockedNames)
            {
                ProhibitedNames = new string[blocked.names.Length];
                foreach (string name in blocked.names)
                {
                    ProhibitedNames[b] = name;
                    b++;
                }
            }

            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            //U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;

            #region Update Checker
            using (var client = new WebClient())
            {
                if (newUpdateSite.Contains(newUpdateTrue) && (oldVersionSite.Contains(oldVersionTrue)))
                {
                    Rocket.Core.Logging.Logger.LogWarning("------");
                    Rocket.Core.Logging.Logger.LogWarning("A new update is available!");
                    Rocket.Core.Logging.Logger.LogWarning("Go to https://github.com/Teyhota/NameKicker/releases/");
                    Rocket.Core.Logging.Logger.LogWarning("and download the latest version!");
                    Rocket.Core.Logging.Logger.LogWarning("------");
                    base.Unload();
                    base.UnloadPlugin();
                }

                else
                {
                    Rocket.Core.Logging.Logger.LogWarning("------");
                    Rocket.Core.Logging.Logger.LogWarning(pluginName + " is up to date!");
                    Rocket.Core.Logging.Logger.LogWarning("------");
                }
            }
            #endregion

            Rocket.Core.Logging.Logger.Log(" Loaded!");
        }
        #endregion

        #region Unload
        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log(" Unloading...");
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            //U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
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
                foreach (string a in ProhibitedNames)
                {
                    if (charName.Contains(a))
                    {
                        if (Instance.Configuration.Instance.BanPlayer)
                        {
                            player.Ban("kick_reason", Instance.Configuration.Instance.BanDuration);
                        }
                        else if (!Instance.Configuration.Instance.BanPlayer)
                        {
                            player.Kick(Translations.Instance.Translate("kick_reason"));
                        }
                        return;
                    }
                }
                Rocket.Core.Logging.Logger.LogWarning(player.CharacterName + " has an ok name!");
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