using System;
using System.Diagnostics;
using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Calculation
{
    public static class TdmCalculator
    {
#if DEBUG
        //Damit nicht ständig ein Assertions-Fehler kommt
        private static int DebugAssertCounter = 0;
        private static int MaxDebugAssert = 1;
#endif

        /// <summary>
        /// Berechnet den TDM-Wert
        /// </summary>
        /// <param name="epPrice">Einkaufspreis</param>
        /// <param name="vpPrice">Verkaufspreis Brutto (inkl. Mwst)</param>
        /// <param name="vpPriceMwstBetrag">Mehrwertsteuerbetrag im Verkaufspreis, 
        /// kann Null sein wenn der Verkaufspreis schon Netto (Mwst-bereinigt) ist.</param>
        /// <returns>TDM value</returns>        
        public static decimal? GetTdm(Money epPrice, Money vpPrice, Money vpPriceMwstBetrag)
        {
            decimal? tdm = null;

            if (epPrice != null && vpPrice != null && vpPriceMwstBetrag != null)
            {
#if DEBUG
                if (vpPrice < epPrice & DebugAssertCounter < MaxDebugAssert)
                {
                    DebugAssertCounter++;
                    Debug.Assert(vpPrice > epPrice, "EP is greater than VP");
                }

                if (vpPrice < vpPriceMwstBetrag & DebugAssertCounter < MaxDebugAssert)
                {
                    DebugAssertCounter++;
                    Debug.Assert(vpPrice > vpPriceMwstBetrag, "Mwst-Anteil-VP is greater than VP");
                }
#endif
                if (vpPrice.Amount > 0m)
                {
                    tdm = ((vpPrice.Amount - vpPriceMwstBetrag.Amount) - epPrice.Amount)/
                          (vpPrice.Amount - vpPriceMwstBetrag.Amount);
                    if (tdm.HasValue)
                    {
                        tdm *= 100;
                        tdm = Math.Round(tdm.Value, 2);
                    }
                }

                if (tdm.HasValue)
                {
                    if (tdm > 100)
                    {
                        Debug.Assert(false, "Tdm greater than 100");
                        //tdm = 100;
                    }
                    //else if (tdm <= 0m)
                    //{
                    //    //Debug.Assert(false, "Tdm is below 0");
                    //    tdm = 0;
                    //}
                }
            }

            return tdm;
        }

        /// <summary>
        /// Berechnet den TDM-Wert
        /// </summary>
        /// <param name="epPrice">Einkaufspreis</param>
        /// <param name="vpPrice">Verkaufspreis Brutto (inkl. Mwst)</param>
        /// <param name="vpPriceMwstBetrag">Mehrwertsteuerbetrag im Verkaufspreis, 
        /// kann Null sein wenn der Verkaufspreis schon Netto (Mwst-bereinigt) ist.</param>
        /// <returns>TDM value</returns> 
        public static decimal? GetTdm(decimal? epPrice, decimal? vpPrice, decimal? vpPriceMwstBetrag)
        {
            decimal? tdm = null;

            if (epPrice.HasValue && vpPrice.HasValue && vpPriceMwstBetrag.HasValue)
                tdm = GetTdm(new Money(epPrice.Value), new Money(vpPrice.Value), new Money(vpPriceMwstBetrag.Value));

            return tdm;
        }

        /// <summary>
        /// Berechnet den TDM-Wert
        /// </summary>
        /// <param name="parameter">Siehe Beschreibung unter ITdmParameter</param>
        /// <returns>TDM value</returns>
        public static decimal? GetTdm(ITdmParameter parameter)
        {
            return GetTdm(parameter.AmountEP, parameter.AmountVP, parameter.AmountVPMwstBetrag);
        }

        /// <summary>
        /// Berechnet den TDM-Wert, inkl. Berechnung des VP-Mehrwertsteuerbetrages
        /// </summary>
        /// <param name="epPrice">Einkaufspreis</param>
        /// <param name="vpPrice">Verkaufspreis Brutto (inkl. Mwst)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>TDM value</returns>        
        public static decimal? GetTdmMwst(Money epPrice, Money vpPrice, decimal mwstSatz)
        {
            Money mwstBetragVp = MwstCalculator.GetMwstBetragBrutto(vpPrice, mwstSatz);
            return GetTdm(epPrice, vpPrice, mwstBetragVp);
        }

        /// <summary>
        /// Berechnet den TDM-Wert, inkl. Berechnung des VP-Mehrwertsteuerbetrages
        /// </summary>
        /// <param name="epPrice">Einkaufspreis</param>
        /// <param name="vpPrice">Verkaufspreis Brutto (inkl. Mwst)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>TDM value</returns>        
        public static decimal? GetTdmMwst(decimal? epPrice, decimal? vpPrice, decimal mwstSatz)
        {
            decimal? mwstBetragVp = MwstCalculator.GetMwstBetragBrutto(vpPrice, mwstSatz);
            return GetTdm(epPrice, vpPrice, mwstBetragVp.Value);
        }
    }
}