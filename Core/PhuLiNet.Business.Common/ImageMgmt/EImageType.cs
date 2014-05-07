using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PhuLiNet.Business.Common.ImageMgmt
{
    public enum EImageType
    {
        [Description("BILD")]
        Bild,
        [Description("BILD-TN")]
        BildThumbnail,
        [Description("TN")]
        Thumbnail,
        [Description("IM")]
        Image,
        [Description("IMAGES")]
        Images
    }
}
