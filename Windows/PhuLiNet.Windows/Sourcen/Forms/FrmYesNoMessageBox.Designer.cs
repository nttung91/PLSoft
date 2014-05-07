namespace Windows.Core.Forms
{
    partial class FrmYesNoMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYesNoMessageBox));
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbYes = new DevExpress.XtraEditors.SimpleButton();
            this.meMessage = new DevExpress.XtraEditors.MemoEdit();
            this.sbNo = new DevExpress.XtraEditors.SimpleButton();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.chkDisplay = new DevExpress.XtraEditors.CheckEdit();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.tlButtons = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisplay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbCancel
            // 
            resources.ApplyResources(this.sbCancel, "sbCancel");
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Name = "sbCancel";
            // 
            // sbYes
            // 
            resources.ApplyResources(this.sbYes, "sbYes");
            this.sbYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.sbYes.Name = "sbYes";
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
            // sbNo
            // 
            resources.ApplyResources(this.sbNo, "sbNo");
            this.sbNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.sbNo.Name = "sbNo";
            // 
            // picQuestion
            // 
            resources.ApplyResources(this.picQuestion, "picQuestion");
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.TabStop = false;
            // 
            // chkDisplay
            // 
            resources.ApplyResources(this.chkDisplay, "chkDisplay");
            this.chkDisplay.Name = "chkDisplay";
            this.chkDisplay.Properties.Caption = resources.GetString("chkDisplay.Properties.Caption");
            this.chkDisplay.CheckedChanged += new System.EventHandler(this.chkDisplay_CheckedChanged);
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
            this.tlButtons.Controls.Add(this.sbYes, 1, 0);
            this.tlButtons.Controls.Add(this.sbNo, 2, 0);
            this.tlButtons.Controls.Add(this.sbCancel, 4, 0);
            this.tlButtons.Name = "tlButtons";
            // 
            // FrmYesNoMessageBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.sbCancel;
            this.ControlBox = false;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.chkDisplay);
            this.Controls.Add(this.picQuestion);
            this.Controls.Add(this.meMessage);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmYesNoMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisplay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbYes;
        private DevExpress.XtraEditors.MemoEdit meMessage;
        private DevExpress.XtraEditors.SimpleButton sbNo;
        private System.Windows.Forms.PictureBox picQuestion;
        private DevExpress.XtraEditors.CheckEdit chkDisplay;
        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tlButtons;
    }
}