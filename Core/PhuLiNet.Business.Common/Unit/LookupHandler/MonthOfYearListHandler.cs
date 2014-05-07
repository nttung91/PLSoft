using System;
using PhuLiNet.Business.Common.Lookup;
using Techical.Dynamic.Property;

namespace PhuLiNet.Business.Common.Unit.LookupHandler
{
    public class MonthOfYearListHandler : LookupListHandler
    {
        #region Attribute von denen der Listeninhalt abhängig ist

        #endregion

        public MonthOfYear From { get; private set; }
        public MonthOfYear To { get; private set; }

        private MonthOfYearListHandler()
        {
            _valuePropertyName = "Myself";
            _lookupType = typeof (MonthOfYear);

            _visibleProperties = new DynamicPropertyList();
            _visibleProperties.AddProperty("MonthName", new SimpleProperty<string>(null, "Monat", true, true));
            _visibleProperties.AddProperty("Year", new SimpleProperty<string>(null, "Jahr", true, true));

            if (From == null)
                From = new MonthOfYear(DateTime.Now.Year - 1, DateTime.Now.Month);
            if (To == null)
                To = new MonthOfYear(DateTime.Now.Year + 1, DateTime.Now.Month);
        }

        private MonthOfYearListHandler(MonthOfYear monthFrom, MonthOfYear monthTo)
            : this()
        {
            if (monthFrom != null)
                From = monthFrom;
            if (monthTo != null)
                To = monthTo;
        }

        public static MonthOfYearListHandler GetLookupHandler()
        {
            return new MonthOfYearListHandler();
        }

        public static MonthOfYearListHandler GetLookupHandler(MonthOfYear monthFrom, MonthOfYear monthTo)
        {
            return new MonthOfYearListHandler(monthFrom, monthTo);
        }

        public override object GetList()
        {
            if (!_listLoaded)
            {
                _list = MonthOfYearList.GetMonthOfYearList(From, To);
                _listLoaded = true;
            }

            return _list;
        }
    }
}