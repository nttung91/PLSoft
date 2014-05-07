using System;
using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context.Base
{
    public interface IContextDataAdapter
    {
        IContext LoadContext(Type contextType);
        void SaveContext(IContext context);
    }
}