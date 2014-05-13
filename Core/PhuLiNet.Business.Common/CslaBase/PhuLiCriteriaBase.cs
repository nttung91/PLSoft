using System;
using Csla;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiCriteriaBase<T> : CriteriaBase<T> where T : PhuLiCriteriaBase<T>
    {
    }
}