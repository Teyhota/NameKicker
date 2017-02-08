using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NameKicker
{
    public class NameKickerConfig : IRocketPluginConfiguration
    {
        #region Vars
        public static NameKickerConfig Instance;

        public bool BanPlayer;
        public uint BanDuration;
        [XmlArrayItem(ElementName = "Name")]
        public List<BlockedNames> BlockedNames;
        #endregion

        #region Defaults
        public void LoadDefaults()
        {
            BanPlayer = false;
            BanDuration = 86400;
            BlockedNames = new List<BlockedNames>
            {
                new BlockedNames { names = new string[] { "Bob", "Joe", "Tim", "Mary", "Jane" } }
            };
        }
        #endregion
    }

    public class BlockedNames
    {
        public BlockedNames() { }
        public string[] names;
    }
}