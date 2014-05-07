using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace Windows.Core.Controls.DXGrids.ReadOnly
{
    public class BasicGridViewControlReadOnly : GridControl
    {
        public BasicGridViewControlReadOnly()
            : base()
        {
            UseEmbeddedNavigator = true;
            EmbeddedNavigator.Buttons.Append.Visible = false;
            EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            EmbeddedNavigator.Buttons.Edit.Visible = false;
            EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            EmbeddedNavigator.Buttons.Remove.Visible = false;
        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView(BasicGridViewReadOnly.BasicViewName);
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new BasicGridViewInfoRegistratorReadOnly());
        }
    }
}