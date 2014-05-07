using System;
using Csla;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiCommandBase<T> : CommandBase<T> where T : PhuLiCommandBase<T>
    {
    }
}