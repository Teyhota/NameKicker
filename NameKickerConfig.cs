using Rocket.API;
using System.Collections.Generic;

namespace NameKicker
{
    public class NameKickerConfig : IRocketPluginConfiguration
    {
        #region Vars
        public static NameKickerConfig Instance;

        public bool BanPlayer;
        public uint BanDuration;
        public List<string> BlockedNames;
        #endregion

        #region Defaults
        public void LoadDefaults()
        {
            BanPlayer = false;
            BanDuration = 86400;
            BlockedNames = new List<string> { "Bob", "Joe", "Tim", "Mary", "Jane" };
        }
        #endregion
    }
}