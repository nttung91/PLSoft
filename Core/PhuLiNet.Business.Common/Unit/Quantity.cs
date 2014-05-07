using System;
using System.Diagnostics;
using System.Globalization;

namespace PhuLiNet.Business.Common.Unit
{
    /// <summary>
    /// A class for a quantity including a unit of meassure
    /// </summary>
    [Serializable]
    public sealed class Quantity : IEquatable<Quantity>, IComparable, IComparable<Quantity>, IConvertible, ICloneable,
        IFormattable
    {
        private decimal? _maximumValue;
        private decimal? _minimumValue;
        private static string _defaultUnitOfMeasure = "STK";
        private static int _defaultDecimalDigits = 3;

        private decimal _value;
        private readonly string _unitOfMeasure;
        private string _formatString;
        private bool _formatWithUnitOfMeasure = true;
        private bool _checkUnitOfMeasure = true;

        public static string DefaultUnitOfMeasure
        {
            get { return _defaultUnitOfMeasure; }
            set { _defaultUnitOfMeasure = value; }
        }

        public static int DefaultDecimalDigits
        {
            get { return _defaultDecimalDigits; }
            set { _defaultDecimalDigits = value; }
        }

        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
        }

        public bool UnitOfMeasureCheck
        {
            get { return _checkUnitOfMeasure; }
        }

        public bool FormatWithUnitOfMeasure
        {
            get { return _formatWithUnitOfMeasure; }
            set { _formatWithUnitOfMeasure = value; }
        }

        public decimal Value
        {
            get { return _value; }
            set
            {
                _value = value;
                CheckMinValue();
                CheckMaxValue();
            }
        }

        public decimal? ValueNullable
        {
            get { return _value; }
        }

        public decimal ValueRounded
        {
            get { return Math.Round(_value, DecimalDigits); }
        }

        public decimal? MinimumValue
        {
            get { return _minimumValue; }
            set
            {
                _minimumValue = value;
                CheckMinValue();
            }
        }

        public decimal? MaximumValue
        {
            get { return _maximumValue; }
            set
            {
                _maximumValue = value;
                CheckMaxValue();
            }
        }

        public int DecimalDigits { get; set; }

        private string FormatString
        {
            get
            {
                if (_formatString == null)
                {
                    _formatString = "#,0";

                    if (DecimalDigits > 0)
                        _formatString += ".";

                    for (int i = 1; i <= DecimalDigits; i++)
                    {
                        _formatString += "0";
                    }
                }

                if (_formatWithUnitOfMeasure)
                    return String.Format("{0} \"{1}\"", _formatString, _unitOfMeasure);
                else
                    return _formatString;
            }
        }

        private void CheckDecimalPlaces()
        {
            int decimalDigits = 0;
            try
            {
                string str = _value.ToString();
                int totalLength = str.Length;
                int decPointPos = str.LastIndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) + 1;
                if (decPointPos > 0)
                    decimalDigits = totalLength - decPointPos;
            }
            catch
            {
                Debug.Assert(false, "CheckDecimalPlaces function failed");
                decimalDigits = _defaultDecimalDigits;
            }
            finally
            {
                DecimalDigits = decimalDigits;
            }
        }

        public Quantity() : this(0, DefaultUnitOfMeasure, true, DefaultDecimalDigits, false, null, null)
        {
        }

        public Quantity(decimal value)
            : this(value, DefaultUnitOfMeasure, true, DefaultDecimalDigits, false, null, null)
        {
        }

        public Quantity(decimal value, int decimalDigits)
            : this(value, DefaultUnitOfMeasure, true, decimalDigits, false, null, null)
        {
        }

        public Quantity(decimal value, string unitOfMeasure)
            : this(value, unitOfMeasure, true, DefaultDecimalDigits, false, null, null)
        {
        }

        public Quantity(decimal value, string unitOfMeasure, int decimalDigits)
            : this(value, unitOfMeasure, true, decimalDigits, false, null, null)
        {
        }

        public Quantity(decimal value, string unitOfMeasure, bool checkUnitOfMeasure)
            : this(value, unitOfMeasure, checkUnitOfMeasure, DefaultDecimalDigits, false, null, null)
        {
        }

        public Quantity(decimal value, string unitOfMeasure, bool checkUnitOfMeasure, int decimalDigits,
            bool calcDecimalPlacesFromValue)
            : this(value, unitOfMeasure, checkUnitOfMeasure, decimalDigits, calcDecimalPlacesFromValue, null, null)
        {
        }

        public Quantity(decimal value, string unitOfMeasure, bool checkUnitOfMeasure, int decimalDigits,
            bool calcDecimalPlacesFromValue, decimal? minimumValue, decimal? maximumValue)
        {
            Debug.Assert(unitOfMeasure != null, "UnitOfMeasure is null");

            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
            _value = value;
            _unitOfMeasure = unitOfMeasure;
            _checkUnitOfMeasure = checkUnitOfMeasure;
            DecimalDigits = decimalDigits;

            if (calcDecimalPlacesFromValue)
                CheckDecimalPlaces();

            CheckMinValue();
            CheckMaxValue();
        }

        public Quantity(long value)
            : this(Convert.ToDecimal(value), DefaultUnitOfMeasure, true, DefaultDecimalDigits, false, null, null)
        {
        }

        public Quantity(long value, int decimalDigits)
            : this(Convert.ToDecimal(value), DefaultUnitOfMeasure, true, decimalDigits, false, null, null)
        {
        }

        public Quantity(long value, string unitOfMeasure)
            : this(Convert.ToDecimal(value), unitOfMeasure, true, DefaultDecimalDigits, false, null, null)
        {
        }

        public Quantity(long value, string unitOfMeasure, bool checkUnitOfMeasure)
            : this(Convert.ToDecimal(value), unitOfMeasure, checkUnitOfMeasure, DefaultDecimalDigits, false, null, null)
        {
        }

        public Quantity(long value, string unitOfMeasure, bool checkUnitOfMeasure, int decimalDigits,
            bool calcDecimalPlacesFromValue)
            : this(
                (Convert.ToDecimal(value)), unitOfMeasure, checkUnitOfMeasure, decimalDigits, calcDecimalPlacesFromValue,
                null, null)
        {
        }

        public Quantity(long value, string unitOfMeasure, bool checkUnitOfMeasure, int decimalDigits,
            bool calcDecimalPlacesFromValue, decimal? minimumValue, decimal? maximumValue)
            : this(
                (Convert.ToDecimal(value)), unitOfMeasure, checkUnitOfMeasure, decimalDigits, calcDecimalPlacesFromValue,
                minimumValue, maximumValue)
        {
        }

        private void CheckMinValue()
        {
            if (MinimumValue.HasValue)
            {
                if (_value < MinimumValue.Value)
                {
                    Debug.Assert(false, "Value is smaller than minimum value. Value will be corrected.");
                    _value = MinimumValue.Value;
                }
            }
        }

        private void CheckMaxValue()
        {
            if (MaximumValue.HasValue)
            {
                if (_value > MaximumValue.Value)
                {
                    Debug.Assert(false, "Value is greater than maximum value. Value will be corrected.");
                    _value = MaximumValue.Value;
                }
            }
        }

        public static bool operator >(Quantity first, Quantity second)
        {
            AssertSameUnitOfMeasure(first, second);
            return first._value > second._value;
        }

        public static bool operator >=(Quantity first, Quantity second)
        {
            AssertSameUnitOfMeasure(first, second);
            return first._value >= second._value;
        }

        public static bool operator <=(Quantity first, Quantity second)
        {
            AssertSameUnitOfMeasure(first, second);
            return first._value <= second._value;
        }

        public static bool operator <(Quantity first, Quantity second)
        {
            AssertSameUnitOfMeasure(first, second);
            return first._value < second._value;
        }

        public static Quantity operator +(Quantity first, Quantity second)
        {
            AssertSameUnitOfMeasure(first, second);

            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return null;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return new Quantity(second.Value, second.UnitOfMeasure, second.UnitOfMeasureCheck, second.DecimalDigits,
                    false, second.MinimumValue, second.MaximumValue);
            else if (!ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return new Quantity(first.Value, first.UnitOfMeasure, first.UnitOfMeasureCheck, first.DecimalDigits,
                    false, first.MinimumValue, first.MaximumValue);
            else
            {
                string uom;
                if (first.UnitOfMeasure != second.UnitOfMeasure)
                    uom = string.Empty;
                else
                    uom = first.UnitOfMeasure;

                return new Quantity(first.Value + second.Value, uom, first.UnitOfMeasureCheck, first.DecimalDigits,
                    false, first.MinimumValue, first.MaximumValue);
            }
        }

        public static Quantity operator *(Quantity first, Quantity second)
        {
            AssertSameUnitOfMeasure(first, second);

            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return null;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return new Quantity(second.Value, second.UnitOfMeasure, second.UnitOfMeasureCheck, second.DecimalDigits,
                    false, second.MinimumValue, second.MaximumValue);
            else if (!ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return new Quantity(first.Value, first.UnitOfMeasure, first.UnitOfMeasureCheck, first.DecimalDigits,
                    false, first.MinimumValue, first.MaximumValue);
            else
            {
                string uom;
                if (first.UnitOfMeasure != second.UnitOfMeasure)
                    uom = string.Empty;
                else
                    uom = first.UnitOfMeasure;

                return new Quantity(first.Value*second.Value, uom, first.UnitOfMeasureCheck, first.DecimalDigits, false,
                    first.MinimumValue, first.MaximumValue);
            }
        }

        public static Quantity Add(Quantity first, Quantity second)
        {
            return first + second;
        }

        public static Quantity operator -(Quantity first, Quantity second)
        {
            AssertSameUnitOfMeasure(first, second);

            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return null;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return new Quantity(second.Value, second.UnitOfMeasure, second.UnitOfMeasureCheck, second.DecimalDigits,
                    false, second.MinimumValue, second.MaximumValue);
            else if (!ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return new Quantity(first.Value, first.UnitOfMeasure, first.UnitOfMeasureCheck, first.DecimalDigits,
                    false, first.MinimumValue, first.MaximumValue);
            else
                return new Quantity(first.Value - second.Value, first.UnitOfMeasure, first.UnitOfMeasureCheck,
                    first.DecimalDigits, false, first.MinimumValue, first.MaximumValue);
        }

        public static Quantity Subtract(Quantity first, Quantity second)
        {
            return first - second;
        }

        public static bool operator ==(Quantity first, Quantity second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            return (first.UnitOfMeasure == second.UnitOfMeasure && first.Value == second.Value &&
                    first.DecimalDigits == second.DecimalDigits);
        }

        public static bool operator !=(Quantity first, Quantity second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return false;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return true;
            else
                return !first.Equals(second);
        }

        public static Quantity operator *(Quantity quantity, decimal value)
        {
            if (quantity == null) throw new ArgumentNullException("quantity");
            return new Quantity(quantity.Value*value, quantity.UnitOfMeasure, quantity.UnitOfMeasureCheck,
                quantity.DecimalDigits, false, quantity.MinimumValue, quantity.MaximumValue);
        }

        public static Quantity Multiply(Quantity quantity, decimal value)
        {
            return quantity*value;
        }

        public static Quantity operator /(Quantity quantity, decimal value)
        {
            if (quantity == null) throw new ArgumentNullException("quantity");
            return new Quantity(quantity.Value/value, quantity.UnitOfMeasure, quantity.UnitOfMeasureCheck,
                quantity.DecimalDigits, false, quantity.MinimumValue, quantity.MaximumValue);
        }

        public static Quantity Divide(Quantity first, decimal value)
        {
            return first/value;
        }

        public Quantity Copy()
        {
            return new Quantity(Value, _unitOfMeasure, _checkUnitOfMeasure, DecimalDigits, false, MinimumValue,
                MaximumValue);
        }

        public Quantity Clone()
        {
            return GetClone();
        }

        private Quantity GetClone()
        {
            return new Quantity(Value, _unitOfMeasure, _checkUnitOfMeasure, DecimalDigits, false, MinimumValue,
                MaximumValue);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is Quantity))
            {
                throw new ArgumentException("Argument must be Quantity");
            }
            return CompareTo((Quantity) obj);
        }

        public int CompareTo(Quantity other)
        {
            if (this < other)
            {
                return -1;
            }
            if (this > other)
            {
                return 1;
            }
            return 0;
        }

        public override string ToString()
        {
            return Value.ToString(FormatString);
        }

        public string ToString(string format)
        {
            return Value.ToString(format);
        }

        public override bool Equals(object obj)
        {
            return (obj is Quantity) && Equals((Quantity) obj);
        }

        public override int GetHashCode()
        {
            if (!string.IsNullOrEmpty(_unitOfMeasure))
                return _value.GetHashCode() ^ _unitOfMeasure.GetHashCode();
            else
                return _value.GetHashCode();
        }

        public bool Equals(Quantity other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return ((UnitOfMeasure == other.UnitOfMeasure) && (_value == other._value));
        }

        private static void AssertSameUnitOfMeasure(Quantity first, Quantity second)
        {
            if (!ReferenceEquals(first, null) && !ReferenceEquals(second, null))
            {
                if (first._checkUnitOfMeasure)
                {
                    Debug.Assert(first.UnitOfMeasure == second.UnitOfMeasure, "Quantity unit mismatch.");
                }
            }
        }

        #region IConvertible Members

        public TypeCode GetTypeCode()
        {
            return TypeCode.Decimal;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(_value, provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value, provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(_value, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(_value, provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return _value;
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_value, provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_value, provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_value, provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt32(_value, provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_value, provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_value, provider);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_value, provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_value, provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_value, provider);
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return GetClone();
        }

        #endregion

        public static Quantity TryConvert(object newValue)
        {
            return TryConvert(null, newValue);
        }

        public static Quantity TryConvert(object oldValue, object newValue)
        {
            var oldQuantity = oldValue as Quantity;
            Quantity newQuantity = null;

            if (newValue is string)
            {
                decimal valueAsDecimal;
                bool parseOk = decimal.TryParse(newValue.ToString(), out valueAsDecimal);
                if (parseOk)
                {
                    if (oldQuantity != null)
                    {
                        newQuantity = new Quantity(valueAsDecimal, oldQuantity.UnitOfMeasure,
                            oldQuantity.UnitOfMeasureCheck, oldQuantity.DecimalDigits, false, oldQuantity.MinimumValue,
                            oldQuantity.MaximumValue);
                        newQuantity.FormatWithUnitOfMeasure = oldQuantity.FormatWithUnitOfMeasure;
                    }
                    else
                        newQuantity = new Quantity(valueAsDecimal);
                }
            }
            else if (newValue is decimal)
            {
                if (oldQuantity != null)
                {
                    newQuantity = new Quantity(Convert.ToDecimal(newValue), oldQuantity.UnitOfMeasure,
                        oldQuantity.UnitOfMeasureCheck, oldQuantity.DecimalDigits, false, oldQuantity.MinimumValue,
                        oldQuantity.MaximumValue);
                    newQuantity.FormatWithUnitOfMeasure = oldQuantity.FormatWithUnitOfMeasure;
                }
                else
                    newQuantity = new Quantity(Convert.ToDecimal(newValue));
            }
            else if (newValue is Quantity)
            {
                newQuantity = (Quantity) newValue;
            }
            else if (newValue == null)
            {
                newQuantity = null;
            }

            return newQuantity;
        }

        public static Quantity Parse(string s)
        {
            return TryConvert(s);
        }

        public static bool TryParse(string s, out Quantity result)
        {
            bool ok;

            result = TryConvert(s);
            if (result != null)
                ok = true;
            else
                ok = false;

            return ok;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (!string.IsNullOrEmpty(format) && format.StartsWith("n"))
            {
                int decPlaces;
                if (int.TryParse(format.Substring(1), out decPlaces))
                    DecimalDigits = decPlaces;
                _formatWithUnitOfMeasure = false;
                _checkUnitOfMeasure = false;
                _formatString = null;
            }

            return ToString();
        }
    }
}