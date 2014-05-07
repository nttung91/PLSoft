using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Calculation
{
    public static class MwstCalculator
    {
        /// <summary>
        /// Berechnet den Nettobetrag (Betrag ohne Mwst.)
        /// </summary>
        /// <param name="bruttoPrice">Bruttobetrag (Betrag mit Mwst.)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>Nettobetrag (Betrag ohne Mwst.)</returns>
        public static Money GetNettoPrice(Money bruttoPrice, decimal mwstSatz)
        {
            Money nettoPrice = null;

            if (bruttoPrice != null)
            {
                nettoPrice = new Money(bruttoPrice.Amount/(100 + mwstSatz)*100);
            }

            return nettoPrice;
        }

        /// <summary>
        /// Berechnet den Nettobetrag (Betrag ohne Mwst.)
        /// </summary>
        /// <param name="bruttoPrice">Bruttobetrag (Betrag mit Mwst.)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>Nettobetrag (Betrag ohne Mwst.)</returns>
        public static decimal? GetNettoPrice(decimal? bruttoPrice, decimal mwstSatz)
        {
            decimal? nettoPrice = null;

            if (bruttoPrice.HasValue)
            {
                Money netto = GetNettoPrice(new Money(bruttoPrice.Value), mwstSatz);
                if (netto != null)
                    nettoPrice = netto.Amount;
            }

            return nettoPrice;
        }

        /// <summary>
        /// Berechnet den Bruttobetrag (Betrag mit Mwst.)
        /// </summary>
        /// <param name="nettoPrice">Nettobetrag (Betrag ohne Mwst.)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>Bruttobetrag (Betrag mit Mwst.)</returns>
        public static Money GetBruttoPrice(Money nettoPrice, decimal mwstSatz)
        {
            Money bruttoPrice = null;

            if (nettoPrice != null)
            {
                bruttoPrice = new Money(nettoPrice.Amount*(100 + mwstSatz)/100);
            }

            return bruttoPrice;
        }

        /// <summary>
        /// Berechnet den Bruttobetrag (Betrag mit Mwst.)
        /// </summary>
        /// <param name="nettoPrice">Nettobetrag (Betrag ohne Mwst.)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>Bruttobetrag (Betrag mit Mwst.)</returns>
        public static decimal? GetBruttoPrice(decimal? nettoPrice, decimal mwstSatz)
        {
            decimal? bruttoPrice = null;

            if (nettoPrice.HasValue)
            {
                Money brutto = GetBruttoPrice(new Money(nettoPrice.Value), mwstSatz);
                if (brutto != null)
                    bruttoPrice = brutto.Amount;
            }

            return bruttoPrice;
        }

        /// <summary>
        /// Berechnet den Mehrwertsteuerbetrag vom Bruttobetrag
        /// </summary>
        /// <param name="bruttoPrice">Bruttobetrag (Betrag mit Mwst.)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>Mehrwertsteuerbetrag</returns>
        public static Money GetMwstBetragBrutto(Money bruttoPrice, decimal mwstSatz)
        {
            Money mwstBetrag = null;

            if (bruttoPrice != null)
            {
                mwstBetrag = new Money(bruttoPrice.Amount/(100 + mwstSatz)*mwstSatz);
            }

            return mwstBetrag;
        }

        /// <summary>
        /// Berechnet den Mehrwertsteuerbetrag vom Bruttobetrag
        /// </summary>
        /// <param name="bruttoPrice">Bruttobetrag (Betrag mit Mwst.)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>Mehrwertsteuerbetrag</returns>
        public static decimal? GetMwstBetragBrutto(decimal? bruttoPrice, decimal mwstSatz)
        {
            decimal? mwstBetrag = null;

            if (bruttoPrice.HasValue)
            {
                Money mwst = GetMwstBetragBrutto(new Money(bruttoPrice.Value), mwstSatz);
                if (mwst != null)
                    mwstBetrag = mwst.Amount;
            }

            return mwstBetrag;
        }

        /// <summary>
        /// Berechnet den Mehrwertsteuerbetrag vom Nettobetrag
        /// </summary>
        /// <param name="nettoPrice">Nettobetrag (Betrag ohne Mwst.)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>Mehrwertsteuerbetrag</returns>
        public static Money GetMwstBetragNetto(Money nettoPrice, decimal mwstSatz)
        {
            Money mwstBetrag = null;

            if (nettoPrice != null)
            {
                mwstBetrag = new Money((nettoPrice.Amount*(100 + mwstSatz)/100) - nettoPrice.Amount);
            }

            return mwstBetrag;
        }

        /// <summary>
        /// Berechnet den Mehrwertsteuerbetrag vom Nettobetrag
        /// </summary>
        /// <param name="nettoPrice">Nettobetrag (Betrag ohne Mwst.)</param>
        /// <param name="mwstSatz">Mwst.-Satz</param>
        /// <returns>Mehrwertsteuerbetrag</returns>
        public static decimal? GetMwstBetragNetto(decimal? nettoPrice, decimal mwstSatz)
        {
            decimal? mwstBetrag = null;

            if (nettoPrice.HasValue)
            {
                Money mwst = GetMwstBetragNetto(new Money(nettoPrice.Value), mwstSatz);
                if (mwst != null)
                    mwstBetrag = mwst.Amount;
            }

            return mwstBetrag;
        }
    }
}