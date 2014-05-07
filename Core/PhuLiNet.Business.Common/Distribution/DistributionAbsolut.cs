using System;
using System.Collections.Generic;
using System.Linq;

namespace PhuLiNet.Business.Common.Distribution
{
    public class DistributionAbsolut<T> : DistributionBase<T>
    {
        public DistributionAbsolut(IEnumerable<T> lstDistribution, decimal totalQtyToDistribute, decimal? minQuantity,
            decimal? multiple) :
                base(lstDistribution, totalQtyToDistribute, minQuantity, multiple)
        {
        }

        public DistributionAbsolut(IDictionary<T, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            decimal? minQuantity, decimal? multiple) :
                base(dictDistributionFactors, totalQtyToDistribute, minQuantity, multiple)
        {
        }

        public DistributionAbsolut(IEnumerable<T> lstDistribution, decimal totalQtyToDistribute, int roundToDigits,
            decimal? minQuantity, decimal? multiple) :
                base(lstDistribution, totalQtyToDistribute, roundToDigits, minQuantity, multiple)
        {
        }

        public DistributionAbsolut(IDictionary<T, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            int roundToDigits, decimal? minQuantity, decimal? multiple) :
                base(dictDistributionFactors, totalQtyToDistribute, roundToDigits, minQuantity, multiple)
        {
        }

        protected override void Distribute()
        {
            //------------------Absteigend nach Menge sortieren-------------------//
            var distributionElements = GetSorted();

            var factorTotal = distributionElements.Sum(distributionElement => distributionElement.DistributionFactor);
            if (factorTotal == 0) return;

            //-------------------Mengen zuordnen bis Max-menge--------------------//
            var qtyDistributedSoFar = 0m;
            while (qtyDistributedSoFar <= TotalQtyToDistribute)
            {
                foreach (var distributionElement in distributionElements)
                {
                    distributionElement.DistributedQuantity += distributionElement.DistributionFactor;
                    qtyDistributedSoFar += distributionElement.DistributionFactor;
                }
            }

            //---------------Zurueck-Kopieren in Original-Dictionary--------------//
            foreach (var de in distributionElements)
            {
                DictDistribution[de.ElementId].DistributedQuantity = Math.Round(de.DistributedQuantity, RoundToDigits);
            }
        }

        private DistributionElement<T>[] GetSorted()
        {
            var dictSorted = DictDistribution.Values.OrderByDescending(p => p.DistributionFactor);
            var enumDe = dictSorted.AsEnumerable();
            var distributionElements = enumDe as DistributionElement<T>[] ?? enumDe.ToArray();

            return distributionElements;
        }
    }

    [Obsolete("use DistributionAbsolut<T>")]
    public class DistributionAbsolut : DistributionBase
    {
        #region Constructors

        public DistributionAbsolut(IEnumerable<string> lstDistribution, decimal totalQtyToDistribute,
            decimal? minQuantity, decimal? multiple) :
                base(lstDistribution, totalQtyToDistribute, minQuantity, multiple)
        {
        }

        public DistributionAbsolut(IDictionary<string, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            decimal? minQuantity, decimal? multiple) :
                base(dictDistributionFactors, totalQtyToDistribute, minQuantity, multiple)
        {
        }

        public DistributionAbsolut(IEnumerable<string> lstDistribution, decimal totalQtyToDistribute, int roundToDigits,
            decimal? minQuantity, decimal? multiple) :
                base(lstDistribution, totalQtyToDistribute, roundToDigits, minQuantity, multiple)
        {
        }

        public DistributionAbsolut(IDictionary<string, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            int roundToDigits, decimal? minQuantity, decimal? multiple) :
                base(dictDistributionFactors, totalQtyToDistribute, roundToDigits, minQuantity, multiple)
        {
        }

        #endregion

        #region IDistributable Members

        protected override void Distribute()
        {
            //------------------Absteigend nach Menge sortieren-------------------//
            var dictSorted = DictDistribution.Values.OrderByDescending(p => p.DistributionFactor);
            var enumDe = dictSorted.AsEnumerable();
            var distributionElements = enumDe as DistributionElement<string>[] ?? enumDe.ToArray();

            if (distributionElements.Sum(distributionElement => distributionElement.DistributionFactor) == 0) return;

            //-------------------Mengen zuordnen bis Max-menge--------------------//
            var qtyDistributedSoFar = 0m;
            while (qtyDistributedSoFar <= TotalQtyToDistribute)
            {
                foreach (var distributionElement in distributionElements)
                {
                    distributionElement.DistributedQuantity += distributionElement.DistributionFactor;
                    qtyDistributedSoFar += distributionElement.DistributionFactor;
                }
            }

            //---------------Zurueck-Kopieren in Original-Dictionary--------------//

            foreach (var de in distributionElements)
            {
                DictDistribution[de.ElementId].DistributedQuantity = de.DistributedQuantity;
            }
        }

        #endregion
    }
}