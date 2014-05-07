namespace Windows.Core.Forms.AdminConsole
{
    partial class FrmAssemblies
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssemblies));
            this.gcAssemblies = new DevExpress.XtraGrid.GridControl();
            this.assemblyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvAssemblies = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlobalAssemblyCache = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuildType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssemblyVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAssemblies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assemblyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssemblies)).BeginInit();
            this.SuspendLayout();
            // 
            // gcAssemblies
            // 
            this.gcAssemblies.DataSource = this.assemblyBindingSource;
            this.gcAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAssemblies.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcAssemblies.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcAssemblies.Location = new System.Drawing.Point(0, 0);
            this.gcAssemblies.MainView = this.gvAssemblies;
            this.gcAssemblies.Name = "gcAssemblies";
            this.gcAssemblies.Size = new System.Drawing.Size(870, 424);
            this.gcAssemblies.TabIndex = 1;
            this.gcAssemblies.UseEmbeddedNavigator = true;
            this.gcAssemblies.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAssemblies});
            // 
            // assemblyBindingSource
            // 
            this.assemblyBindingSource.DataSource = typeof(Windows.Core.Forms.AdminConsole.AssemblyInformation);
            // 
            // gvAssemblies
            // 
            this.gvAssemblies.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colLocation,
            this.colGlobalAssemblyCache,
            this.colFileDate,
            this.colAssemblyVersion,
            this.colFileVersion,
            this.colBuildType});
            this.gvAssemblies.GridControl = this.gcAssemblies;
            this.gvAssemblies.Name = "gvAssemblies";
            this.gvAssemblies.OptionsView.ShowAutoFilterRow = true;
            this.gvAssemblies.OptionsView.ShowGroupPanel = false;
            this.gvAssemblies.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFullName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFullName
            // 
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.ReadOnly = true;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 0;
            this.colFullName.Width = 256;
            // 
            // colLocation
            // 
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.OptionsColumn.ReadOnly = true;
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 1;
            this.colLocation.Width = 257;
            // 
            // colGlobalAssemblyCache
            // 
            this.colGlobalAssemblyCache.AppearanceHeader.Options.UseTextOptions = true;
            this.colGlobalAssemblyCache.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGlobalAssemblyCache.Caption = "GAC";
            this.colGlobalAssemblyCache.FieldName = "GlobalAssemblyCache";
            this.colGlobalAssemblyCache.Name = "colGlobalAssemblyCache";
            this.colGlobalAssemblyCache.OptionsColumn.ReadOnly = true;
            this.colGlobalAssemblyCache.Visible = true;
            this.colGlobalAssemblyCache.VisibleIndex = 6;
            this.colGlobalAssemblyCache.Width = 54;
            // 
            // colFileDate
            // 
            this.colFileDate.FieldName = "FileDate";
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.Visible = true;
            this.colFileDate.VisibleIndex = 2;
            this.colFileDate.Width = 139;
            // 
            // colFileVersion
            // 
            this.colFileVersion.FieldName = "FileVersion";
            this.colFileVersion.Name = "colFileVersion";
            this.colFileVersion.Visible = true;
            this.colFileVersion.VisibleIndex = 4;
            this.colFileVersion.Width = 73;
            // 
            // colBuildType
            // 
            this.colBuildType.FieldName = "BuildType";
            this.colBuildType.Name = "colBuildType";
            this.colBuildType.Visible = true;
            this.colBuildType.VisibleIndex = 5;
            this.colBuildType.Width = 73;
            // 
            // colAssemblyVersion
            // 
            this.colAssemblyVersion.FieldName = "AssemblyVersion";
            this.colAssemblyVersion.Name = "colAssemblyVersion";
            this.colAssemblyVersion.Visible = true;
            this.colAssemblyVersion.VisibleIndex = 3;
            // 
            // FrmAssemblies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 424);
            this.Controls.Add(this.gcAssemblies);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmAssemblies";
            this.Text = "AppDomain Assemblies";
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAssemblies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assemblyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssemblies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcAssemblies;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAssemblies;
        private System.Windows.Forms.BindingSource assemblyBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colGlobalAssemblyCache;
        private DevExpress.XtraGrid.Columns.GridColumn colFileDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBuildType;
        private DevExpress.XtraGrid.Columns.GridColumn colFileVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colAssemblyVersion;
    }
}