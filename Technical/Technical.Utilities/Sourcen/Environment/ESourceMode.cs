using System.ComponentModel;

namespace Technical.Utilities.Environment
{
    public enum ESourceMode
    {
        [Description("UNDEFINED (Local)")]
        Undefined, //no source mode defined (like on local development sandbox)
        [Description("TEST")]
        Testing,
        [Description("ABNAHME")]
        Staging,
        [Description("PRODU")]
        Production        
    }
}