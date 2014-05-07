using System;
using System.Diagnostics;

namespace PhuLiNet.Business.Common.Calculation
{
    public static class MoneyRounder
    {
        public static decimal RoundToPayableAmount(decimal amount, decimal minimalPayableAmount)
        {
            Debug.Assert(minimalPayableAmount > 0, "minimalPayableAmount muss >0 sein");

            decimal helper = minimalPayableAmount*100;
            decimal result = Math.Round(amount/helper, 2, MidpointRounding.AwayFromZero)*helper;

            return result;
        }
    }
}