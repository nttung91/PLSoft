using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using PhuLiNet.Business.Common.Lookup;
using Techical.Dynamic.Property.Sorting;
using Windows.Core.Controls.DXEditors.Helpers;

namespace Windows.Core.Controls.DXEditors.Lookups
{
    [ToolboxItem(false)]
    [UserRepositoryItem("RegisterGenericLookupEdit")]
    public class GenericLookupEditRepositoryItem : RepositoryItemLookUpEdit
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LookupListHandler ListHandler { get; set; }

        public bool ReadOnlyLookup { get; set; }

        public GenericLookupEditRepositoryItem()
        {
            //Init ListHandler
            ListHandler = EmptyLookupListHandler.GetLookupHandler();

            //Setting Defaults
            DisplayMember = ListHandler.ValuePropertyName;
            ValueMember = ListHandler.ValuePropertyName;
            ImmediatePopup = true;
            NullText = string.Empty;
            DropDownRows = 15;
            BestFitRowCount = 20;
            BestFitMode = BestFitMode.BestFitResizePopup;
        }

        protected override void AssignColumns(LookUpColumnInfoCollection source)
        {
            if (source.Count > 0)
                base.AssignColumns(source);
        }

        static GenericLookupEditRepositoryItem()
        {
            RegisterGenericLookupEdit();
        }

        public const string LookupEditName = "GenericLookupEdit";

        public static void RegisterGenericLookupEdit()
        {
            //Icon representing the editor within a container editor's Designer
            // ReSharper disable AssignNullToNotNullAttribute
            var bitmap =
                new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("Windows.Core.ManorIcon.bmp"));
            // ReSharper restore AssignNullToNotNullAttribute

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(LookupEditName,
                typeof (GenericLookupEdit),
                typeof (GenericLookupEditRepositoryItem),
                typeof (LookUpEditViewInfo),
                new ButtonEditPainter(), true, bitmap));
        }

        public override string EditorTypeName
        {
            get { return LookupEditName; }
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as GenericLookupEditRepositoryItem;
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

        protected override void RaiseCustomDisplayText(CustomDisplayTextEventArgs e)
        {
            base.RaiseCustomDisplayText(e);
            LookupEditDisplayTextHelper.SetCustomDisplayText(e, DisplayFormat, NullText);
        }

        /// <summary>
        /// Returns ReadOnly value and calls the BeforeReadOnlyCheck event before
        /// </summary>
        /// <returns></returns>
        private bool CheckReadOnly()
        {
            BeforeReadOnlyCheck(this, new EventArgs());
            return ReadOnlyLookup;
        }

        protected override void RaiseQueryPopUp(CancelEventArgs e)
        {
            if (CheckReadOnly())
            {
                e.Cancel = true;
                return;
            }

            SetDataSource(this, new EventArgs());

            if (ListHandler != null && !(ListHandler is EmptyLookupListHandler) && !ListHandler.ReadOnly)
            {
                base.RaiseQueryPopUp(e);

                //Modus mit ListHandler DataSource
                DisplayMember = ListHandler.ValuePropertyName;
                ValueMember = ListHandler.ValuePropertyName;

                DataSource = ListHandler.GetList();

                if (Columns.Count == 0)
                {
                    PopulateColumns();
                    foreach (LookUpColumnInfo colInfo in Columns)
                    {
                        if (ListHandler.VisibleProperties.HasProperty(colInfo.FieldName))
                        {
                            var property = ListHandler.VisibleProperties.GetProperty(colInfo.FieldName);
                            colInfo.Caption = property.DisplayName;

                            switch (property.SortOrder)
                            {
                                case ESortDirection.Ascending:
                                    colInfo.SortOrder = ColumnSortOrder.Ascending;
                                    break;
                                case ESortDirection.Descending:
                                    colInfo.SortOrder = ColumnSortOrder.Descending;
                                    break;
                                case ESortDirection.None:
                                    colInfo.SortOrder = ColumnSortOrder.None;
                                    break;
                                default:
                                    colInfo.SortOrder = ColumnSortOrder.None;
                                    break;
                            }

                            colInfo.Visible = property.Visible;
                        }
                        else
                        {
                            colInfo.Visible = false;
                        }
                    }
                }

                var list = DataSource as IList;
                if (list != null && (DataSource != null && list.Count < 10))
                    DropDownRows = (DataSource as IList).Count + 1;
            }
            else
            {
                //ListHandler not set or readonly mode
                e.Cancel = true;
            }
        }


        /// <summary>
        /// Bevor das Lookup aufgeht, wird dieser Event ausgelöst
        /// Der Client des Lookups kann sich darauf registrieren und im Eventhandler die Datasource ermitteln und zuweisen
        /// </summary>
        public delegate void SetDataSourceHandler(object sender, EventArgs e);

        [Browsable(true)]
        public event SetDataSourceHandler OnSetDataSource;

        protected void SetDataSource(object sender, EventArgs e)
        {
            if (OnSetDataSource != null)
                OnSetDataSource(sender, e);
        }

        /// <summary>
        /// Eventhandler für ReadOnly-Check
        /// Dieser Event kann genutzt werden um den Wert von ReadOnly neu zu setzen
        /// bevor dieser ausgelesen wird.
        /// </summary>
        public delegate void BeforeReadOnlyCheckHandler(object sender, EventArgs e);

        [Browsable(true)]
        public event BeforeReadOnlyCheckHandler BeforeReadOnlyChecked;

        protected void BeforeReadOnlyCheck(object sender, EventArgs e)
        {
            if (BeforeReadOnlyChecked != null)
                BeforeReadOnlyChecked(sender, e);
        }
    }
}