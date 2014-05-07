namespace PhuLiNet.Business.Common.Barcodes
{
    public interface IBarcode
    {
        EBarcodeTypes BarcodeType { get; }

        /// <summary>
        /// Barcode Typ Schlüssel in Datenbank
        /// </summary>
        string BarcodeTypeId { get; }

        /// <summary>
        /// Überschreiben der Anzeige des Barcode Typs 
        /// Sonderfall: Anzeige eines speziellen Barcode-Typs 'BARCODE' (Standardbarcode)
        /// auf der Etikettenbestellung
        /// </summary>
        string BarcodeTypeDisplay { get; set; }

        string BarcodeValue { get; set; }
        bool BestlFlag { get; set; }
    }
}