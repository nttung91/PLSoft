using System;
using System.ComponentModel;

namespace PhuLiNet.Business.Common.Delivery
{
    public enum ELfaIds
    {
        [Description("S")]
        Stock,
        [Description("D")]
        Direct,
        [Description("T")]
        Transit,
        [Description("R")]
        Repartition,
        [Description("C")]
        Crossdocking
    }
}
