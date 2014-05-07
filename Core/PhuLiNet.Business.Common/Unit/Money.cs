using System;
using System.Diagnostics;
using System.Globalization;
using PhuLiNet.Business.Common.Calculation;
using PhuLiNet.Business.Common.Defaults;

namespace PhuLiNet.Business.Common.Unit
{
    /// <summary>
    /// A class for money including currency
    /// </summary>
    [Serializable]
    public sealed class Money : IEquatable<Money>, IComparable, IComparable<Money>, IConvertible, ICloneable,
        IFormattable
    {
        private static int _defaultDecimalDigits = 2;

        private decimal _amount;
        private readonly string _currencySymbol;
        private readonly string _currencySymbolDisplay;
        private int _currencyDecimalDigits;
        private string _formatString;
        private bool _formatWithCurrency = true;

        private bool _checkCurrency = true;

        public bool CheckCurrency
        {
            get { return _checkCurrency; }
            set { _checkCurrency = value; }
        }

        public static string DefaultCurrency
        {
            get { return Organisation.EnterpriseCurrency; }
        }

        public static string DefaultCurrencyDisplay
        {
            get { return Organisation.EnterpriseCurrencyDisplay; }
        }

        public static int DefaultDecimalDigits
        {
            get { return _defaultDecimalDigits; }
            set { _defaultDecimalDigits = value; }
        }

        public string CurrencySymbol
        {
            get { return _currencySymbol; }
        }

        public string CurrencySymbolDisplay
        {
            get { return _currencySymbolDisplay; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public decimal? AmountNullable
        {
            get { return _amount; }
        }

        public string AmountFormatted
        {
            get { return ToString(); }
        }

        public decimal AmountRounded
        {
            get { return Math.Round(_amount, _currencyDecimalDigits); }
        }

        public int DecimalDigits
        {
            get { return _currencyDecimalDigits; }
        }

        public bool FormatWithCurrency
        {
            get { return _formatWithCurrency; }
            set { _formatWithCurrency = value; }
        }

        private string FormatString
        {
            get
            {
                if (_formatString == null)
                {
                    _formatString = "#,0";

                    if (_currencyDecimalDigits > 0)
                        _formatString += ".";

                    for (int i = 1; i <= _currencyDecimalDigits; i++)
                    {
                        _formatString += "0";
                    }
                }

                if (_formatWithCurrency)
                {
                    string currencySymbol;
                    if (_currencySymbolDisplay != null)
                        currencySymbol = _currencySymbolDisplay;
                    else
                        currencySymbol = _currencySymbol;
                    return String.Format("{0} \"{1}\"", _formatString, currencySymbol);
                }
                else
                    return _formatString;
            }
        }

        public Money() : this(0, DefaultCurrency, DefaultCurrencyDisplay, DefaultDecimalDigits)
        {
        }

        public Money(decimal amount) : this(amount, DefaultCurrency, DefaultCurrencyDisplay, DefaultDecimalDigits)
        {
        }

        [Obsolete("CurrencySymbolDisplay should be specified when calling constructor")]
        public Money(decimal amount, string currencySymbol) : this(amount, currencySymbol, DefaultDecimalDigits)
        {
        }

        public Money(decimal amount, string currencySymbol, string currencySymbolDisplay)
            : this(amount, currencySymbol, currencySymbolDisplay, DefaultDecimalDigits)
        {
        }

        [Obsolete("CurrencySymbolDisplay should be specified when calling constructor")]
        public Money(decimal amount, string currencySymbol, int currencyDecimalDigits)
            : this(amount, currencySymbol, null, currencyDecimalDigits)
        {
        }

        public Money(decimal amount, int currencyDecimalDigits)
            : this(amount, DefaultCurrency, DefaultCurrency, currencyDecimalDigits)
        {
        }

        public Money(decimal amount, string currencySymbol, string currencySymbolDisplay, int currencyDecimalDigits)
        {
            Debug.Assert(currencySymbol != null, "CurrencySymbol is null");
            Debug.Assert(currencySymbol != string.Empty, "CurrencySymbol is empty");
            Debug.Assert(currencySymbolDisplay != null, "CurrencySymbolDisplay is null");

            _amount = Math.Round(amount, currencyDecimalDigits);
            _currencySymbol = currencySymbol;
            _currencySymbolDisplay = currencySymbolDisplay;
            _currencyDecimalDigits = currencyDecimalDigits;
        }

        public Money(long amount) : this(Convert.ToDecimal(amount))
        {
        }

        [Obsolete("CurrencySymbolDisplay should be specified when calling constructor")]
        public Money(long amount, string currencySymbol) : this(Convert.ToDecimal(amount), currencySymbol)
        {
        }

        public Money(long amount, string currencySymbol, string currencySymbolDisplay)
            : this(Convert.ToDecimal(amount), currencySymbol, currencySymbolDisplay)
        {
        }

        [Obsolete("CurrencySymbolDisplay should be specified when calling constructor")]
        public Money(long amount, string currencySymbol, int currencyDecimalDigits)
            : this((Convert.ToDecimal(amount)), currencySymbol, currencyDecimalDigits)
        {
        }

        public Money(long amount, string currencySymbol, string currencySymbolDisplay, int currencyDecimalDigits)
            : this((Convert.ToDecimal(amount)), currencySymbol, currencySymbolDisplay, currencyDecimalDigits)
        {
        }

        public static bool operator >(Money first, Money second)
        {
            bool greater;

            AssertSameCurrency(first, second);

            if (!ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                greater = first._amount > second._amount;
            else
                greater = false;

            return greater;
        }

        public static bool operator >=(Money first, Money second)
        {
            AssertSameCurrency(first, second);
            return first._amount >= second._amount;
        }

        public static bool operator <=(Money first, Money second)
        {
            AssertSameCurrency(first, second);
            return first._amount <= second._amount;
        }

        public static bool operator <(Money first, Money second)
        {
            AssertSameCurrency(first, second);
            return first._amount < second._amount;
        }

        /// <summary>
        /// Gibt Prozentbetrag als Money von second % an first
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Money operator %(Money first, decimal? second)
        {
            if (ReferenceEquals(first, null))
            {
                return null;
            }
            if (ReferenceEquals(second, null))
            {
                return new Money(0m, first.CurrencySymbol, first.CurrencySymbolDisplay, first.DecimalDigits);
            }

            return new Money(first._amount*second.Value/100, first.CurrencySymbol, first.CurrencySymbolDisplay,
                first.DecimalDigits);
        }

        public static Money operator +(Money first, Money second)
        {
            AssertSameCurrency(first, second);

            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return null;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return new Money(second.Amount, second.CurrencySymbol, second.CurrencySymbolDisplay,
                    second.DecimalDigits);
            else if (!ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return new Money(first.Amount, first.CurrencySymbol, first.CurrencySymbolDisplay, first.DecimalDigits);
            else
                return new Money(first.Amount + second.Amount, first.CurrencySymbol, first.CurrencySymbolDisplay,
                    first.DecimalDigits);
        }

        public static Money operator /(Money first, Money second)
        {
            AssertSameCurrency(first, second);

            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return null;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
            {
                Debug.Assert(false, "Division with null value!");
                return null;
            }
            else if (!ReferenceEquals(first, null) && ReferenceEquals(second, null))
            {
                Debug.Assert(false, "Division with null value!");
                return null;
            }
            else
                return new Money(first.Amount/second.Amount, first.CurrencySymbol, first.CurrencySymbolDisplay,
                    first.DecimalDigits);
        }

        public static Money Add(Money first, Money second)
        {
            return first + second;
        }

        public static Money operator -(Money first, Money second)
        {
            AssertSameCurrency(first, second);

            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return null;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return new Money(second.Amount, second.CurrencySymbol, second.CurrencySymbolDisplay,
                    second.DecimalDigits);
            else if (!ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return new Money(first.Amount, first.CurrencySymbol, first.CurrencySymbolDisplay, first.DecimalDigits);
            else
                return new Money(first.Amount - second.Amount, first.CurrencySymbol, first.CurrencySymbolDisplay,
                    first.DecimalDigits);
        }

        public static Money Subtract(Money first, Money second)
        {
            return first - second;
        }

        public static bool operator ==(Money first, Money second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            return (first.CurrencySymbol == second.CurrencySymbol && first.Amount == second.Amount &&
                    first.DecimalDigits == second.DecimalDigits);
        }

        public static bool operator !=(Money first, Money second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return false;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return true;
            else
                return !first.Equals(second);
        }

        public static Money operator *(Money money, decimal value)
        {
            if (money == null) throw new ArgumentNullException("money");
            return new Money(money.Amount*value, money.CurrencySymbol, money.CurrencySymbolDisplay, money.DecimalDigits);
        }

        public static Money Multiply(Money money, decimal value)
        {
            return money*value;
        }

        public static Money operator /(Money money, decimal value)
        {
            if (money == null) throw new ArgumentNullException("money");
            return new Money(money.Amount/value, money.CurrencySymbol, money.CurrencySymbolDisplay, money.DecimalDigits);
        }

        public static Money Divide(Money first, decimal value)
        {
            return first/value;
        }

        public static Money LocalCurrency
        {
            get
            {
                return new Money(0m, CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol,
                    CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol,
                    CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits);
            }
        }

        public Money Copy()
        {
            return GetClone();
        }

        public Money Clone()
        {
            return GetClone();
        }

        private Money GetClone()
        {
            return new Money(Amount, _currencySymbol, _currencySymbolDisplay, _currencyDecimalDigits);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is Money))
            {
                throw new ArgumentException("Argument must be money");
            }
            return CompareTo((Money) obj);
        }

        public int CompareTo(Money other)
        {
            if (CurrencySymbol != other.CurrencySymbol)
                return CurrencySymbol.CompareTo(other.CurrencySymbol);
            if (Amount != other.Amount)
                return Amount.CompareTo(other.Amount);

            return 0;
        }

        public override string ToString()
        {
            return Amount.ToString(FormatString);
        }

        public string ToString(string format)
        {
            return Amount.ToString(format);
        }

        public override bool Equals(object obj)
        {
            return (obj is Money) && Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return _amount.GetHashCode() ^ _currencySymbol.GetHashCode();
        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return ((CurrencySymbol == other.CurrencySymbol) && (_amount == other._amount));
        }

        private static void AssertSameCurrency(Money first, Money second)
        {
            if (!ReferenceEquals(first, null) && !ReferenceEquals(second, null))
            {
                if (first.CurrencySymbol != second.CurrencySymbol)
                {
                    if (first._checkCurrency)
                        throw new InvalidOperationException("Money currency mismatch.");
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
            return Convert.ToBoolean(_amount, provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_amount, provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(_amount, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(_amount, provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return _amount;
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_amount, provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_amount, provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_amount, provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt32(_amount, provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_amount, provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_amount, provider);
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
            return Convert.ToUInt16(_amount, provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_amount, provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_amount, provider);
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return GetClone();
        }

        #endregion

        public static Money TryConvert(object newValue)
        {
            return TryConvert(null, newValue);
        }

        public static Money TryConvert(object oldValue, object newValue)
        {
            var oldMoney = oldValue as Money;
            Money newMoney = null;

            if (newValue is string)
            {
                decimal valueAsDecimal;
                bool parseOk = decimal.TryParse(newValue.ToString(), out valueAsDecimal);
                if (parseOk)
                {
                    if (oldMoney != null)
                    {
                        newMoney = new Money(valueAsDecimal, oldMoney.CurrencySymbol, oldMoney._currencySymbolDisplay,
                            oldMoney.DecimalDigits);
                    }
                    else
                    {
                        newMoney = new Money(valueAsDecimal);
                    }
                }
            }
            else if (newValue is decimal ||
                     newValue is double ||
                     newValue is float)
            {
                if (oldMoney != null)
                {
                    newMoney = new Money(Convert.ToDecimal(newValue), oldMoney.CurrencySymbol,
                        oldMoney.CurrencySymbolDisplay, oldMoney.DecimalDigits);
                }
                else
                {
                    newMoney = new Money(Convert.ToDecimal(newValue));
                }
            }
            else if (newValue is Money)
            {
                newMoney = (Money) newValue;
            }
            else if (newValue == null)
            {
                newMoney = null;
            }

            return newMoney;
        }

        public static Money Parse(string s)
        {
            return TryConvert(s);
        }

        public static bool TryParse(string s, out Money result)
        {
            bool ok;

            result = TryConvert(s);
            if (result != null)
                ok = true;
            else
                ok = false;

            return ok;
        }

        public Money RoundToPayableAmount()
        {
            if (_currencySymbol.Equals(Organisation.EnterpriseCurrency))
            {
                return new Money(MoneyRounder.RoundToPayableAmount(_amount, 0.05m), _currencySymbol,
                    _currencySymbolDisplay, _currencyDecimalDigits);
            }
            else
            {
                return this;
            }
        }


        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (!string.IsNullOrEmpty(format) && format.StartsWith("n"))
            {
                int decPlaces;
                if (int.TryParse(format.Substring(1), out decPlaces))
                    _currencyDecimalDigits = decPlaces;
                _formatWithCurrency = false;
                _formatString = null;
            }

            return ToString();
        }

        public static Money ZeroAmount
        {
            get { return new Money(0m); }
        }
    }
}