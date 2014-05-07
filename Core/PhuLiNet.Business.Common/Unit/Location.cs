using System;

namespace PhuLiNet.Business.Common.Unit
{
    [Serializable]
    public struct Location
    {
        public int ArtLocId;
        public string LocName;
        public string Abbrev;
        public string Descr;
        public double VorjahresUmsatz;
        public string LanguageCode;
        public string LanguageDescr;
        public int LocArtLocId;

        public Location(int artLocId, string locName, string abbrev, string descr)
        {
            ArtLocId = artLocId;
            LocName = locName;
            Abbrev = abbrev;
            Descr = descr;
            VorjahresUmsatz = 0d;
            LanguageCode = string.Empty;
            LanguageDescr = string.Empty;
            LocArtLocId = 0;
        }

        public Location(int artLocId, string locName, string abbrev, string descr, int locArtLocId)
        {
            ArtLocId = artLocId;
            LocName = locName;
            Abbrev = abbrev;
            Descr = descr;
            VorjahresUmsatz = 0d;
            LanguageCode = string.Empty;
            LanguageDescr = string.Empty;
            LocArtLocId = locArtLocId;
        }

        public Location(int artLocId, string locName, string abbrev, string descr, double vorjahresUmsatz)
        {
            ArtLocId = artLocId;
            LocName = locName;
            Abbrev = abbrev;
            Descr = descr;
            VorjahresUmsatz = vorjahresUmsatz;
            LanguageCode = string.Empty;
            LanguageDescr = string.Empty;
            LocArtLocId = 0;
        }

        public Location(int artLocId, string locName, string abbrev, string descr, double vorjahresUmsatz,
            string languageCode, string languageDescr)
        {
            ArtLocId = artLocId;
            LocName = locName;
            Abbrev = abbrev;
            Descr = descr;
            VorjahresUmsatz = vorjahresUmsatz;
            LanguageCode = languageCode;
            LanguageDescr = languageDescr;
            LocArtLocId = 0;
        }

        public Location(int artLocId, string locName, string abbrev, string descr, double vorjahresUmsatz,
            string languageCode, string languageDescr, int locArtLocId)
        {
            ArtLocId = artLocId;
            LocName = locName;
            Abbrev = abbrev;
            Descr = descr;
            VorjahresUmsatz = vorjahresUmsatz;
            LanguageCode = languageCode;
            LanguageDescr = languageDescr;
            LocArtLocId = locArtLocId;
        }

        public Location Duplicate()
        {
            return new Location(ArtLocId, LocName, Abbrev, Descr, VorjahresUmsatz, LanguageCode, LanguageDescr,
                LocArtLocId);
        }

        public override string ToString()
        {
            return LocName;
        }
    }
}