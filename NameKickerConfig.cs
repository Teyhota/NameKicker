using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        BlockedName1 = "Bob";
        BlockedName2 = "Joe";
        BlockedName3 = "Tim";
        BlockedName4 = "Mary";
        BlockedName5 = "Jane";
    }
}