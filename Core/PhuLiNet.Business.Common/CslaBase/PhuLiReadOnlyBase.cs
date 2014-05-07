using System;
using Csla;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiReadOnlyBase<T> : ReadOnlyBase<T>, IPhuLiReadOnlyBase where T : PhuLiReadOnlyBase<T>
    {
        public object IdValue
        {
            get { return GetIdValue(); }
        }
    }
}