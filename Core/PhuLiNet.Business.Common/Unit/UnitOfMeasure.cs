using System;

namespace PhuLiNet.Business.Common.Unit
{
    [Serializable]
    public struct UnitOfMeasure
    {
        public string UomId;
        public int DecimalPlaces;
        public string ShortDescr;
        public string Descr;

        public UnitOfMeasure(string uomId, int decimalPlaces) : this(uomId, decimalPlaces, null, null)
        {
        }

        public UnitOfMeasure(string uomId, int decimalPlaces, string shortDescr, string descr)
        {
            UomId = uomId;
            DecimalPlaces = decimalPlaces;
            ShortDescr = shortDescr;
            Descr = descr;
        }

        public override string ToString()
        {
            return UomId;
        }
    }
}