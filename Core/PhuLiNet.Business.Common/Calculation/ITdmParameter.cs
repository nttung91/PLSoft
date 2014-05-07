using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Calculation
{
    public interface ITdmParameter
    {
        /// <summary>
        /// Einkaufspreis
        /// </summary>
        Money AmountEP { get; }

        /// <summary>
        /// Verkaufspreis Brutto (inkl. Mwst)
        /// </summary>
        Money AmountVP { get; }

        /// <summary>
        /// Mehrwertsteuerbetrag im Verkaufspreis, 
        /// kann Null sein wenn der Verkaufspreis schon Netto (Mwst-bereinigt) ist.
        /// </summary>
        Money AmountVPMwstBetrag { get; }
    }
}