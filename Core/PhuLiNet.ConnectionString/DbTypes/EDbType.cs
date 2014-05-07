using System.ComponentModel;

namespace Manor.ConnectionStrings.DbTypes
{
    public enum EDbType
    {
        [Description("NO DB")]
        Unkown,
        [Description("PRODU")]
        Wws,
        [Description("HAUPRO")]
        WwHaus,
        [Description("MAINDB")]
        MainDb,
        [Description("AIMPRO")]
        Aim,
        [Description("FISPRO")]
        Fis,
        [Description("LAS")]
        Las,
        [Description("DIV")]
        Div
    }
}
