using System.ComponentModel;

namespace Technical.Utilities.Responsibility
{
    // all descriptions should be contained as PERS_ID in table MIM_WWEXT.PERSONS.
    // Hint: 'Entwicklungstechnik' is not a division, instead 'SCS - Leitung/Stab' should be used - if necessary add this division to the enumeration.
    public enum EOperationalTeam
    {
        [Description("SCS_ZS")]
        ScsZentrale,

        [Description("SCS_HS")]
        ScsHaus,

        [Description("SCS_LS")]
        ScsLogistik,

        [Description("SCS_DM")]
        ScsDatenmanagement,

        [Description("SCS_VS")]
        ScsVerwaltungssysteme
    }
}
