using System.Diagnostics;
using Technical.Utilities.Helpers;

namespace PhuLiNet.Business.Common.Delivery
{
    public static class FreightMethodDefinitions
    {
        /// <summary>
        /// Ist diese Transportart Land?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsLand(string fmId)
        {
            Debug.Assert(fmId != null, "fmId is null");

            if (fmId == EnumHelper.GetEnumDescription(EFreightMethods.Land))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ist diese Transportart Air?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsAir(string fmId)
        {
            Debug.Assert(fmId != null, "fmId is null");

            if (fmId == EnumHelper.GetEnumDescription(EFreightMethods.Air))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ist diese Transportart Sea?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsSea(string fmId)
        {
            Debug.Assert(fmId != null, "fmId is null");

            if (fmId == EnumHelper.GetEnumDescription(EFreightMethods.Sea))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ist diese Transportart SeaAir?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsSeaAir(string fmId)
        {
            Debug.Assert(fmId != null, "fmId is null");

            if (fmId == EnumHelper.GetEnumDescription(EFreightMethods.SeaAir))
                return true;
            else
                return false;
        }
    }
}