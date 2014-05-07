namespace Windows.Core.Forms
{
    partial class FrmExceptionMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExceptionMessageBox));
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.picError = new System.Windows.Forms.PictureBox();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.tlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.tabException = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.meExceptionText = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.meInnerException = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.meStackTrace = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabException)).BeginInit();
            this.tabException.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meExceptionText.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meInnerException.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meStackTrace.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblInfo.Appearance.Font")));
            this.lblInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // picError
            // 
            resources.ApplyResources(this.picError, "picError");
            this.picError.Name = "picError";
            this.picError.TabStop = false;
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
            this.tlButtons.Controls.Add(this.btnOk, 1, 0);
            this.tlButtons.Name = "tlButtons";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            // 
            // tabException
            // 
            resources.ApplyResources(this.tabException, "tabException");
            this.tabException.Name = "tabException";
            this.tabException.SelectedTabPage = this.xtraTabPage1;
            this.tabException.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.meExceptionText);
            this.xtraTabPage1.Controls.Add(this.lblInfo);
            this.xtraTabPage1.Controls.Add(this.picError);
            this.xtraTabPage1.Name = "xtraTabPage1";
            resources.ApplyResources(this.xtraTabPage1, "xtraTabPage1");
            // 
            // meExceptionText
            // 
            resources.ApplyResources(this.meExceptionText, "meExceptionText");
            this.meExceptionText.Name = "meExceptionText";
            this.meExceptionText.Properties.ReadOnly = true;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.meInnerException);
            this.xtraTabPage2.Name = "xtraTabPage2";
            resources.ApplyResources(this.xtraTabPage2, "xtraTabPage2");
            // 
            // meInnerException
            // 
            resources.ApplyResources(this.meInnerException, "meInnerException");
            this.meInnerException.Name = "meInnerException";
            this.meInnerException.Properties.ReadOnly = true;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.meStackTrace);
            this.xtraTabPage3.Name = "xtraTabPage3";
            resources.ApplyResources(this.xtraTabPage3, "xtraTabPage3");
            // 
            // meStackTrace
            // 
            resources.ApplyResources(this.meStackTrace, "meStackTrace");
            this.meStackTrace.Name = "meStackTrace";
            this.meStackTrace.Properties.ReadOnly = true;
            // 
            // FrmExceptionMessageBox
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.tabException);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmExceptionMessageBox";
            this.ShowIcon = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabException)).EndInit();
            this.tabException.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meExceptionText.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meInnerException.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meStackTrace.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblInfo;
        private System.Windows.Forms.PictureBox picError;
        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tlButtons;
        protected DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraTab.XtraTabControl tabException;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.MemoEdit meExceptionText;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.MemoEdit meInnerException;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.MemoEdit meStackTrace;
    }
}