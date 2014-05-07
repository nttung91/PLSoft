using System;
using System.ComponentModel;

namespace PhuLiNet.Business.Common.Delivery
{
    public enum ELocationLevel
    {

        [Description("HAUS")]
        Haus,
        [Description("RAYON")]
        Rayon,
        [Description("LAGER")]
        Lager,
        [Description("ZENTRALE")]
        Zentrale
    }
}
