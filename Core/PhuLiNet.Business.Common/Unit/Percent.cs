using System;
using System.Diagnostics;
using System.Globalization;

namespace PhuLiNet.Business.Common.Unit
{
    [Serializable]
    public sealed class Percent : IEquatable<Percent>, IComparable, IComparable<Percent>, ICloneable, IConvertible
    {
        private static int defaultDecimalDigits = 0;
        private static decimal defaultMinValue = 0;
        private static decimal defaultMaxValue = 100;
        private static string defaultFormatString = "%";

        private decimal? _value;
        private int _decimalDigits;
        private string _formatString = "%";
        private decimal _minimumValue;
        private decimal _maximumValue;

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
                decimalDigits = defaultDecimalDigits;
            }
            finally
            {
                _decimalDigits = decimalDigits;
            }
        }

        public Percent() : this(0, defaultDecimalDigits, false, defaultMinValue, defaultMaxValue)
        {
        }

        public Percent(decimal? value) : this(value, defaultDecimalDigits, false, defaultMinValue, defaultMaxValue)
        {
        }

        public Percent(decimal? value, int decimalDigits)
            : this(value, decimalDigits, false, defaultMinValue, defaultMaxValue)
        {
        }

        public Percent(decimal? value, int decimalDigits, bool calcDecimalPlacesFromValue)
            : this(value,
                decimalDigits, calcDecimalPlacesFromValue, defaultMinValue, defaultMaxValue)
        {
        }

        public Percent(decimal? value, int decimalDigits, bool calcDecimalPlacesFromValue, decimal minimumValue,
            decimal maximumValue)
        {
            _minimumValue = minimumValue;
            _maximumValue = maximumValue;
            _value = value;
            _decimalDigits = decimalDigits;

            if (calcDecimalPlacesFromValue)
                CheckDecimalPlaces();

            CheckMinValue();
            CheckMaxValue();
        }

        public string FormatString
        {
            get { return _formatString; }
            set { _formatString = value; }
        }

        public decimal MinimumValue
        {
            get { return _minimumValue; }
            set { _minimumValue = value; }
        }

        public decimal MaximumValue
        {
            get { return _maximumValue; }
            set { _maximumValue = value; }
        }

        public static int DefaultDecimalDigits
        {
            get { return defaultDecimalDigits; }
            set { defaultDecimalDigits = value; }
        }

        public int DecimalDigits
        {
            get { return _decimalDigits; }
            set { _decimalDigits = value; }
        }

        public decimal? Value
        {
            get { return _value.Value; }
            set
            {
                _value = value;
                CheckMinValue();
                CheckMaxValue();
            }
        }

        private void CheckMaxValue()
        {
            if (_value > _maximumValue)
            {
                Debug.Assert(false, "Value is greater than maximum value. Value will be corrected.");
                _value = _maximumValue;
            }
        }

        private void CheckMinValue()
        {
            if (_value < _minimumValue)
            {
                Debug.Assert(false, "Value is smaller than minimum value. Value will be corrected.");
                _value = _minimumValue;
            }
        }

        public static Percent operator +(Percent first, Percent second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return null;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return new Percent(second.Value, second.DecimalDigits, false, second.MinimumValue, second.MaximumValue);
            else if (!ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return new Percent(first.Value, first.DecimalDigits, false, first.MinimumValue, first.MaximumValue);
            else
            {
                return new Percent(first.Value + second.Value, first.DecimalDigits, false, first.MinimumValue,
                    first.MaximumValue);
            }
        }

        public static Percent Add(Percent first, Percent second)
        {
            return first + second;
        }

        public static Percent operator -(Percent first, Percent second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return null;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return new Percent(0 - second.Value, second.DecimalDigits, false, second.MinimumValue,
                    second.MaximumValue);
            else if (!ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return new Percent(first.Value, first.DecimalDigits, false, first.MinimumValue, first.MaximumValue);
            else
            {
                return new Percent(first.Value - second.Value, first.DecimalDigits, false, first.MinimumValue,
                    first.MaximumValue);
            }
        }

        public static Percent Substract(Percent first, Percent second)
        {
            return first - second;
        }

        public static bool operator >(Percent first, Percent second)
        {
            return first._value > second._value;
        }

        public static bool operator >=(Percent first, Percent second)
        {
            return first._value >= second._value;
        }

        public static bool operator <=(Percent first, Percent second)
        {
            return first._value <= second._value;
        }

        public static bool operator <(Percent first, Percent second)
        {
            return first._value < second._value;
        }

        public static implicit operator Percent(decimal value)
        {
            return new Percent(value, defaultDecimalDigits);
        }

        public static implicit operator Percent(long value)
        {
            return new Percent(value, defaultDecimalDigits);
        }

        public static implicit operator Percent(string value)
        {
            return TryConvert(value);
        }

        public Percent Clone()
        {
            return GetClone();
        }

        private Percent GetClone()
        {
            return new Percent(Value, _decimalDigits, false, _minimumValue, _maximumValue);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is Percent))
            {
                throw new ArgumentException("Argument must be Percent");
            }
            return CompareTo((Percent) obj);
        }

        public int CompareTo(Percent other)
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
            if (Value.HasValue)
                return Value.Value + FormatString;
            else
                return null;
        }

        public static Percent TryConvert(object newValue)
        {
            return TryConvert(null, newValue);
        }

        public static Percent TryConvert(object oldValue, object newValue)
        {
            var oldPercent = oldValue as Percent;
            Percent newPercent = null;

            if (newValue is string)
            {
                decimal valueAsDecimal;
                string stringValue;

                if (newValue.ToString().Contains(defaultFormatString))
                    stringValue = newValue.ToString().Substring(0, newValue.ToString().IndexOf(defaultFormatString) + 1);
                else
                    stringValue = newValue.ToString();

                bool parseOk = decimal.TryParse(stringValue.ToString(), out valueAsDecimal);
                if (parseOk)
                {
                    if (oldPercent != null)
                    {
                        newPercent = new Percent(valueAsDecimal, oldPercent.DecimalDigits, false,
                            oldPercent.MinimumValue, oldPercent.MaximumValue);
                    }
                    else
                        newPercent = new Percent(valueAsDecimal);
                }
            }
            else if (newValue is decimal)
            {
                if (oldPercent != null)
                {
                    newPercent = new Percent(Convert.ToDecimal(newValue), oldPercent.DecimalDigits, false,
                        oldPercent.MinimumValue, oldPercent.MaximumValue);
                }
                else
                    newPercent = new Percent(Convert.ToDecimal(newValue));
            }
            else if (newValue is Percent)
            {
                newPercent = (Percent) newValue;
            }
            else if (newValue == null)
            {
                newPercent = null;
            }

            return newPercent;
        }

        #region IEquatable

        public override bool Equals(object obj)
        {
            return (obj is Percent) && Equals((Percent) obj);
        }

        public bool Equals(Percent other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return (_value == other._value);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return GetClone();
        }

        #endregion

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
            return _value.Value;
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
    }
}