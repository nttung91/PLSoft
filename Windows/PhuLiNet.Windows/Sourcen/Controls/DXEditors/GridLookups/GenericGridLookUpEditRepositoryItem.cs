using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using DevExpress.Accessibility;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using PhuLiNet.Business.Common.Lookup;
using Techical.Dynamic.Property.Filtering;
using Techical.Dynamic.Property.Sorting;
using Windows.Core.Controls.DXEditors.Helpers;

namespace Windows.Core.Controls.DXEditors.GridLookups
{
    [ToolboxItem(false)]
    [UserRepositoryItem("RegisterGenericRepositoryItemGridLookUpEdit")]
    public class GenericGridLookUpEditRepositoryItem : RepositoryItemGridLookUpEdit
    {
        private const int BestFitMaxRowCountValue = 50;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LookupListHandler ListHandler { get; set; }

        public GenericGridLookUpEditRepositoryItem()
        {
            //Init ListHandler
            ListHandler = EmptyLookupListHandler.GetLookupHandler();

            //Setting Defaults
            DataSource = ListHandler.LookupType;
            DisplayMember = ListHandler.ValuePropertyName;
            ValueMember = ListHandler.ValuePropertyName;
            PopupFormMinSize = new Size(400, 400);
            ImmediatePopup = true;
            NullText = string.Empty;
            BestFitMode = BestFitMode.BestFitResizePopup;

            if (View != null)
            {
                View.BestFitMaxRowCount = BestFitMaxRowCountValue;
            }
        }

        protected override GridView CreateViewInstance()
        {
            switch (ViewType)
            {
                case GridLookUpViewType.BandedView:
                    return new BandedGridView();
                case GridLookUpViewType.AdvBandedView:
                    return new AdvBandedGridView();

                default:
                    return new GridView();
            }
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as GenericGridLookUpEditRepositoryItem;
                if (source == null)
                    return;

                if (source.ListHandler != null)
                    ListHandler = source.ListHandler;
                if (source.OnSetDataSource != null)
                    OnSetDataSource = source.OnSetDataSource;
            }
            finally
            {
                EndUpdate();
            }
        }

        static GenericGridLookUpEditRepositoryItem()
        {
            RegisterGenericRepositoryItemGridLookUpEdit();
        }

        public static void RegisterGenericRepositoryItemGridLookUpEdit()
        {
            //Icon representing the editor within a container editor's Designer
            // ReSharper disable AssignNullToNotNullAttribute
            var bitmap =
                new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("Windows.Core.ManorIcon.bmp"));
            // ReSharper restore AssignNullToNotNullAttribute

            EditorRegistrationInfo.Default.Editors.Add(
                new EditorClassInfo(EditorName,
                    typeof (GenericGridLookUpEdit),
                    typeof (GenericGridLookUpEditRepositoryItem),
                    typeof (GridLookUpEditBaseViewInfo),
                    new ButtonEditPainter(), true, bitmap, typeof (PopupEditAccessible)));
        }

        internal const string EditorName = "GenericGridLookupEdit";

        public override string EditorTypeName
        {
            get { return EditorName; }
        }

        protected override void RaiseCustomDisplayText(CustomDisplayTextEventArgs e)
        {
            base.RaiseCustomDisplayText(e);
            LookupEditDisplayTextHelper.SetCustomDisplayText(e, DisplayFormat, NullText);
        }

        protected override void RaiseQueryPopUp(CancelEventArgs e)
        {
            View.OptionsView.ShowAutoFilterRow = true;

            SetDataSource(this, new EventArgs());

            if (ListHandler != null && !(ListHandler is EmptyLookupListHandler) && !ListHandler.ReadOnly)
            {
                base.RaiseQueryPopUp(e);

                // Wenn im Designer Display/Value Member gesetzt wurden dann diese nehmen.
                // Ein aufrufendes Form hat evtl. nicht den ganzen Lookuptyp als Property Implementiert sondern nur eine string oder int Property
                // Beispiel Refcode (Display Member = RvMeaning -> Anzeige, ValueMember = RvAbbreviation -> Wert der in die Property zurückgeschrieben wird.
                if (string.IsNullOrEmpty(DisplayMember))
                {
                    DisplayMember = ListHandler.ValuePropertyName;
                }
                if (string.IsNullOrEmpty(ValueMember))
                {
                    ValueMember = ListHandler.ValuePropertyName;
                }

                DataSource = ListHandler.GetList();
                View.GridControl.ForceInitialize();

                ListHandler.VisibleProperties.GetProperties(true);

                foreach (GridColumn gc in View.Columns)
                {
                    if (ListHandler.VisibleProperties.HasProperty(gc.FieldName))
                    {
                        var property = ListHandler.VisibleProperties.GetProperty(gc.FieldName);
                        gc.Caption = property.DisplayName;
                        gc.VisibleIndex = ListHandler.VisibleProperties.IndexOf(property.Key);

                        switch (property.SortOrder)
                        {
                            case ESortDirection.Ascending:
                                gc.SortOrder = ColumnSortOrder.Ascending;
                                break;
                            case ESortDirection.Descending:
                                gc.SortOrder = ColumnSortOrder.Descending;
                                break;
                            case ESortDirection.None:
                                gc.SortOrder = ColumnSortOrder.None;
                                break;
                            default:
                                gc.SortOrder = ColumnSortOrder.None;
                                break;
                        }

                        switch (property.AutoFilterCondition)
                        {
                            case EAutoFilterCondition.Equals:
                                gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Equals;
                                break;
                            case EAutoFilterCondition.Like:
                                gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Like;
                                break;
                            case EAutoFilterCondition.Contains:
                                gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                                break;
                            default:
                                gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Default;
                                break;
                        }

                        gc.Visible = property.Visible;
                    }
                    else
                    {
                        gc.Visible = false;
                    }
                }

                View.BestFitMaxRowCount = BestFitMaxRowCountValue;
                View.BestFitColumns();
            }
            else
            {
                //ListHandler not set or readonly mode
                e.Cancel = true;
            }
        }

        public delegate void SetDataSourceHandler(object sender, EventArgs e);

        [Browsable(true)]
        public event SetDataSourceHandler OnSetDataSource;

        protected void SetDataSource(object sender, EventArgs e)
        {
            if (OnSetDataSource != null)
                OnSetDataSource(sender, e);
        }
    }
}