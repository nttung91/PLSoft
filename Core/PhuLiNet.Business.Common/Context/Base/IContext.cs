using System;

namespace PhuLiNet.Business.Common.Context.Base
{
    public interface IContext : ICloneable
    {
        void Reset();
    }
}