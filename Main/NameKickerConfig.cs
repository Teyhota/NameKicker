using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NameKickerConfig : IRocketPluginConfiguration
{
    public static NameKickerConfig Instance;

    public string BlockedName1 = "";
    public string BlockedName2 = "";
    public string BlockedName3 = "";
    public string BlockedName4 = "";
    public string BlockedName5 = "";

    public void LoadDefaults()
    {
        BlockedName1 = "bob";
        BlockedName2 = "joe";
        BlockedName3 = "tim";
        BlockedName4 = "mary";
        BlockedName5 = "jane";
    }
}