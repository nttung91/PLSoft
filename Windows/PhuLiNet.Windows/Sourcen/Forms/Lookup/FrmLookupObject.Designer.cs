using PhuLiNet.Business.Common.Lookup;

namespace Windows.Core.Forms.Lookup
{
    partial class FrmLookupObject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLookupObject));
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcLookup = new DevExpress.XtraGrid.GridControl();
            this.iLookupObjectBindingSource = new System.Windows.Forms.BindingSource();
            this.gvLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLookupKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLookupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.tlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnNullSelection = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.xtraGridCheckBoxHelper1 = new Windows.Core.Components.XtraGrid.XtraGridCheckBoxHelper();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLookupObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.CheckStateChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckStateChanged);
            // 
            // gcLookup
            // 
            resources.ApplyResources(this.gcLookup, "gcLookup");
            this.gcLookup.DataSource = this.iLookupObjectBindingSource;
            this.gcLookup.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcLookup.EmbeddedNavigator.Buttons.Append.Hint = resources.GetString("gcLookup.EmbeddedNavigator.Buttons.Append.Hint");
            this.gcLookup.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcLookup.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcLookup.EmbeddedNavigator.Buttons.CancelEdit.Hint = resources.GetString("gcLookup.EmbeddedNavigator.Buttons.CancelEdit.Hint");
            this.gcLookup.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcLookup.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcLookup.EmbeddedNavigator.Buttons.Edit.Hint = resources.GetString("gcLookup.EmbeddedNavigator.Buttons.Edit.Hint");
            this.gcLookup.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcLookup.EmbeddedNavigator.Buttons.EnabledAutoRepeat = false;
            this.gcLookup.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcLookup.EmbeddedNavigator.Buttons.EndEdit.Hint = resources.GetString("gcLookup.EmbeddedNavigator.Buttons.EndEdit.Hint");
            this.gcLookup.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcLookup.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcLookup.EmbeddedNavigator.Buttons.Remove.Hint = resources.GetString("gcLookup.EmbeddedNavigator.Buttons.Remove.Hint");
            this.gcLookup.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcLookup.MainView = this.gvLookup;
            this.gcLookup.Name = "gcLookup";
            this.gcLookup.UseEmbeddedNavigator = true;
            this.gcLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLookup});
            // 
            // iLookupObjectBindingSource
            // 
            this.iLookupObjectBindingSource.DataSource = typeof(ILookupObject);
            // 
            // gvLookup
            // 
            this.gvLookup.Appearance.FocusedRow.Font = ((System.Drawing.Font)(resources.GetObject("gvLookup.Appearance.FocusedRow.Font")));
            this.gvLookup.Appearance.FocusedRow.Options.UseFont = true;
            this.gvLookup.BestFitMaxRowCount = 100;
            this.gvLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelected,
            this.colLookupKey,
            this.colLookupName});
            this.gvLookup.GridControl = this.gcLookup;
            this.gvLookup.Name = "gvLookup";
            this.gvLookup.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvLookup.OptionsView.ShowAutoFilterRow = true;
            this.gvLookup.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLookupKey, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvLookup.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvLookup_CustomUnboundColumnData);
            this.gvLookup.DoubleClick += new System.EventHandler(this.gvLookup_DoubleClick);
            // 
            // colSelected
            // 
            this.colSelected.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("colSelected.AppearanceHeader.Font")));
            this.colSelected.AppearanceHeader.Options.UseFont = true;
            this.colSelected.AppearanceHeader.Options.UseTextOptions = true;
            this.colSelected.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colSelected, "colSelected");
            this.colSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSelected.FieldName = "Selected";
            this.colSelected.Name = "colSelected";
            // 
            // colLookupKey
            // 
            this.colLookupKey.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("colLookupKey.AppearanceHeader.Font")));
            this.colLookupKey.AppearanceHeader.Options.UseFont = true;
            this.colLookupKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colLookupKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colLookupKey, "colLookupKey");
            this.colLookupKey.FieldName = "LookupKey";
            this.colLookupKey.Name = "colLookupKey";
            this.colLookupKey.OptionsColumn.AllowEdit = false;
            this.colLookupKey.OptionsColumn.ReadOnly = true;
            // 
            // colLookupName
            // 
            this.colLookupName.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("colLookupName.AppearanceHeader.Font")));
            this.colLookupName.AppearanceHeader.Options.UseFont = true;
            this.colLookupName.AppearanceHeader.Options.UseTextOptions = true;
            this.colLookupName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colLookupName, "colLookupName");
            this.colLookupName.FieldName = "LookupName";
            this.colLookupName.Name = "colLookupName";
            this.colLookupName.OptionsColumn.AllowEdit = false;
            this.colLookupName.OptionsColumn.AllowFocus = false;
            this.colLookupName.OptionsColumn.ReadOnly = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.tlButtons);
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            this.pnlButtons.Name = "pnlButtons";
            // 
            // tlButtons
            // 
            resources.ApplyResources(this.tlButtons, "tlButtons");
            this.tlButtons.Controls.Add(this.btnNullSelection, 0, 0);
            this.tlButtons.Controls.Add(this.btnCancel, 3, 0);
            this.tlButtons.Controls.Add(this.btnOk, 2, 0);
            this.tlButtons.Name = "tlButtons";
            // 
            // btnNullSelection
            // 
            resources.ApplyResources(this.btnNullSelection, "btnNullSelection");
            this.btnNullSelection.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNullSelection.Name = "btnNullSelection";
            this.btnNullSelection.Click += new System.EventHandler(this.btnNullSelection_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // xtraGridCheckBoxHelper1
            // 
            this.xtraGridCheckBoxHelper1.GridColumn = this.colSelected;
            // 
            // FrmLookupObject
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.gcLookup);
            this.HelpButton = true;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLookupObject";
            this.RememberPosition = false;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FrmLookupObject_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLookupObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLookup;
        private System.Windows.Forms.BindingSource iLookupObjectBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLookupKey;
        private DevExpress.XtraGrid.Columns.GridColumn colLookupName;
        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tlButtons;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnNullSelection;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private Components.XtraGrid.XtraGridCheckBoxHelper xtraGridCheckBoxHelper1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
