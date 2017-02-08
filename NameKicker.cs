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
        public string pluginVersion = "1.1";
        public string pluginDev = "Teyhota";
        public string pluginSite = "Plugins.4Unturned.tk";
        public string unturnedVersion = "3.17.16.0";

        public static WebClient myWebClient = new WebClient();
        string newUpdateTrue = "true";
        string oldVersionTrue = "true";
        string newUpdateSite = myWebClient.DownloadString("http://plugins.4unturned.tk/updatehandler/name-kicker/1.1");
        string oldVersionSite = myWebClient.DownloadString("http://plugins.4unturned.tk/oldversion/name-kicker/1.1");
        
        public static NameKicker Instance;
        #endregion

        #region Load
        protected override void Load()
        {
            base.Load();
            Instance = this;
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            //U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;

            Rocket.Core.Logging.Logger.Log(" Loading...");
            Rocket.Core.Logging.Logger.LogWarning("Plugin by: " + pluginDev);
            Rocket.Core.Logging.Logger.LogWarning("Plugin Version: " + pluginVersion);
            Rocket.Core.Logging.Logger.LogWarning("For Unturned Version: " + unturnedVersion);
            Rocket.Core.Logging.Logger.LogWarning("Support: " + pluginSite);

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
            Rocket.Core.Logging.Logger.Log(" Unloaded!");
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            //U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
            base.Unload();
        }
        #endregion

        #region Translations
        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList()
                {
                    {"kick_reason_name_1", "Please change your username!"},
                    {"kick_reason_name_2", "Please change your username!"},
                    {"kick_reason_name_3", "Please change your username!"},
                    {"kick_reason_name_4", "Please change your username!"},
                    {"kick_reason_name_5", "Please change your username!"},
                    {"kick_reason_name_6", "Please change your username!"},
                    {"kick_reason_name_7", "Please change your username!"},
                    {"kick_reason_name_8", "Please change your username!"},
                    {"kick_reason_name_9", "Please change your username!"},
                    {"kick_reason_name_10", "Please change your username!"}
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
                if (charName.Contains(Instance.Configuration.Instance.BlockedName1))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_1", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_1"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_1"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName2))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_2", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_2"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_2"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName3))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_3", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_3"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_3"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName4))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_4", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_4"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_4"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName5))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_5", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_5"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_5"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName6))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_6", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_6"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_6"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName7))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_7", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_7"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_7"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName8))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_8", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_8"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_8"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName9))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_9", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_9"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_9"));
                    }
                }

                else if (charName.Contains(Instance.Configuration.Instance.BlockedName10))
                {
                    UnturnedChat.Say("NameKicker: " + Instance.Translate("kick_reason_name_10", Color.red));

                    if (Instance.Configuration.Instance.BanPlayer)
                    {
                        Provider.ban(player.CSteamID, Instance.Translate("kick_reason_name_10"), Instance.Configuration.Instance.BanDuration);
                    }

                    else
                    {
                        Provider.kick(player.CSteamID, Instance.Translate("kick_reason_name_10"));
                    }
                }

                else
                {
                    Rocket.Core.Logging.Logger.Log("Player ok!", ConsoleColor.Magenta);
                }
                #endregion
            }

            //player joins that is admin
            else
            {
                Rocket.Core.Logging.Logger.Log("Player is excused because they are Admin!", ConsoleColor.Magenta);
            }
        }
        #endregion
    }
}