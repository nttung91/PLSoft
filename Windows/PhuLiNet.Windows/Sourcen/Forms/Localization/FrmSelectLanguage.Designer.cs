using PhuLiNet.Business.Common.Languages;

namespace Windows.Core.Forms.Localization
{
    partial class FrmSelectLanguage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectLanguage));
            this.leLanguage = new DevExpress.XtraEditors.LookUpEdit();
            this.languageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbLanguage = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // leLanguage
            // 
            resources.ApplyResources(this.leLanguage, "leLanguage");
            this.leLanguage.Name = "leLanguage";
            this.leLanguage.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.leLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leLanguage.Properties.Buttons"))))});
            this.leLanguage.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leLanguage.Properties.Columns"), resources.GetString("leLanguage.Properties.Columns1"), ((int)(resources.GetObject("leLanguage.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("leLanguage.Properties.Columns3"))), resources.GetString("leLanguage.Properties.Columns4"), ((bool)(resources.GetObject("leLanguage.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("leLanguage.Properties.Columns6"))))});
            this.leLanguage.Properties.DataSource = this.languageBindingSource;
            this.leLanguage.Properties.DisplayMember = "Name";
            this.leLanguage.Properties.NullText = resources.GetString("leLanguage.Properties.NullText");
            this.leLanguage.Properties.NullValuePrompt = resources.GetString("leLanguage.Properties.NullValuePrompt");
            this.leLanguage.Properties.ValueMember = "LanguageObject";
            this.leLanguage.EditValueChanged += new System.EventHandler(this.leLanguage_EditValueChanged);
            // 
            // languageBindingSource
            // 
            this.languageBindingSource.DataSource = typeof(Language);
            // 
            // lbLanguage
            // 
            resources.ApplyResources(this.lbLanguage, "lbLanguage");
            this.lbLanguage.Name = "lbLanguage";
            // 
            // FrmSelectLanguage
            // 
            this.AcceptButtonVisible = true;
            resources.ApplyResources(this, "$this");
            this.CancelButtonVisible = true;
            this.Controls.Add(this.leLanguage);
            this.Controls.Add(this.lbLanguage);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmSelectLanguage";
            this.RememberPosition = false;
            this.Controls.SetChildIndex(this.lbLanguage, 0);
            this.Controls.SetChildIndex(this.leLanguage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit leLanguage;
        private DevExpress.XtraEditors.LabelControl lbLanguage;
        private System.Windows.Forms.BindingSource languageBindingSource;
    }
}
