using Technical.Utilities.Helpers;

namespace PhuLiNet.Business.Common.Delivery
{
    /// <summary>
    /// Location Level Definition
    /// </summary>
    public static class LocationLevel
    {
        /// <summary>
        /// Ist dieser Level Haus?
        /// </summary>
        /// <param name="lslId"></param>
        /// <returns></returns>
        public static bool IsHaus(string lslId)
        {
            if (lslId.ToUpper() == GetLocationLevel(ELocationLevel.Haus))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ist dieser Level Lager?
        /// </summary>
        /// <param name="lslId"></param>
        /// <returns></returns>
        public static bool IsLager(string lslId)
        {
            if (lslId.ToUpper() == GetLocationLevel(ELocationLevel.Lager))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ist dieser Level Rayon?
        /// </summary>
        /// <param name="lslId"></param>
        /// <returns></returns>
        public static bool IsRayon(string lslId)
        {
            if (lslId.ToUpper() == GetLocationLevel(ELocationLevel.Rayon))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ist dieser Level Zentrale?
        /// </summary>
        /// <param name="lslId"></param>
        /// <returns></returns>
        public static bool IsZentrale(string lslId)
        {
            if (lslId.ToUpper() == GetLocationLevel(ELocationLevel.Zentrale))
                return true;
            else
                return false;
        }

        public static string GetLocationLevel(ELocationLevel locationLevelEnum)
        {
            return EnumHelper.GetEnumDescription(locationLevelEnum);
        }
    }
}