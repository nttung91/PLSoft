using System;
using System.Collections.Generic;

namespace PhuLiNet.Business.Common.Distribution
{
    public class DistributionRelativ<T> : DistributionBase<T>
    {
        public DistributionRelativ(IEnumerable<T> lstDistribution, decimal totalQtyToDistribute, decimal? minQuantity,
            decimal? multiple) :
                base(lstDistribution, totalQtyToDistribute, minQuantity, multiple)
        {
        }

        public DistributionRelativ(IDictionary<T, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            decimal? minQuantity, decimal? multiple) :
                base(dictDistributionFactors, totalQtyToDistribute, minQuantity, multiple)
        {
        }

        public DistributionRelativ(IEnumerable<T> lstDistribution, decimal totalQtyToDistribute, int roundToDigits,
            decimal? minQuantity, decimal? multiple) :
                base(lstDistribution, totalQtyToDistribute, roundToDigits, minQuantity, multiple)
        {
        }

        public DistributionRelativ(IDictionary<T, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            int roundToDigits, decimal? minQuantity, decimal? multiple) :
                base(dictDistributionFactors, totalQtyToDistribute, roundToDigits, minQuantity, multiple)
        {
        }

        protected override void Distribute()
        {
            foreach (var dictDistribution in DictDistribution)
            {
                var distribQty = TotalQtyToDistribute*(dictDistribution.Value.DistributionFactor/100);
                dictDistribution.Value.DistributedQuantity = Math.Round(distribQty, RoundToDigits);
            }
        }
    }

    [Obsolete("use DistributionRelativ<T>")]
    public class DistributionRelativ : DistributionBase
    {
        public DistributionRelativ(IEnumerable<string> lstDistribution, decimal totalQtyToDistribute,
            decimal? minQuantity, decimal? multiple) :
                base(lstDistribution, totalQtyToDistribute, minQuantity, multiple)
        {
        }

        public DistributionRelativ(IDictionary<string, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            decimal? minQuantity, decimal? multiple) :
                base(dictDistributionFactors, totalQtyToDistribute, minQuantity, multiple)
        {
        }

        public DistributionRelativ(IEnumerable<string> lstDistribution, decimal totalQtyToDistribute, int roundToDigits,
            decimal? minQuantity, decimal? multiple) :
                base(lstDistribution, totalQtyToDistribute, roundToDigits, minQuantity, multiple)
        {
        }

        public DistributionRelativ(IDictionary<string, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            int roundToDigits, decimal? minQuantity, decimal? multiple) :
                base(dictDistributionFactors, totalQtyToDistribute, roundToDigits, minQuantity, multiple)
        {
        }

        protected override void Distribute()
        {
            foreach (var distribution in DictDistribution)
            {
                var distribQty = TotalQtyToDistribute*(distribution.Value.DistributionFactor/100);
                distribution.Value.DistributedQuantity = Math.Round(distribQty, RoundToDigits);
            }
        }
    }
}