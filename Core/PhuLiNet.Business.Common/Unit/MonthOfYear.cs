using System;
using System.Diagnostics;

namespace PhuLiNet.Business.Common.Unit
{
    /// <summary>
    /// A class for month of year display and input
    /// </summary>
    [Serializable]
    public class MonthOfYear : IEquatable<MonthOfYear>, ICloneable, IComparable, IComparable<MonthOfYear>, IConvertible
    {
        private const string _separator = " ";
        private int _year;
        private int _month;

        public int Year
        {
            get { return _year; }
        }

        public int Month
        {
            get { return _month; }
        }

        public string MonthName
        {
            get { return new DateTime(DateTime.Now.Year, _month, 1).ToString("MMM"); }
        }

        public MonthOfYear Myself
        {
            get { return this; }
        }

        public MonthOfYear()
        {
            MonthOfYear currentMonth = Now;
            _month = currentMonth.Month;
            _year = currentMonth.Year;
        }

        public MonthOfYear(int year, int month)
        {
            Debug.Assert(year > 0, "year is 0");
            Debug.Assert(month > 0, "month is 0");
            Debug.Assert(month <= 12, "month greater than 12");

            _month = month;
            _year = year;
        }

        public MonthOfYear(DateTime dateTime)
        {
            _month = dateTime.Month;
            _year = dateTime.Year;
        }

        public static MonthOfYear Now
        {
            get
            {
                DateTime now = DateTime.Now;
                return new MonthOfYear(now.Year, now.Month);
            }
        }

        #region IEquatable<Quantity> Members

        public bool Equals(MonthOfYear other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return ((_year == other._year) && (_month == other._month));
        }

        #endregion

        public override bool Equals(object obj)
        {
            return (obj is MonthOfYear) && Equals((MonthOfYear) obj);
        }

        public static bool operator >(MonthOfYear first, MonthOfYear second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            else
            {
                return (first._year > second._year) || ((first._year == second._year) && (first._month > second._month));
            }
        }

        public static bool operator >=(MonthOfYear first, MonthOfYear second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            else
            {
                return (first._year > second._year) ||
                       ((first._year == second._year) && (first._month >= second._month));
            }
        }

        public static bool operator <=(MonthOfYear first, MonthOfYear second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            else
            {
                return (first._year < second._year) ||
                       ((first._year == second._year) && (first._month <= second._month));
            }
        }

        public static bool operator <(MonthOfYear first, MonthOfYear second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            else
            {
                return (first._year < second._year) || ((first._year == second._year) && (first._month < second._month));
            }
        }

        public static bool operator ==(MonthOfYear first, MonthOfYear second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            return first.Equals(second);
        }

        public static bool operator !=(MonthOfYear first, MonthOfYear second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return false;
            else if (ReferenceEquals(first, null) && !ReferenceEquals(second, null))
                return true;
            else
                return !first.Equals(second);
        }

        public override int GetHashCode()
        {
            return _year.GetHashCode() ^ _month.GetHashCode();
        }

        public MonthOfYear Copy()
        {
            return GetClone();
        }

        public MonthOfYear Clone()
        {
            return GetClone();
        }

        private MonthOfYear GetClone()
        {
            return new MonthOfYear(_year, _month);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is MonthOfYear))
            {
                throw new ArgumentException("Argument must be MonthOfYear");
            }
            return CompareTo((MonthOfYear) obj);
        }

        public int CompareTo(MonthOfYear other)
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
            return String.Format("{0}{1}{2}", _year, _separator, MonthName);
        }

        public string ToString(string format)
        {
            return ToString();
        }

        public DateTime ToDateTime()
        {
            var dateTime = new DateTime(_year, _month, 1);
            return dateTime;
        }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return GetClone();
        }

        #endregion

        #region IConvertible Members

        public TypeCode GetTypeCode()
        {
            return TypeCode.DateTime;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(ToDateTime(provider));
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(ToDateTime(provider));
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(ToDateTime(provider));
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return ToDateTime();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(ToDateTime(provider));
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(ToDateTime(provider));
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(ToDateTime(provider));
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(ToDateTime(provider));
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(ToDateTime(provider));
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(ToDateTime(provider));
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(ToDateTime(provider));
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
            return Convert.ToUInt16(ToDateTime(provider));
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(ToDateTime(provider));
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(ToDateTime(provider));
        }

        #endregion

        public static MonthOfYear TryConvert(object newValue)
        {
            MonthOfYear newMonthOfYear = null;

            if (newValue is string && newValue != null && newValue.ToString() != string.Empty)
            {
                var newValueAsString = newValue as string;
                string[] array = newValueAsString.Split(new string[1] {_separator}, StringSplitOptions.None);

                if (array.Length == 2)
                {
                    //seperator exists
                    int first;
                    int second;
                    bool parseOkFirst = int.TryParse(array[0], out first);
                    bool parseOkSecond = int.TryParse(array[1], out second);

                    if (parseOkFirst && parseOkSecond)
                    {
                        if (array[0].Length == 4)
                        {
                            newMonthOfYear = new MonthOfYear(first, second);
                        }
                    }
                }
                else if (array.Length == 1 && array[0].Length == 6)
                {
                    //seperator exists does not exist
                    int first;
                    int second;
                    bool parseOkFirst = int.TryParse(array[0].Substring(0, 4), out first);
                    bool parseOkSecond = int.TryParse(array[0].Substring(4, 2), out second);

                    if (parseOkFirst && parseOkSecond)
                    {
                        if (first > 0 && second > 0 && second <= 12)
                        {
                            newMonthOfYear = new MonthOfYear(first, second);
                        }
                    }
                }
            }
            else if (newValue is DateTime)
            {
                newMonthOfYear = new MonthOfYear((DateTime) newValue);
            }
            else if (newValue == null)
            {
                newMonthOfYear = null;
            }

            return newMonthOfYear;
        }

        public static MonthOfYear Parse(string s)
        {
            return TryConvert(s);
        }

        public static bool TryParse(string s, out MonthOfYear result)
        {
            bool ok = false;

            result = TryConvert(s);
            if (result != null)
            {
                ok = true;
            }

            return ok;
        }
    }
}