using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NameKickerConfig : IRocketPluginConfiguration
{
    #region Vars
    public static NameKickerConfig Instance;

    public string BlockedName1;
    public string BlockedName2;
    public string BlockedName3;
    public string BlockedName4;
    public string BlockedName5;
    public string BlockedName6;
    public string BlockedName7;
    public string BlockedName8;
    public string BlockedName9;
    public string BlockedName10;
    public bool BanPlayer;
    public uint BanDuration;
    #endregion

    #region Defaults
    public void LoadDefaults()
    {
        BlockedName1 = "Admin";
        BlockedName2 = "Moderator";
        BlockedName3 = "Tyler";
        BlockedName4 = "Peter";
        BlockedName5 = "Griffin";
        BlockedName6 = "Bob";
        BlockedName7 = "Joe";
        BlockedName8 = "Tim";
        BlockedName9 = "Mary";
        BlockedName10 = "Jane";
        BanPlayer = false;
        BanDuration = 86400;
    }
    #endregion
}