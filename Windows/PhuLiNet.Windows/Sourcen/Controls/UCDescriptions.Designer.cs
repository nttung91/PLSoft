namespace Windows.Core.Controls
{
    partial class UCDescriptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcDescriptions = new DevExpress.XtraGrid.GridControl();
            this.bsDescriptions = new System.Windows.Forms.BindingSource();
            this.bsParent = new System.Windows.Forms.BindingSource();
            this.gvDescriptions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplaySequence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colShortDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortDescriptionTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcDescriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDescriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDescriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortDescriptionTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDescriptions
            // 
            this.gcDescriptions.DataSource = this.bsDescriptions;
            this.gcDescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDescriptions.Location = new System.Drawing.Point(0, 0);
            this.gcDescriptions.MainView = this.gvDescriptions;
            this.gcDescriptions.Name = "gcDescriptions";
            this.gcDescriptions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.descriptionTextEdit,
            this.shortDescriptionTextEdit});
            this.gcDescriptions.ShowOnlyPredefinedDetails = true;
            this.gcDescriptions.Size = new System.Drawing.Size(347, 150);
            this.gcDescriptions.TabIndex = 18;
            this.gcDescriptions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDescriptions,
            this.gridView3});
            // 
            // bsDescriptions
            // 
            this.bsDescriptions.DataSource = this.bsParent;
            // 
            // gvDescriptions
            // 
            this.gvDescriptions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplaySequence,
            this.colLang,
            this.colDescr,
            this.colShortDescr});
            this.gvDescriptions.GridControl = this.gcDescriptions;
            this.gvDescriptions.Name = "gvDescriptions";
            this.gvDescriptions.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDescriptions.OptionsView.ColumnAutoWidth = false;
            this.gvDescriptions.OptionsView.ShowGroupPanel = false;
            this.gvDescriptions.OptionsView.ShowIndicator = false;
            this.gvDescriptions.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDisplaySequence, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colDisplaySequence
            // 
            this.colDisplaySequence.FieldName = "DisplaySequence";
            this.colDisplaySequence.Name = "colDisplaySequence";
            this.colDisplaySequence.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colLang
            // 
            this.colLang.Caption = "Sprache";
            this.colLang.FieldName = "Language";
            this.colLang.Name = "colLang";
            this.colLang.OptionsColumn.AllowEdit = false;
            this.colLang.OptionsColumn.AllowFocus = false;
            this.colLang.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLang.OptionsColumn.FixedWidth = true;
            this.colLang.OptionsColumn.ReadOnly = true;
            this.colLang.Visible = true;
            this.colLang.VisibleIndex = 0;
            // 
            // colDescr
            // 
            this.colDescr.Caption = "Beschreibung";
            this.colDescr.ColumnEdit = this.descriptionTextEdit;
            this.colDescr.FieldName = "Description";
            this.colDescr.Name = "colDescr";
            this.colDescr.Visible = true;
            this.colDescr.VisibleIndex = 1;
            this.colDescr.Width = 168;
            // 
            // descriptionTextEdit
            // 
            this.descriptionTextEdit.AutoHeight = false;
            this.descriptionTextEdit.Name = "descriptionTextEdit";
            // 
            // colShortDescr
            // 
            this.colShortDescr.Caption = "Kurzbeschreibung";
            this.colShortDescr.ColumnEdit = this.shortDescriptionTextEdit;
            this.colShortDescr.FieldName = "ShortDescription";
            this.colShortDescr.Name = "colShortDescr";
            this.colShortDescr.Visible = true;
            this.colShortDescr.VisibleIndex = 2;
            // 
            // shortDescriptionTextEdit
            // 
            this.shortDescriptionTextEdit.AutoHeight = false;
            this.shortDescriptionTextEdit.Name = "shortDescriptionTextEdit";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gcDescriptions;
            this.gridView3.Name = "gridView3";
            // 
            // UCDescriptions
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcDescriptions);
            this.Name = "UCDescriptions";
            this.Size = new System.Drawing.Size(347, 150);
            ((System.ComponentModel.ISupportInitialize)(this.gcDescriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDescriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDescriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortDescriptionTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDescriptions;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDescriptions;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplaySequence;
        private DevExpress.XtraGrid.Columns.GridColumn colLang;
        private DevExpress.XtraGrid.Columns.GridColumn colShortDescr;
        private DevExpress.XtraGrid.Columns.GridColumn colDescr;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.BindingSource bsDescriptions;
        protected System.Windows.Forms.BindingSource bsParent;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit shortDescriptionTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit descriptionTextEdit;
    }
}
