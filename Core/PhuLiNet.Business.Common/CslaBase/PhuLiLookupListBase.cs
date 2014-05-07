using System;
using System.Collections.Generic;
using System.Linq;
using PhuLiNet.Business.Common.Helper;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Lookup;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiLookupListBase<T, TC> : PhuLiReadOnlyBindingListBase<T, TC>, ILookupObjectList,
        IDisplayTexts
        where T : PhuLiLookupListBase<T, TC>
        where TC : PhuLiLookupBase<TC>
    {
        public abstract string LookupListName { get; }

        public IList<ILookupObject> GetLookupList()
        {
            return this.Cast<ILookupObject>().ToList();
        }

        public string ToDisplayText()
        {
            return DisplayTextHelper.ConvertToDisplayText<TC>(this, ", ");
        }

        public string ToDisplayTextShort()
        {
            return DisplayTextHelper.ConvertToDisplayTextShort<TC>(this, ", ");
        }
    }
}