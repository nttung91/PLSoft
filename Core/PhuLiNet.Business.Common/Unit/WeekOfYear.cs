using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace PhuLiNet.Business.Common.Unit
{
    /// <summary>
    /// A class for week of year display and input
    /// </summary>
    [Serializable]
    public class WeekOfYear : IEquatable<WeekOfYear>, ICloneable, IComparable, IComparable<WeekOfYear>, IConvertible
    {
        private const string _separator = ".";
        private int _year;
        private int _week;

        public int Year
        {
            get { return _year; }
        }

        public int Week
        {
            get { return _week; }
        }

        public WeekOfYear()
        {
            WeekOfYear currentWeek = Now;
            _week = currentWeek.Week;
            _year = currentWeek.Year;
        }

        public WeekOfYear(int year, int week)
        {
            Debug.Assert(year > 0, "year is 0");
            Debug.Assert(week > 0, "week is 0");

            _week = week;
            _year = year;
        }

        public WeekOfYear(DateTime dateTime)
        {
            Debug.Assert(dateTime != null, "DateTime is null");

            _week = GetWeekOfYear(dateTime);
            _year = dateTime.Year;
        }

        public static WeekOfYear Now
        {
            get
            {
                DateTime now = DateTime.Now;
                int week = GetWeekOfYear(now);
                return new WeekOfYear(now.Year, week);
            }
        }

        private static int GetWeekOfYear(DateTime dateTime)
        {
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            int week = ci.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return week;
        }

        #region IEquatable<Quantity> Members

        public bool Equals(WeekOfYear other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return ((_year == other._year) && (_week == other._week));
        }

        #endregion

        public override bool Equals(object obj)
        {
            return (obj is WeekOfYear) && Equals((WeekOfYear) obj);
        }

        public static bool operator >(WeekOfYear first, WeekOfYear second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            else
            {
                return (first._year > second._year) || ((first._year == second._year) && (first._week > second._week));
            }
        }

        public static bool operator >=(WeekOfYear first, WeekOfYear second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            else
            {
                return (first._year > second._year) || ((first._year == second._year) && (first._week >= second._week));
            }
        }

        public static bool operator <=(WeekOfYear first, WeekOfYear second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            else
            {
                return (first._year < second._year) || ((first._year == second._year) && (first._week <= second._week));
            }
        }

        public static bool operator <(WeekOfYear first, WeekOfYear second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            else
            {
                return (first._year < second._year) || ((first._year == second._year) && (first._week < second._week));
            }
        }

        public static bool operator ==(WeekOfYear first, WeekOfYear second)
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

        public static bool operator !=(WeekOfYear first, WeekOfYear second)
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
            return _year.GetHashCode() ^ _week.GetHashCode();
        }

        public WeekOfYear Copy()
        {
            return GetClone();
        }

        public WeekOfYear Clone()
        {
            return GetClone();
        }

        private WeekOfYear GetClone()
        {
            return new WeekOfYear(_year, _week);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is WeekOfYear))
            {
                throw new ArgumentException("Argument must be WeekOfYear");
            }
            return CompareTo((WeekOfYear) obj);
        }

        public int CompareTo(WeekOfYear other)
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
            return _year.ToString() + _separator + _week.ToString("00");
        }

        public string ToString(string format)
        {
            return ToString();
        }

        public DateTime ToDateTime()
        {
            var dateTime = new DateTime(_year, 1, 1);
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            dateTime = ci.Calendar.AddWeeks(dateTime, _week - 1);
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
            if (conversionType == typeof (DateTime)) return ToDateTime(provider);
            return null;
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

        public static WeekOfYear TryConvert(object newValue)
        {
            WeekOfYear newWeekOfYear = null;

            if (newValue is string)
            {
                var newValueAsString = newValue as string;
                string[] array = newValueAsString.Split(new string[1] {_separator}, StringSplitOptions.None);

                if (array.Length == 2)
                {
                    int first;
                    int second;
                    bool parseOkFirst = int.TryParse(array[0], out first);
                    bool parseOkSecond = int.TryParse(array[1], out second);

                    if (parseOkFirst && parseOkSecond)
                    {
                        if (array[0].Length == 4)
                        {
                            newWeekOfYear = new WeekOfYear(first, second);
                        }
                    }
                }
            }
            else if (newValue is DateTime)
            {
                newWeekOfYear = new WeekOfYear((DateTime) newValue);
            }
            else if (newValue is WeekOfYear)
            {
                newWeekOfYear = (newValue as WeekOfYear).Clone();
            }
            else if (newValue == null)
            {
                newWeekOfYear = null;
            }

            return newWeekOfYear;
        }

        public static WeekOfYear Parse(string s)
        {
            return TryConvert(s);
        }

        public static bool TryParse(string s, out WeekOfYear result)
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