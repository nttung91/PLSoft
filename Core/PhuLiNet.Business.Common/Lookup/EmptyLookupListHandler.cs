using System;

namespace PhuLiNet.Business.Common.Lookup
{
    /// <summary>
    /// Empty list handler with no data
    /// </summary>
    [Serializable()]
    public class EmptyLookupListHandler : LookupListHandler
    {
        private EmptyLookupListHandler()
        {
        }

        public static EmptyLookupListHandler GetLookupHandler()
        {
            return new EmptyLookupListHandler();
        }

        public override object GetList()
        {
            return _list;
        }
    }
}