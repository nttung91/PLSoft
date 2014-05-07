namespace PhuLiNet.Business.Common.Barcodes
{
    public class BarcodeType
    {
        public EBarcodeTypes Type { get; set; }

        public int Length { get; set; }

        public int MinLength { get; set; }

        public string Descr { get; set; }

        public string ShortDescr { get; set; }

        public string BarcodeFormat { get; set; }

        public int SeqFormatPrio { get; set; }

        public int SeqBestBarcode { get; set; }
    }
}