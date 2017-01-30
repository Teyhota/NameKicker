using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NameKicker
{
    public class NameKickerConfig : IRocketPluginConfiguration
    {
        public static NameKickerConfig Instance;
        
        [XmlArrayItem(ElementName = "Name")]
        public List<BlockedNames> BlockedNames;

        public void LoadDefaults()
        {
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