using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace Windows.Core.Controls.DXGrids.Editable
{
    public class BasicGridViewControl : GridControl
    {
        public BasicGridViewControl()
            : base()
        {
            UseEmbeddedNavigator = true;
        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView(BasicGridView.BasicViewName);
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new BasicGridViewInfoRegistrator());
        }
    }
}