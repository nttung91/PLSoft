namespace PhuLiNet.Business.Common.Delivery
{
    public static class JurisdictionDefinitions
    {
        private const string DOMESTIC_JUR_ID = "CH";

        /// <summary>
        /// Inland
        /// </summary>
        public static bool IsDomestic(string jurId)
        {
            return (jurId.Equals(DOMESTIC_JUR_ID));
        }
    }
}