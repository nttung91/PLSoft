using System;
using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Calculation
{
    /// <summary>
    /// Berechnet den Tdm-Durchschnitt gewichtet nach dem Bestellwert
    /// </summary>
    public class TdmAverage
    {
        private decimal? _averageTdm = null;
        private decimal _qtyVpTdmSum = 0m;
        private decimal _qtyVpSum = 0m;

        public TdmAverage()
        {
        }

        /// <summary>
        /// Ergänzt ein Tdm/Quantity Wertepaar
        /// </summary>
        /// <param name="totalQuantity"></param>
        /// <param name="vpPrice"></param>
        /// <param name="tdm"></param>
        public void AddTdm(Quantity totalQuantity, Money vpPrice, decimal? tdm)
        {
            if (totalQuantity != null && totalQuantity.Value > 0m && vpPrice != null && vpPrice.Amount > 0m &&
                tdm.HasValue)
            {
                _qtyVpTdmSum += totalQuantity.ValueRounded*vpPrice.AmountRounded*tdm.Value;
                _qtyVpSum += totalQuantity.ValueRounded*vpPrice.AmountRounded;
            }
        }

        /// <summary>
        /// Ergänzt ein Tdm/Quantity Wertepaar
        /// </summary>
        /// <param name="totalQuantity"></param>
        /// <param name="vpPrice"></param>
        /// <param name="tdm"></param>
        public void AddTdm(decimal? totalQuantity, decimal? vpPrice, decimal? tdm)
        {
            if (totalQuantity.HasValue && vpPrice.HasValue && tdm.HasValue)
                AddTdm(new Quantity(totalQuantity.Value), new Money(vpPrice.Value), tdm);
        }

        /// <summary>
        /// Ergänzt ein Tdm/Bestellwert Wertepaar
        /// </summary>
        /// <param name="vpTotalAmount"></param>
        /// <param name="tdm"></param>
        public void AddTdm(Money vpTotalAmount, decimal? tdm)
        {
            if (vpTotalAmount != null && vpTotalAmount.Amount > 0m && tdm.HasValue)
            {
                _qtyVpTdmSum += vpTotalAmount.AmountRounded*tdm.Value;
                _qtyVpSum += vpTotalAmount.AmountRounded;
            }
        }

        /// <summary>
        /// Ergänzt ein Tdm/Bestellwert Wertepaar
        /// </summary>
        /// <param name="vpTotalAmount"></param>
        /// <param name="tdm"></param>
        public void AddTdm(decimal? vpTotalAmount, decimal? tdm)
        {
            if (vpTotalAmount.HasValue)
                AddTdm(new Money(vpTotalAmount.Value), tdm);
        }

        /// <summary>
        /// Gibt den Durchschnitts Tdm-Wert zurück
        /// </summary>
        /// <returns></returns>
        public decimal? AverageTdm()
        {
            if (_qtyVpSum > 0)
                _averageTdm = _qtyVpTdmSum/_qtyVpSum;

            if (_averageTdm.HasValue)
                _averageTdm = Math.Round(_averageTdm.Value, 2);

            return _averageTdm;
        }

        /// <summary>
        /// Löscht alle bisherigen Werte
        /// </summary>
        public void Clear()
        {
            _averageTdm = null;
            _qtyVpSum = 0m;
            _qtyVpTdmSum = 0m;
        }
    }
}