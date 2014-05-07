namespace Windows.Core.BaseForms
{
    partial class FrmOptionenBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptionenBase));
            this.xtcOptions = new DevExpress.XtraTab.XtraTabControl();
            this.xtpOptions = new DevExpress.XtraTab.XtraTabPage();
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLayout = new System.Windows.Forms.Panel();
            this.gcMisc = new DevExpress.XtraEditors.GroupControl();
            this.ceWaitForm = new DevExpress.XtraEditors.CheckEdit();
            this.gcFont = new DevExpress.XtraEditors.GroupControl();
            this.meInfo = new DevExpress.XtraEditors.MemoEdit();
            this.lblFont = new System.Windows.Forms.Label();
            this.sbStandardFont = new DevExpress.XtraEditors.SimpleButton();
            this.lblFontSize = new DevExpress.XtraEditors.LabelControl();
            this.ceFontBold = new DevExpress.XtraEditors.CheckEdit();
            this.spiFontSize = new DevExpress.XtraEditors.SpinEdit();
            this.fontEdit = new DevExpress.XtraEditors.FontEdit();
            this.gcLookAndFeel = new DevExpress.XtraEditors.GroupControl();
            this.lblStyles = new DevExpress.XtraEditors.LabelControl();
            this.rgStyles = new DevExpress.XtraEditors.RadioGroup();
            this.lbSkins = new DevExpress.XtraEditors.ListBoxControl();
            this.lblSkins = new System.Windows.Forms.Label();
            this.lblTableStyle = new DevExpress.XtraEditors.LabelControl();
            this.cboSchemas = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbAbbrechen = new DevExpress.XtraEditors.SimpleButton();
            this.sbOk = new DevExpress.XtraEditors.SimpleButton();
            this.xtpApplication = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcOptions)).BeginInit();
            this.xtcOptions.SuspendLayout();
            this.xtpOptions.SuspendLayout();
            this.tlpLayout.SuspendLayout();
            this.pnlLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMisc)).BeginInit();
            this.gcMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceWaitForm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFont)).BeginInit();
            this.gcFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontBold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiFontSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLookAndFeel)).BeginInit();
            this.gcLookAndFeel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgStyles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSkins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSchemas.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtcOptions
            // 
            resources.ApplyResources(this.xtcOptions, "xtcOptions");
            this.xtcOptions.Name = "xtcOptions";
            this.xtcOptions.SelectedTabPage = this.xtpOptions;
            this.xtcOptions.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpOptions,
            this.xtpApplication});
            // 
            // xtpOptions
            // 
            this.xtpOptions.Controls.Add(this.tlpLayout);
            this.xtpOptions.Name = "xtpOptions";
            resources.ApplyResources(this.xtpOptions, "xtpOptions");
            // 
            // tlpLayout
            // 
            resources.ApplyResources(this.tlpLayout, "tlpLayout");
            this.tlpLayout.Controls.Add(this.pnlLayout, 0, 0);
            this.tlpLayout.Controls.Add(this.sbAbbrechen, 2, 1);
            this.tlpLayout.Controls.Add(this.sbOk, 1, 1);
            this.tlpLayout.Name = "tlpLayout";
            // 
            // pnlLayout
            // 
            this.tlpLayout.SetColumnSpan(this.pnlLayout, 3);
            this.pnlLayout.Controls.Add(this.gcMisc);
            this.pnlLayout.Controls.Add(this.gcFont);
            this.pnlLayout.Controls.Add(this.gcLookAndFeel);
            resources.ApplyResources(this.pnlLayout, "pnlLayout");
            this.pnlLayout.Name = "pnlLayout";
            // 
            // gcMisc
            // 
            this.gcMisc.Controls.Add(this.ceWaitForm);
            resources.ApplyResources(this.gcMisc, "gcMisc");
            this.gcMisc.Name = "gcMisc";
            // 
            // ceWaitForm
            // 
            resources.ApplyResources(this.ceWaitForm, "ceWaitForm");
            this.ceWaitForm.Name = "ceWaitForm";
            this.ceWaitForm.Properties.Caption = resources.GetString("ceWaitForm.Properties.Caption");
            // 
            // gcFont
            // 
            this.gcFont.Controls.Add(this.meInfo);
            this.gcFont.Controls.Add(this.lblFont);
            this.gcFont.Controls.Add(this.sbStandardFont);
            this.gcFont.Controls.Add(this.lblFontSize);
            this.gcFont.Controls.Add(this.ceFontBold);
            this.gcFont.Controls.Add(this.spiFontSize);
            this.gcFont.Controls.Add(this.fontEdit);
            resources.ApplyResources(this.gcFont, "gcFont");
            this.gcFont.Name = "gcFont";
            // 
            // meInfo
            // 
            resources.ApplyResources(this.meInfo, "meInfo");
            this.meInfo.Name = "meInfo";
            this.meInfo.Properties.ReadOnly = true;
            this.meInfo.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.meInfo.UseOptimizedRendering = true;
            // 
            // lblFont
            // 
            resources.ApplyResources(this.lblFont, "lblFont");
            this.lblFont.Name = "lblFont";
            // 
            // sbStandardFont
            // 
            resources.ApplyResources(this.sbStandardFont, "sbStandardFont");
            this.sbStandardFont.Name = "sbStandardFont";
            this.sbStandardFont.Click += new System.EventHandler(this.sbStandardFont_Click);
            // 
            // lblFontSize
            // 
            resources.ApplyResources(this.lblFontSize, "lblFontSize");
            this.lblFontSize.Name = "lblFontSize";
            // 
            // ceFontBold
            // 
            resources.ApplyResources(this.ceFontBold, "ceFontBold");
            this.ceFontBold.Name = "ceFontBold";
            this.ceFontBold.Properties.Caption = resources.GetString("ceFontBold.Properties.Caption");
            // 
            // spiFontSize
            // 
            resources.ApplyResources(this.spiFontSize, "spiFontSize");
            this.spiFontSize.Name = "spiFontSize";
            this.spiFontSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spiFontSize.Properties.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.spiFontSize.Properties.MaxValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.spiFontSize.Properties.MinValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // fontEdit
            // 
            resources.ApplyResources(this.fontEdit, "fontEdit");
            this.fontEdit.Name = "fontEdit";
            this.fontEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fontEdit.Properties.Buttons"))))});
            // 
            // gcLookAndFeel
            // 
            this.gcLookAndFeel.Controls.Add(this.lblStyles);
            this.gcLookAndFeel.Controls.Add(this.rgStyles);
            this.gcLookAndFeel.Controls.Add(this.lbSkins);
            this.gcLookAndFeel.Controls.Add(this.lblSkins);
            this.gcLookAndFeel.Controls.Add(this.lblTableStyle);
            this.gcLookAndFeel.Controls.Add(this.cboSchemas);
            resources.ApplyResources(this.gcLookAndFeel, "gcLookAndFeel");
            this.gcLookAndFeel.Name = "gcLookAndFeel";
            // 
            // lblStyles
            // 
            resources.ApplyResources(this.lblStyles, "lblStyles");
            this.lblStyles.Name = "lblStyles";
            // 
            // rgStyles
            // 
            resources.ApplyResources(this.rgStyles, "rgStyles");
            this.rgStyles.Name = "rgStyles";
            this.rgStyles.Properties.Appearance.Options.UseTextOptions = true;
            this.rgStyles.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rgStyles.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.rgStyles.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgStyles.Properties.Items"), resources.GetString("rgStyles.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgStyles.Properties.Items2"), resources.GetString("rgStyles.Properties.Items3")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgStyles.Properties.Items4"), resources.GetString("rgStyles.Properties.Items5")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgStyles.Properties.Items6"), resources.GetString("rgStyles.Properties.Items7")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgStyles.Properties.Items8"), resources.GetString("rgStyles.Properties.Items9")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgStyles.Properties.Items10"), resources.GetString("rgStyles.Properties.Items11")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgStyles.Properties.Items12"), resources.GetString("rgStyles.Properties.Items13"))});
            // 
            // lbSkins
            // 
            resources.ApplyResources(this.lbSkins, "lbSkins");
            this.lbSkins.Name = "lbSkins";
            // 
            // lblSkins
            // 
            resources.ApplyResources(this.lblSkins, "lblSkins");
            this.lblSkins.Name = "lblSkins";
            // 
            // lblTableStyle
            // 
            resources.ApplyResources(this.lblTableStyle, "lblTableStyle");
            this.lblTableStyle.Name = "lblTableStyle";
            // 
            // cboSchemas
            // 
            resources.ApplyResources(this.cboSchemas, "cboSchemas");
            this.cboSchemas.Name = "cboSchemas";
            this.cboSchemas.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cboSchemas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboSchemas.Properties.Buttons"))))});
            this.cboSchemas.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F11);
            this.cboSchemas.Properties.DropDownRows = 18;
            this.cboSchemas.Properties.NullValuePrompt = resources.GetString("cboSchemas.Properties.NullValuePrompt");
            this.cboSchemas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // sbAbbrechen
            // 
            resources.ApplyResources(this.sbAbbrechen, "sbAbbrechen");
            this.sbAbbrechen.Name = "sbAbbrechen";
            this.sbAbbrechen.Click += new System.EventHandler(this.sbAbbrechen_Click);
            // 
            // sbOk
            // 
            resources.ApplyResources(this.sbOk, "sbOk");
            this.sbOk.Name = "sbOk";
            this.sbOk.Click += new System.EventHandler(this.sbOk_Click);
            // 
            // xtpApplication
            // 
            this.xtpApplication.Name = "xtpApplication";
            resources.ApplyResources(this.xtpApplication, "xtpApplication");
            // 
            // FrmOptionenBase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtcOptions);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmOptionenBase";
            this.RememberPosition = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmOptionenBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcOptions)).EndInit();
            this.xtcOptions.ResumeLayout(false);
            this.xtpOptions.ResumeLayout(false);
            this.tlpLayout.ResumeLayout(false);
            this.pnlLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMisc)).EndInit();
            this.gcMisc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceWaitForm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFont)).EndInit();
            this.gcFont.ResumeLayout(false);
            this.gcFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontBold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiFontSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLookAndFeel)).EndInit();
            this.gcLookAndFeel.ResumeLayout(false);
            this.gcLookAndFeel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgStyles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSkins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSchemas.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSkins;
        private DevExpress.XtraEditors.ListBoxControl lbSkins;
        private DevExpress.XtraEditors.RadioGroup rgStyles;
        private DevExpress.XtraEditors.SimpleButton sbOk;
        private DevExpress.XtraEditors.SimpleButton sbAbbrechen;
        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.Panel pnlLayout;
        protected DevExpress.XtraEditors.ComboBoxEdit cboSchemas;
        private DevExpress.XtraEditors.GroupControl gcLookAndFeel;
        private DevExpress.XtraEditors.GroupControl gcFont;
        public DevExpress.XtraTab.XtraTabPage xtpApplication;
        public DevExpress.XtraTab.XtraTabControl xtcOptions;
        protected DevExpress.XtraTab.XtraTabPage xtpOptions;
        private DevExpress.XtraEditors.CheckEdit ceWaitForm;
        private DevExpress.XtraEditors.GroupControl gcMisc;
        private DevExpress.XtraEditors.LabelControl lblStyles;
        private DevExpress.XtraEditors.LabelControl lblTableStyle;
        private DevExpress.XtraEditors.FontEdit fontEdit;
        private DevExpress.XtraEditors.SpinEdit spiFontSize;
        private DevExpress.XtraEditors.LabelControl lblFontSize;
        private DevExpress.XtraEditors.CheckEdit ceFontBold;
        private DevExpress.XtraEditors.SimpleButton sbStandardFont;
        private DevExpress.XtraEditors.MemoEdit meInfo;
        private System.Windows.Forms.Label lblFont;
    }
}

