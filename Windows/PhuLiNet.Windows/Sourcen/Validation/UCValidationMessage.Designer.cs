namespace Windows.Core.Validation
{
    partial class UCValidationMessage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCValidationMessage));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.gcValidationMessage = new DevExpress.XtraGrid.GridControl();
            this.iValidationMessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prValidationMessage = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.riicSeverity = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.icStatus = new DevExpress.Utils.ImageCollection(this.components);
            this.ribeJumpTo = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gvValidationMessage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAffectedDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAffectedId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcValidationMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iValidationMessageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicSeverity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeJumpTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvValidationMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // gcValidationMessage
            // 
            this.gcValidationMessage.DataSource = this.iValidationMessageBindingSource;
            this.gcValidationMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcValidationMessage.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcValidationMessage.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcValidationMessage.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcValidationMessage.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcValidationMessage.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcValidationMessage.ExternalRepository = this.prValidationMessage;
            this.gcValidationMessage.Location = new System.Drawing.Point(0, 0);
            this.gcValidationMessage.MainView = this.gvValidationMessage;
            this.gcValidationMessage.Name = "gcValidationMessage";
            this.gcValidationMessage.Size = new System.Drawing.Size(596, 319);
            this.gcValidationMessage.TabIndex = 0;
            this.gcValidationMessage.UseEmbeddedNavigator = true;
            this.gcValidationMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvValidationMessage});
            // 
            // iValidationMessageBindingSource
            // 
            this.iValidationMessageBindingSource.DataSource = typeof(PhuLiNet.Business.Common.Messages.IValidationMessage);
            // 
            // prValidationMessage
            // 
            this.prValidationMessage.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riicSeverity,
            this.ribeJumpTo});
            // 
            // riicSeverity
            // 
            this.riicSeverity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riicSeverity.Name = "riicSeverity";
            this.riicSeverity.SmallImages = this.icStatus;
            // 
            // icStatus
            // 
            this.icStatus.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icStatus.ImageStream")));
            // 
            // ribeJumpTo
            // 
            this.ribeJumpTo.AutoHeight = false;
            toolTipTitleItem1.Text = "Eingabe anzeigen";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Klicken Sie hier, um den Fehler anzuzeigen.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.ribeJumpTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close, "", superToolTip1)});
            this.ribeJumpTo.Name = "ribeJumpTo";
            this.ribeJumpTo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gvValidationMessage
            // 
            this.gvValidationMessage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeverity,
            this.colDescription,
            this.colAffectedDescr,
            this.colAffectedId});
            this.gvValidationMessage.GridControl = this.gcValidationMessage;
            this.gvValidationMessage.Name = "gvValidationMessage";
            this.gvValidationMessage.OptionsView.ShowGroupPanel = false;
            this.gvValidationMessage.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSeverity, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSeverity
            // 
            this.colSeverity.Caption = "Typ";
            this.colSeverity.ColumnEdit = this.riicSeverity;
            this.colSeverity.FieldName = "Severity";
            this.colSeverity.Name = "colSeverity";
            this.colSeverity.OptionsColumn.AllowFocus = false;
            this.colSeverity.OptionsColumn.ReadOnly = true;
            this.colSeverity.Visible = true;
            this.colSeverity.VisibleIndex = 0;
            this.colSeverity.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Meldung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 202;
            // 
            // colAffectedDescr
            // 
            this.colAffectedDescr.Caption = "Beschreibung";
            this.colAffectedDescr.FieldName = "AffectedDescr";
            this.colAffectedDescr.Name = "colAffectedDescr";
            this.colAffectedDescr.OptionsColumn.ReadOnly = true;
            this.colAffectedDescr.Visible = true;
            this.colAffectedDescr.VisibleIndex = 3;
            this.colAffectedDescr.Width = 153;
            // 
            // colAffectedId
            // 
            this.colAffectedId.Caption = "Betrifft";
            this.colAffectedId.FieldName = "AffectedId";
            this.colAffectedId.Name = "colAffectedId";
            this.colAffectedId.Visible = true;
            this.colAffectedId.VisibleIndex = 2;
            this.colAffectedId.Width = 120;
            // 
            // ValidationMessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcValidationMessage);
            this.Name = "ValidationMessageControl";
            this.Size = new System.Drawing.Size(596, 319);
            ((System.ComponentModel.ISupportInitialize)(this.gcValidationMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iValidationMessageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicSeverity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeJumpTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvValidationMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcValidationMessage;
        private DevExpress.XtraGrid.Views.Grid.GridView gvValidationMessage;
        private System.Windows.Forms.BindingSource iValidationMessageBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAffectedDescr;
        private DevExpress.XtraEditors.Repository.PersistentRepository prValidationMessage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicSeverity;
        private DevExpress.Utils.ImageCollection icStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribeJumpTo;
        private DevExpress.XtraGrid.Columns.GridColumn colAffectedId;
    }
}
