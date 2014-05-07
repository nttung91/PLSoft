using System.ComponentModel;

namespace PhuLiNet.Business.Common.Barcodes
{
    public enum EBarcodeTypes
    {
        Undefined,
        [Description("EAN-13")]
        EAN_13,
        [Description("EAN-21")]
        EAN_21,
        [Description("EAN-22")]
        EAN_22,
        [Description("EAN-28")]
        EAN_28,
        [Description("EAN-29")]
        EAN_29,
        [Description("EAN-8")]
        EAN_8,
        [Description("GTIN-14")]
        GTIN_14,
        [Description("IC-14")]
        IC_14,
        [Description("MAN-13")]
        MAN_13,
        [Description("PHARMACODE")]
        PHARMACODE,
        [Description("PLU-1")]
        PLU_1,
        [Description("PLU-2")]
        PLU_2,
        [Description("PLU-3")]
        PLU_3,
        [Description("UPC-12")]
        UPC_12,
        [Description("UPC-A")]
        UPC_A,
        [Description("UPC-E")]
        UPC_E,
    }
}