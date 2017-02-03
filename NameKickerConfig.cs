using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NameKicker
{
    public class NameKickerConfig : IRocketPluginConfiguration
    {
        public static NameKickerConfig Instance;

        public bool BanInsteadOfKick;
        public uint BanTime;
        [XmlArrayItem(ElementName = "Name")]
        public List<BlockedNames> BlockedNames;

        public void LoadDefaults()
        {
            BanInsteadOfKick = true;
            BanTime = 3600;
            BlockedNames = new List<BlockedNames>
            {
                new BlockedNames { name = new string[] { "Bob", "Joe", "Tim", "Mary", "Jane" } }
            };
        }
    }

    public class BlockedNames
    {
        public BlockedNames() { }
        public string[] name;
    }
}