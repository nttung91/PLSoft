using System;
using Csla;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class ManorCriteriaBase<T> : CriteriaBase<T> where T : ManorCriteriaBase<T>
    {
    }
}