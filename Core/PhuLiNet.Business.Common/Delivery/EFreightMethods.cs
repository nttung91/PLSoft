using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PhuLiNet.Business.Common.Delivery
{
    public enum EFreightMethods
    {
        [Description("sea")]
        Sea,
        [Description("s/a")]
        SeaAir,
        [Description("air")]
        Air,
        [Description("land")]
        Land
    }
}
