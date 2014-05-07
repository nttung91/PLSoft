namespace Windows.Core.Forms.Environment
{
    partial class FrmEnvironmentVariables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnvironmentVariables));
            this.gcEnvVars = new DevExpress.XtraGrid.GridControl();
            this.gvEnvVars = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbeEnvVarType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEnvVars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnvVars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeEnvVarType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcEnvVars
            // 
            resources.ApplyResources(this.gcEnvVars, "gcEnvVars");
            this.gcEnvVars.EmbeddedNavigator.AccessibleDescription = resources.GetString("gcEnvVars.EmbeddedNavigator.AccessibleDescription");
            this.gcEnvVars.EmbeddedNavigator.AccessibleName = resources.GetString("gcEnvVars.EmbeddedNavigator.AccessibleName");
            this.gcEnvVars.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gcEnvVars.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gcEnvVars.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gcEnvVars.EmbeddedNavigator.Anchor")));
            this.gcEnvVars.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gcEnvVars.EmbeddedNavigator.BackgroundImage")));
            this.gcEnvVars.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gcEnvVars.EmbeddedNavigator.BackgroundImageLayout")));
            this.gcEnvVars.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gcEnvVars.EmbeddedNavigator.ImeMode")));
            this.gcEnvVars.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gcEnvVars.EmbeddedNavigator.TextLocation")));
            this.gcEnvVars.EmbeddedNavigator.ToolTip = resources.GetString("gcEnvVars.EmbeddedNavigator.ToolTip");
            this.gcEnvVars.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gcEnvVars.EmbeddedNavigator.ToolTipIconType")));
            this.gcEnvVars.EmbeddedNavigator.ToolTipTitle = resources.GetString("gcEnvVars.EmbeddedNavigator.ToolTipTitle");
            this.gcEnvVars.MainView = this.gvEnvVars;
            this.gcEnvVars.Name = "gcEnvVars";
            this.gcEnvVars.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEnvVars});
            // 
            // gvEnvVars
            // 
            resources.ApplyResources(this.gvEnvVars, "gvEnvVars");
            this.gvEnvVars.GridControl = this.gcEnvVars;
            this.gvEnvVars.Name = "gvEnvVars";
            // 
            // cbeEnvVarType
            // 
            resources.ApplyResources(this.cbeEnvVarType, "cbeEnvVarType");
            this.cbeEnvVarType.Name = "cbeEnvVarType";
            this.cbeEnvVarType.Properties.AccessibleDescription = resources.GetString("cbeEnvVarType.Properties.AccessibleDescription");
            this.cbeEnvVarType.Properties.AccessibleName = resources.GetString("cbeEnvVarType.Properties.AccessibleName");
            this.cbeEnvVarType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cbeEnvVarType.Properties.AutoHeight = ((bool)(resources.GetObject("cbeEnvVarType.Properties.AutoHeight")));
            this.cbeEnvVarType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbeEnvVarType.Properties.Buttons"))))});
            this.cbeEnvVarType.Properties.Items.AddRange(new object[] {
            resources.GetString("cbeEnvVarType.Properties.Items"),
            resources.GetString("cbeEnvVarType.Properties.Items1"),
            resources.GetString("cbeEnvVarType.Properties.Items2")});
            this.cbeEnvVarType.Properties.NullValuePrompt = resources.GetString("cbeEnvVarType.Properties.NullValuePrompt");
            this.cbeEnvVarType.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbeEnvVarType.Properties.NullValuePromptShowForEmptyValue")));
            this.cbeEnvVarType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeEnvVarType.SelectedIndexChanged += new System.EventHandler(this.cbeEnvVarType_SelectedIndexChanged);
            // 
            // FrmEnvironmentVariables
            // 
            this.AcceptButtonVisible = true;
            resources.ApplyResources(this, "$this");
            this.CancelButtonText = "&Schliessen";
            this.CancelButtonVisible = true;
            this.Controls.Add(this.gcEnvVars);
            this.Controls.Add(this.cbeEnvVarType);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmEnvironmentVariables";
            this.Controls.SetChildIndex(this.cbeEnvVarType, 0);
            this.Controls.SetChildIndex(this.gcEnvVars, 0);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEnvVars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnvVars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeEnvVarType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcEnvVars;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEnvVars;
        private DevExpress.XtraEditors.ComboBoxEdit cbeEnvVarType;
    }
}
