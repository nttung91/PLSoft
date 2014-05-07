using System;
using Technical.Utilities.Helpers;

namespace PhuLiNet.Business.Common.Barcodes
{
    [Serializable()]
    public class Barcode : IBarcode, IComparable, IComparable<Barcode>, IEquatable<Barcode>, ICloneable
    {
        private EBarcodeTypes _type;
        private string _barcodeTypeDisplay;
        private string _barcodeValue;
        private bool _bestlFlag;

        public Barcode()
        {
        }

        public EBarcodeTypes BarcodeType
        {
            get { return _type; }
            set { _type = value; }
        }

        public string BarcodeTypeId
        {
            get { return EnumHelper.GetEnumDescription(_type); }
        }

        public string BarcodeTypeDisplay
        {
            get
            {
                if (_barcodeTypeDisplay == null)
                {
                    _barcodeTypeDisplay = EnumHelper.GetEnumDescription(_type);
                }
                return _barcodeTypeDisplay;
            }
            set { _barcodeTypeDisplay = value; }
        }

        public string BarcodeValue
        {
            get { return _barcodeValue; }
            set { _barcodeValue = value; }
        }

        public bool BestlFlag
        {
            get { return _bestlFlag; }
            set { _bestlFlag = value; }
        }

        public override string ToString()
        {
            return BarcodeValue;
        }

        public override int GetHashCode()
        {
            return _barcodeValue.GetHashCode() ^ _type.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is Barcode))
            {
                throw new ArgumentException("Argument must be barcode");
            }
            return CompareTo((Barcode) obj);
        }

        public int CompareTo(Barcode other)
        {
            int compare = 0;

            if (BarcodeType != other.BarcodeType)
                return BarcodeType.CompareTo(other.BarcodeType);
            if (BarcodeValue != other.BarcodeValue)
                return BarcodeValue.CompareTo(other.BarcodeValue);

            return compare;
        }

        public override bool Equals(object obj)
        {
            return (obj is Barcode) && Equals((Barcode) obj);
        }

        public bool Equals(Barcode other)
        {
            if (ReferenceEquals(other, null))
                return false;

            return ((BarcodeType == other.BarcodeType) && (_barcodeValue == other._barcodeValue));
        }

        public static bool operator ==(Barcode first, Barcode second)
        {
            if (ReferenceEquals(first, second))
                return true;

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                return false;

            return (first.Equals(second));
        }

        public static bool operator !=(Barcode first, Barcode second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return false;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return true;
            else
                return !first.Equals(second);
        }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return GetClone();
        }

        public Barcode Clone()
        {
            return GetClone();
        }

        private Barcode GetClone()
        {
            var newBarcode = new Barcode();
            newBarcode.BarcodeType = _type;
            newBarcode.BarcodeTypeDisplay = _barcodeTypeDisplay;
            newBarcode.BarcodeValue = _barcodeValue;
            newBarcode.BestlFlag = _bestlFlag;

            return newBarcode;
        }

        #endregion
    }
}