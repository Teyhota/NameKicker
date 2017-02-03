using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;

namespace NameKicker
{
    public class NameKicker : RocketPlugin<NameKickerConfig>
    {
        public static NameKicker Instance;
        public static string[] ProhibitedNames;

        protected override void Load()
        {
            Instance = this;
            ProhibitedNames = new string[Instance.Configuration.Instance.BlockedNames.Count];
            int b = 0;
            foreach (BlockedNames blocked in Instance.Configuration.Instance.BlockedNames)
            {
                ProhibitedNames = new string[blocked.name.Length];
                foreach (string name in blocked.name)
                {
                    ProhibitedNames[b] = name;
                    b++;
                }
            }
            //base.Load();
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            Rocket.Core.Logging.Logger.Log("Loading plugin...", ConsoleColor.DarkGreen);
            Rocket.Core.Logging.Logger.LogWarning("Plugin by: Teyhota");
            Rocket.Core.Logging.Logger.LogWarning("Plugin Version: 1.0.2.0 beta");
            Rocket.Core.Logging.Logger.LogWarning("For Unturned Version: 3.17.15.0");
            Rocket.Core.Logging.Logger.Log("...NameKicker has been loaded!", ConsoleColor.DarkGreen);
            Rocket.Core.Logging.Logger.Log("Go to plugins.4Unturned.tk for support!", ConsoleColor.DarkRed);

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
                    {"kick_reason", "please change your username!"},
                };
            }
        }

        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            string charName = player.CharacterName;

            //player joins that is not admin
            if (!player.IsAdmin)
            {
                foreach (string a in ProhibitedNames)
                {
                    if (charName.Contains(a))
                    {
                        if (Instance.Configuration.Instance.BanInsteadOfKick)
                        {
                            player.Ban("kick_reason", Instance.Configuration.Instance.BanTime);
                        }
                        else if (!Instance.Configuration.Instance.BanInsteadOfKick)
                        {
                            player.Kick(Translations.Instance.Translate("kick_reason"));
                        }
                    }
                }
            }
        }
    }
}