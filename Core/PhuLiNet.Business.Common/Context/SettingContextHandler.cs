using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context
{
    public class SettingContextHandler : BaseContextHandler
    {
        public SettingContextHandler()
        {
            DataAdapter = new SettingDataAdapter();
        }

        public override T GetContext<T>()
        {
            T context;

            if (base.HasContext<T>())
            {
                context = base.GetContext<T>();
            }
            else
            {
                context = (T) DataAdapter.LoadContext(typeof (T)) ?? new T();
                AddContext(context);
            }

            return context;
        }

        public override void LoadContexts()
        {
        }
    }
}