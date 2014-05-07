using System;
using System.Collections.Generic;
using System.Linq;
using Technical.Utilities.Extensions;
using Technical.Utilities.Helpers;

namespace PhuLiNet.Business.Common.Delivery
{
    /// <summary>
    /// Definition von Lieferbedingungen und Regeln
    /// </summary>
    public static class DeliveryDefinitions
    {
        /// <summary>
        /// Ist dieser Warenfluss Stock?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsStock(string lfa)
        {
            if (string.IsNullOrEmpty(lfa)) throw new ArgumentNullException("lfa");

            if (lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Stock))
                return true;
            return false;
        }

        /// <summary>
        /// Ist dieser Warenfluss Direkt?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsDirect(string lfa)
        {
            if (string.IsNullOrEmpty(lfa)) throw new ArgumentNullException("lfa");

            if (lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Direct))
                return true;
            return false;
        }

        /// <summary>
        /// Ist dieser Warenfluss Transit?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsTransit(string lfa)
        {
            if (string.IsNullOrEmpty(lfa)) throw new ArgumentNullException("lfa");

            if (lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Transit))
                return true;
            return false;
        }

        /// <summary>
        /// Ist dieser Warenfluss Repartition?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsRepartition(string lfa)
        {
            if (string.IsNullOrEmpty(lfa)) throw new ArgumentNullException("lfa");

            if (lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Repartition))
                return true;
            return false;
        }

        /// <summary>
        /// Ist dieser Warenfluss Crossdocking?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsCrossdocking(string lfa)
        {
            if (string.IsNullOrEmpty(lfa)) throw new ArgumentNullException("lfa");

            if (lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Crossdocking))
                return true;
            return false;
        }

        /// <summary>
        /// Ist für diesen Warenfluss eine Angabe des Lagers nötig?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsStockLocationNeeded(string lfa)
        {
            bool stockNeeded = false;

            if (!string.IsNullOrEmpty(lfa))
            {
                if (lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Stock) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Transit) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Repartition) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Crossdocking))
                {
                    stockNeeded = true;
                }
            }

            return stockNeeded;
        }

        /// <summary>
        /// Ist für diesen Warenfluss eine Haus-Verteilung möglich/nötig?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsDistributionListNeeded(string lfa)
        {
            bool distributionListNeeded = false;

            if (!string.IsNullOrEmpty(lfa))
            {
                if (lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Direct) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Transit) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Repartition) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Crossdocking))
                {
                    distributionListNeeded = true;
                }
            }

            return distributionListNeeded;
        }

        /// <summary>
        /// Ist dieser Warenfluss gültig für Lieferantenbestellungen?
        /// </summary>
        /// <param name="lfa"></param>
        /// <returns></returns>
        public static bool IsPossibleForSupplierOrder(string lfa)
        {
            if (!string.IsNullOrEmpty(lfa))
            {
                if (lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Direct) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Transit) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Repartition) ||
                    lfa.ToUpper() == EnumHelper.GetEnumDescription(ELfaIds.Stock))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<string> LfaIdsPossibleForSupplierOrder()
        {
            var lfas = Enum.GetValues(typeof (ELfaIds))
                .Cast<object>()
                .Select(p => EnumHelper.GetEnumDescription((ELfaIds) p))
                .Where(IsPossibleForSupplierOrder)
                .ToList();
            return lfas;
        }

        public static List<string> LfaIdsNotPossibleForSupplierOrder()
        {
            var lfas = Enum.GetValues(typeof (ELfaIds))
                .Cast<object>()
                .Select(p => EnumHelper.GetEnumDescription((ELfaIds) p))
                .Where(p => !IsPossibleForSupplierOrder(p))
                .ToList();
            return lfas;
        }

        public static string StockLfaId()
        {
            return GetLfaId(ELfaIds.Stock);
        }

        public static string DirectLfaId()
        {
            return GetLfaId(ELfaIds.Direct);
        }

        public static string GetLfaId(ELfaIds lfaIdEnum)
        {
            return EnumHelper.GetEnumDescription(lfaIdEnum);
        }
    }
}