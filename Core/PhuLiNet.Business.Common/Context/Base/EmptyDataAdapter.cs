using System;

namespace PhuLiNet.Business.Common.Context.Base
{
    public class EmptyDataAdapter : IContextDataAdapter
    {
        public IContext LoadContext(Type contextType)
        {
            return null;
        }

        public void SaveContext(IContext context)
        {
        }
    }
}