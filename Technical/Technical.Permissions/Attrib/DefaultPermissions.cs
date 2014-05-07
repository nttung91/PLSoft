namespace Technical.Permissions.Attrib
{
    /// <summary>
    /// Die Rechte sind in der Tabelle prg_grps abgelegt. Die PGR_ID repräsentiert die PermissionId im .Net-Sourcecode. 
    /// Bestehende Rechte sind wiederzuverwenden, ein neues Recht ist (wie ein TechnicalMenü-Eintrag) über die Entwicklungstechnik anzumelden.
    /// </summary>
    public static class DefaultPermissions
    {
        public const string ORG_Entwicklung = "ORG Entwicklung";
        public const string WWS_Super_User = "WWS Super User";
        public const string ET_Entwicklungswerkzeuge = "ET Entwicklungswerkzeuge";
    }
}