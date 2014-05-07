namespace Windows.Core.Forms
{
    partial class FrmWarningMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWarningMessageBox));
            this.meMessage = new DevExpress.XtraEditors.MemoEdit();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.tlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // meMessage
            // 
            resources.ApplyResources(this.meMessage, "meMessage");
            this.meMessage.Name = "meMessage";
            this.meMessage.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("meMessage.Properties.Appearance.Font")));
            this.meMessage.Properties.Appearance.Options.UseFont = true;
            this.meMessage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.meMessage.Properties.ReadOnly = true;
            this.meMessage.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            // 
            // picInfo
            // 
            resources.ApplyResources(this.picInfo, "picInfo");
            this.picInfo.Name = "picInfo";
            this.picInfo.TabStop = false;
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
            // FrmWarningMessageBox
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.picInfo);
            this.Controls.Add(this.meMessage);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmWarningMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit meMessage;
        private System.Windows.Forms.PictureBox picInfo;
        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tlButtons;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}