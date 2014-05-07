using PhuLiNet.Business.Common.Rules;

namespace Windows.Core.Validation
{
	partial class UCBrokenRules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCBrokenRules));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gcBrokenRules = new DevExpress.XtraGrid.GridControl();
            this.bsExtendedBrokenRule = new System.Windows.Forms.BindingSource(this.components);
            this.prBrokenRules = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.riicSeverity = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.icStatus = new DevExpress.Utils.ImageCollection(this.components);
            this.ribeJumpTo = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rimeDescr = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gvBrokenRules = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLink = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcBrokenRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsExtendedBrokenRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicSeverity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeJumpTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rimeDescr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBrokenRules)).BeginInit();
            this.SuspendLayout();
            // 
            // gcBrokenRules
            // 
            this.gcBrokenRules.DataSource = this.bsExtendedBrokenRule;
            resources.ApplyResources(this.gcBrokenRules, "gcBrokenRules");
            this.gcBrokenRules.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcBrokenRules.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcBrokenRules.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcBrokenRules.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcBrokenRules.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcBrokenRules.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcBrokenRules.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcBrokenRules.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcBrokenRules.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcBrokenRules.ExternalRepository = this.prBrokenRules;
            this.gcBrokenRules.MainView = this.gvBrokenRules;
            this.gcBrokenRules.Name = "gcBrokenRules";
            this.gcBrokenRules.UseEmbeddedNavigator = true;
            this.gcBrokenRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBrokenRules});
            // 
            // bsExtendedBrokenRule
            // 
            this.bsExtendedBrokenRule.DataSource = typeof(PhuLiNet.Business.Common.Rules.ExtendedBrokenRule);
            // 
            // prBrokenRules
            // 
            this.prBrokenRules.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riicSeverity,
            this.ribeJumpTo,
            this.rimeDescr});
            // 
            // riicSeverity
            // 
            this.riicSeverity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riicSeverity.Buttons"))))});
            this.riicSeverity.Name = "riicSeverity";
            this.riicSeverity.SmallImages = this.icStatus;
            // 
            // icStatus
            // 
            this.icStatus.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icStatus.ImageStream")));
            // 
            // ribeJumpTo
            // 
            resources.ApplyResources(this.ribeJumpTo, "ribeJumpTo");
            this.ribeJumpTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ribeJumpTo.Buttons"))), resources.GetString("ribeJumpTo.Buttons1"), ((int)(resources.GetObject("ribeJumpTo.Buttons2"))), ((bool)(resources.GetObject("ribeJumpTo.Buttons3"))), ((bool)(resources.GetObject("ribeJumpTo.Buttons4"))), ((bool)(resources.GetObject("ribeJumpTo.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("ribeJumpTo.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("ribeJumpTo.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("ribeJumpTo.Buttons8"), ((object)(resources.GetObject("ribeJumpTo.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("ribeJumpTo.Buttons10"))), ((bool)(resources.GetObject("ribeJumpTo.Buttons11"))))});
            this.ribeJumpTo.Name = "ribeJumpTo";
            this.ribeJumpTo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ribeJumpTo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ribeJumpTo_ButtonClick);
            // 
            // rimeDescr
            // 
            this.rimeDescr.Name = "rimeDescr";
            // 
            // gvBrokenRules
            // 
            this.gvBrokenRules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeverity,
            this.colDescription,
            this.colLink});
            this.gvBrokenRules.GridControl = this.gcBrokenRules;
            this.gvBrokenRules.Name = "gvBrokenRules";
            this.gvBrokenRules.OptionsView.RowAutoHeight = true;
            this.gvBrokenRules.OptionsView.ShowGroupPanel = false;
            this.gvBrokenRules.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSeverity, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSeverity
            // 
            this.colSeverity.AppearanceHeader.Options.UseTextOptions = true;
            this.colSeverity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colSeverity, "colSeverity");
            this.colSeverity.ColumnEdit = this.riicSeverity;
            this.colSeverity.FieldName = "Severity";
            this.colSeverity.Name = "colSeverity";
            this.colSeverity.OptionsColumn.AllowFocus = false;
            this.colSeverity.OptionsColumn.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colDescription, "colDescription");
            this.colDescription.ColumnEdit = this.rimeDescr;
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowFocus = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            // 
            // colLink
            // 
            this.colLink.AppearanceHeader.Options.UseTextOptions = true;
            this.colLink.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colLink, "colLink");
            this.colLink.ColumnEdit = this.ribeJumpTo;
            this.colLink.Name = "colLink";
            this.colLink.OptionsColumn.ReadOnly = true;
            this.colLink.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            // 
            // UCBrokenRules
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcBrokenRules);
            this.Name = "UCBrokenRules";
            ((System.ComponentModel.ISupportInitialize)(this.gcBrokenRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsExtendedBrokenRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicSeverity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeJumpTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rimeDescr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBrokenRules)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraGrid.GridControl gcBrokenRules;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBrokenRules;
        private System.Windows.Forms.BindingSource bsExtendedBrokenRule;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colLink;
        private DevExpress.Utils.ImageCollection icStatus;
        private DevExpress.XtraEditors.Repository.PersistentRepository prBrokenRules;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicSeverity;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribeJumpTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rimeDescr;

    }
}
