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
using System.Text;
using System.Threading;
using UnityEngine;

namespace NameKicker
{
    public class NameKicker : RocketPlugin<NameKickerConfig>
    {

        public static NameKicker Instance;
        protected override void Load()
        {
            Instance = this;
            //base.Load();
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            Rocket.Core.Logging.Logger.Log("Loading plugin...", ConsoleColor.DarkGreen);
            Rocket.Core.Logging.Logger.LogWarning("Plugin by: Teyhota");
            Rocket.Core.Logging.Logger.LogWarning("Plugin Version: 1.0.0.10 beta");
            Rocket.Core.Logging.Logger.LogWarning("For Unturned Version: 3.17.11.0");
            Rocket.Core.Logging.Logger.Log("...NameKicker has been loaded!", ConsoleColor.DarkGreen);
            Rocket.Core.Logging.Logger.Log("Go to TRPD.4Unturned.tk for support!", ConsoleColor.DarkRed);

        }

        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("Unloading plugin...", ConsoleColor.DarkRed);
            Rocket.Core.Logging.Logger.Log("...NameKicker has been unloaded!", ConsoleColor.DarkRed);
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            //base.Unload();
        }

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
                    {"kick_reason_name_5", "Please change your username!"}
                };
            }
        }

        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            string charName = player.CharacterName;

            //player joins that is not admin
            if (!player.IsAdmin)
                if (charName.Contains(NameKicker.Instance.Configuration.Instance.BlockedName1))
                {
                    UnturnedChat.Say(NameKicker.Instance.Translate("kick_reason_name_1"));
                    Provider.kick(player.CSteamID, NameKicker.Instance.Translations.Instance.Translate("kick_reason_name_1"));
                }
                else if (charName.Contains(NameKicker.Instance.Configuration.Instance.BlockedName2))
                {
                    UnturnedChat.Say(NameKicker.Instance.Translate("kick_reason_name_2"));
                    Provider.kick(player.CSteamID, NameKicker.Instance.Translations.Instance.Translate("kick_reason_name_2"));
                }
                else if (charName.Contains(NameKicker.Instance.Configuration.Instance.BlockedName3))
                {
                    UnturnedChat.Say(NameKicker.Instance.Translate("kick_reason_name_3"));
                    Provider.kick(player.CSteamID, NameKicker.Instance.Translations.Instance.Translate("kick_reason_name_3"));
                }
                else if (charName.Contains(NameKicker.Instance.Configuration.Instance.BlockedName4))
                {
                    UnturnedChat.Say(NameKicker.Instance.Translate("kick_reason_name_4"));
                    Provider.kick(player.CSteamID, NameKicker.Instance.Translations.Instance.Translate("kick_reason_name_4"));
                }
                else if (charName.Contains(NameKicker.Instance.Configuration.Instance.BlockedName5))
                {
                    UnturnedChat.Say(NameKicker.Instance.Translate("kick_reason_name_5"));
                    Provider.kick(player.CSteamID, NameKicker.Instance.Translations.Instance.Translate("kick_reason_name_5"));
                }
            }
        }
    }