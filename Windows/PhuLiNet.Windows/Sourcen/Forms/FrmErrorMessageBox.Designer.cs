namespace Windows.Core.Forms
{
    partial class FrmErrorMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmErrorMessageBox));
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.meErrortext = new DevExpress.XtraEditors.MemoEdit();
            this.picError = new System.Windows.Forms.PictureBox();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.tlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.meErrortext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblInfo.Appearance.Font")));
            this.lblInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // meErrortext
            // 
            resources.ApplyResources(this.meErrortext, "meErrortext");
            this.meErrortext.Name = "meErrortext";
            this.meErrortext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.meErrortext.Properties.ReadOnly = true;
            this.meErrortext.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
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
            // FrmErrorMessageBox
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.picError);
            this.Controls.Add(this.meErrortext);
            this.Controls.Add(this.lblInfo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmErrorMessageBox";
            this.ShowIcon = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.meErrortext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblInfo;
        private DevExpress.XtraEditors.MemoEdit meErrortext;
        private System.Windows.Forms.PictureBox picError;
        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tlButtons;
        protected DevExpress.XtraEditors.SimpleButton btnOk;
    }
}