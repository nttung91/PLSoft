using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PhuLiNet.Business.Common.Calculation;

namespace PhuLiNet.Business.Common.Distribution
{
    public class DistributionBase<T> : IDistributable<T>
    {
        protected IDictionary<T, DistributionElement<T>> DictDistribution;
        protected decimal FactorSum = 0.0M;
        protected decimal TotalQtyToDistribute;
        protected decimal? MinQuantity;
        protected decimal? Multiple;

        protected int RoundToDigits = 0;

        protected decimal TotalQtyCalculated
        {
            get { return DictDistribution.Keys.Sum(s => DictDistribution[s].DistributedQuantity); }
        }

        public DistributionBase(IEnumerable<T> lstDistribution, decimal totalQtyToDistribute, decimal? minQuantity,
            decimal? multiple)
        {
            InitializeDistributionDictionary(lstDistribution, true);
            TotalQtyToDistribute = totalQtyToDistribute;
            MinQuantity = minQuantity;
            Multiple = multiple;
        }

        public DistributionBase(IDictionary<T, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            decimal? minQuantity, decimal? multiple)
        {
            InitializeDistributionDictionary(dictDistributionFactors, true);
            TotalQtyToDistribute = totalQtyToDistribute;
            MinQuantity = minQuantity;
            Multiple = multiple;
        }

        public DistributionBase(IEnumerable<T> lstDistribution, decimal totalQtyToDistribute, int roundToDigits,
            decimal? minQuantity, decimal? multiple) :
                this(lstDistribution, totalQtyToDistribute, minQuantity, multiple)
        {
            RoundToDigits = roundToDigits;
        }

        public DistributionBase(IDictionary<T, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            int roundToDigits, decimal? minQuantity, decimal? multiple) :
                this(dictDistributionFactors, totalQtyToDistribute, minQuantity, multiple)
        {
            RoundToDigits = roundToDigits;
        }

        protected virtual void Distribute()
        {
            ComputeFactorSum();

            Debug.Assert(FactorSum != 0, "Achtung: Verteilung würde ZeroDivideException erzeugen !");
            if (FactorSum == 0) return;

            foreach (var s in DictDistribution.Keys)
            {
                var coeff = DictDistribution[s].DistributionFactor/FactorSum;
                var distribQty = coeff*TotalQtyToDistribute;
                distribQty = Math.Round(distribQty, RoundToDigits);

                DictDistribution[s].DistributedQuantity = distribQty;
            }
        }

        public IDictionary<T, decimal> GetDistributedQuantities()
        {
            Distribute();
            RoundToMinQtyAndMultiple();

            return DictDistribution.Keys.ToDictionary(s => s, s => DictDistribution[s].DistributedQuantity);
        }

        private void InitializeDistributionDictionary(IEnumerable<T> lstDistribution, bool renew)
        {
            if (DictDistribution != null && !renew) return;

            DictDistribution = new Dictionary<T, DistributionElement<T>>();

            foreach (var elem in lstDistribution)
            {
                var de = new DistributionElement<T>(elem);
                DictDistribution.Add(elem, de);
            }
        }

        private void InitializeDistributionDictionary(IDictionary<T, decimal> dictDistribution, bool renew)
        {
            if (DictDistribution != null && !renew) return;

            DictDistribution = new Dictionary<T, DistributionElement<T>>();

            foreach (var elem in dictDistribution.Keys)
            {
                var de = new DistributionElement<T>(elem, dictDistribution[elem]);
                DictDistribution.Add(elem, de);
            }
        }

        private void ComputeFactorSum()
        {
            FactorSum = 0.0M;

            foreach (var s in DictDistribution.Keys)
            {
                FactorSum += DictDistribution[s].DistributionFactor;
            }
        }

        private void RoundToMinQtyAndMultiple()
        {
            if (DictDistribution == null || DictDistribution.Count == 0) return;

            var totalDistributed = DictDistribution.Keys.Sum(s => DictDistribution[s].DistributedQuantity);

            var difference = GetRoundingDifference(totalDistributed);

            DictDistribution.Values.ElementAt(0).DistributedQuantity += difference;
        }

        private decimal GetRoundingDifference(decimal quantity)
        {
            var minMultiQtyRounder = new MinMultiQtyRounder(MinQuantity, Multiple, quantity);

            decimal result;
            if (minMultiQtyRounder.MoreThanMinimum)
            {
                if (Multiple == null) return 0;
                result = minMultiQtyRounder.DiffToMultiple;
            }
            else
            {
                if (MinQuantity == null) return 0;
                result = minMultiQtyRounder.DiffToMinimum;
            }

            return result;
        }
    }

    [Obsolete("use DistributionBase<T>")]
    public class DistributionBase : IDistributable
    {
        protected IDictionary<string, DistributionElement<string>> DictDistribution;
        protected decimal FactorSum = 0.0M;
        protected decimal TotalQtyToDistribute;
        protected decimal? MinQuantity;
        protected decimal? Multiple;

        protected int RoundToDigits = 0;

        protected decimal TotalQtyCalculated
        {
            get { return DictDistribution.Keys.Sum(s => DictDistribution[s].DistributedQuantity); }
        }

        public DistributionBase(IEnumerable<string> lstDistribution, decimal totalQtyToDistribute, decimal? minQuantity,
            decimal? multiple)
        {
            InitializeDistributionDictionary(lstDistribution, true);
            TotalQtyToDistribute = totalQtyToDistribute;
            MinQuantity = minQuantity;
            Multiple = multiple;
        }

        public DistributionBase(IDictionary<string, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            decimal? minQuantity, decimal? multiple)
        {
            InitializeDistributionDictionary(dictDistributionFactors, true);
            TotalQtyToDistribute = totalQtyToDistribute;
            MinQuantity = minQuantity;
            Multiple = multiple;
        }

        public DistributionBase(IEnumerable<string> lstDistribution, decimal totalQtyToDistribute, int roundToDigits,
            decimal? minQuantity, decimal? multiple) :
                this(lstDistribution, totalQtyToDistribute, minQuantity, multiple)
        {
            RoundToDigits = roundToDigits;
        }

        public DistributionBase(IDictionary<string, decimal> dictDistributionFactors, decimal totalQtyToDistribute,
            int roundToDigits, decimal? minQuantity, decimal? multiple) :
                this(dictDistributionFactors, totalQtyToDistribute, minQuantity, multiple)
        {
            RoundToDigits = roundToDigits;
        }

        protected virtual void Distribute()
        {
            ComputeFactorSum();

            Debug.Assert(FactorSum != 0, "Achtung: Verteilung würde ZeroDivideException erzeugen !");
            if (FactorSum == 0) return;

            foreach (var s in DictDistribution.Keys)
            {
                var coeff = DictDistribution[s].DistributionFactor/FactorSum;
                var distribQty = coeff*TotalQtyToDistribute;
                distribQty = Math.Round(distribQty, RoundToDigits);

                DictDistribution[s].DistributedQuantity = distribQty;
            }
        }

        public IDictionary<string, decimal> GetDistributedQuantities()
        {
            Distribute();
            RoundToMinQtyAndMultiple();

            return DictDistribution.Keys.ToDictionary(s => s, s => DictDistribution[s].DistributedQuantity);
        }

        private void InitializeDistributionDictionary(IEnumerable<string> lstDistribution, bool renew)
        {
            if (DictDistribution != null && !renew) return;

            DictDistribution = new Dictionary<string, DistributionElement<string>>();

            foreach (var elem in lstDistribution)
            {
                var de = new DistributionElement<string>(elem);
                DictDistribution.Add(elem, de);
            }
        }

        private void InitializeDistributionDictionary(IDictionary<string, decimal> dictDistribution, bool renew)
        {
            if (DictDistribution != null && !renew) return;

            DictDistribution = new Dictionary<string, DistributionElement<string>>();

            foreach (var elem in dictDistribution.Keys)
            {
                var de = new DistributionElement<string>(elem, dictDistribution[elem]);
                DictDistribution.Add(elem, de);
            }
        }

        private void ComputeFactorSum()
        {
            FactorSum = 0.0M;

            foreach (var s in DictDistribution.Keys)
            {
                FactorSum += DictDistribution[s].DistributionFactor;
            }
        }

        private void RoundToMinQtyAndMultiple()
        {
            if (DictDistribution == null || DictDistribution.Count == 0) return;

            var qtyTotal = DictDistribution.Keys.Sum(s => DictDistribution[s].DistributedQuantity);

            var qtyToRoundTo = GetQtyToRoundTo(qtyTotal);
            var increment = 0;

            while (increment < qtyToRoundTo)
            {
                DictDistribution.Values.ElementAt(0).DistributedQuantity++;
                increment++;
            }
        }

        private decimal GetQtyToRoundTo(decimal totalQtySoFar)
        {
            var rounder = new MinMultiQtyRounder(MinQuantity, Multiple, totalQtySoFar);

            decimal qtyToRoundTo;
            if (rounder.MoreThanMinimum == false)
            {
                if (MinQuantity == null) return 0;
                qtyToRoundTo = rounder.DiffToMinimum;
            }
            else
            {
                if (Multiple == null) return 0;
                qtyToRoundTo = rounder.DiffToMultiple;
            }

            return qtyToRoundTo;
        }
    }
}