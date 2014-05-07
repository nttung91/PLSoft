using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Windows.Core.BaseForms;
using Windows.Core.Binding;
using Windows.Core.Controls.Adapters;
using Windows.Core.Helpers.GridLayout;
using Windows.Core.Helpers.GridLayout.LayoutManager;
using Windows.Core.Instructions;

namespace Windows.Core.Controls
{
    public partial class UCGridBase : UCBusinessControlBase, ISaveAndRestoreGridLayout, IFilterableControl,
        IControlInstructions,
        IExportableControl, IPrintableControl
    {
        protected ListControlAdapter ListControl;
        private IGridLayoutHandler _layoutHandler;
        public event EventHandler<CurrentMasterDetailSelectionChanged> CurrentChanged;
        public event EventHandler<CurrentMasterDetailSelectionChanging> CurrentChanging;

        public UCGridBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The binding sources hierarchy used by the control.
        /// Child binding sources are added with AddChild to the BindingSourceNode.
        /// </summary>
        /// <remarks>The binding source hierarchy is bound/rebound/unbound at the correct times.</remarks>
        protected virtual BindingSourceNode BindingSource
        {
            get { throw new NotImplementedException(); }
        }

        protected override sealed void InitBindings()
        {
            if (IsDesignerHosted) return;

            object rootToBind = GetRootToBind();

            if (rootToBind != null)
            {
                _objectBindingManager.BindBO(rootToBind, BindingSource.BindingSource);
                _objectBindingManager.RestoreBindings(BindingSource, true);
            }
            else
            {
                _objectBindingManager.UnbindBO(BindingSource.BindingSource, true, true);
            }
            AfterInitBindings();
        }

        /// <summary>
        /// Returns the object which should be bound to the root binding source.
        /// </summary>
        /// <returns>E.g. a list or a dummy list container object.</returns>
        protected virtual object GetRootToBind()
        {
            throw new NotImplementedException();
        }

        public override void InitBusiness()
        {
            InitListControl();
            InitLayoutManager();

            // Bind the business object to root source
            InitBindings();
            InitControls();

            RaiseCurrentDataChanged();
        }

        public override void ClearBusiness()
        {
            _objectBindingManager.ClearBindings(BindingSource, true);

            RaiseCurrentDataChanged();
        }

        public override void RefreshBusiness()
        {
            InitBindings();
            _objectBindingManager.RestoreBindings(BindingSource, true);

            RaiseCurrentDataChanged();
        }


        protected override void InitControls()
        {
            BindingSource.BindingSource.CurrentChanged += DataBindingSource_CurrentChanged;
            ListControl.ItemChanging += ListControlOnItemChanging;
        }

        private void ListControlOnItemChanging(object sender, ItemChangingEventArgs args)
        {
            if (CurrentChanging != null && BindingSource.BindingSource.Position >= 0)
            {
                var allowArgs = new CurrentMasterDetailSelectionChanging(args.NewElement) {Allow = true};
                CurrentChanging(this, allowArgs);
                args.Allow = allowArgs.Allow;
            }
        }

        private void DataBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            RaiseCurrentDataChanged();
        }

        public virtual void RaiseCurrentDataChanged()
        {
            if (CurrentChanged != null && BindingSource.BindingSource.Position >= 0)
            {
                CurrentChanged(this, new CurrentMasterDetailSelectionChanged(BindingSource.BindingSource.Current));
            }
        }

        /// <summary>
        /// Override this to e.g. enable/disable controls 
        /// </summary>
        protected virtual void AfterInitBindings()
        {
        }

        protected virtual void InitListControl()
        {
            throw new NotImplementedException();
        }

        #region ISaveAndRestoreGridLayout Members

        private void InitLayoutManager()
        {
            if (_layoutHandler == null)
            {
                _layoutHandler = new GridLayoutManagerList();
                _layoutHandler.AddLayoutManager(new ListControlLayoutManager(ParentForm, ListControl));
                _layoutHandler.RestoreLayouts();
            }
        }

        public void RestoreGridLayout(string layoutName)
        {
            _layoutHandler.RestoreLayout(layoutName);
        }

        public void SaveGridLayout(string layoutName)
        {
            _layoutHandler.SaveLayout(layoutName);
        }

        #endregion

        #region IFilterableControl Members

        public virtual void Filter()
        {
            ListControl.ShowAutoFilterRow = !ListControl.ShowAutoFilterRow;
        }

        #endregion

        public virtual void BestFitColumns()
        {
            ListControl.BestFitColumns();
        }

        protected void BuildColumnFilter(GridColumn gridColumn, RepositoryItemCheckedComboBoxEdit checkedComboBoxEdit)
        {
            var typeFilterList = checkedComboBoxEdit.Items.Cast<CheckedListBoxItem>()
                .Where(p => p.CheckState == CheckState.Checked)
                .Select(p => (string) p.Value).ToList();

            if (typeFilterList.Count == 0)
            {
                gridColumn.FilterInfo = null;
                return;
            }

            var containsOp = new InOperator(gridColumn.FieldName, typeFilterList);
            gridColumn.FilterInfo = new ColumnFilterInfo(containsOp);
        }

        public virtual void ApplyInstruction(IInstruction instruction)
        {
            if (instruction is NewInstruction)
            {
                ExecuteNewInstruction(instruction);
            }
            else if (instruction is DeleteInstruction)
            {
                ExecuteDeleteInstruction(instruction);
            }
            else if (instruction is CopyInstruction)
            {
                ExecuteCopyInstruction(instruction);
            }
        }

        protected virtual void ExecuteNewInstruction(IInstruction instruction)
        {
        }

        protected virtual void ExecuteDeleteInstruction(IInstruction instruction)
        {
        }

        protected virtual void ExecuteCopyInstruction(IInstruction instruction)
        {
        }

        public virtual void Print()
        {
            ForceLeaveFocus();
            ListControl.Print();
        }

        public virtual void Export(ExportType exportType)
        {
            ForceLeaveFocus();
            ListControl.Export(exportType);
        }

        protected virtual void ForceLeaveFocus()
        {
            ListControl.ForceLeaveFocus();
        }
    }
}