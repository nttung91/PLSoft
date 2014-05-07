namespace Windows.Core.Forms
{
    partial class FrmDisappearInfoMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisappearInfoMessageBox));
            this.meMessage = new DevExpress.XtraEditors.MemoEdit();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.timerDisappear = new System.Windows.Forms.Timer();
            this.lblDisappearInfo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
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
            // timerDisappear
            // 
            this.timerDisappear.Tick += new System.EventHandler(this.timerDisappear_Tick);
            // 
            // lblDisappearInfo
            // 
            resources.ApplyResources(this.lblDisappearInfo, "lblDisappearInfo");
            this.lblDisappearInfo.Name = "lblDisappearInfo";
            // 
            // FrmDisappearInfoMessageBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.lblDisappearInfo);
            this.Controls.Add(this.picInfo);
            this.Controls.Add(this.meMessage);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmDisappearInfoMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FrmDisappearInfoMessageBox_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit meMessage;
        private System.Windows.Forms.PictureBox picInfo;
        private System.Windows.Forms.Timer timerDisappear;
        private DevExpress.XtraEditors.LabelControl lblDisappearInfo;
    }
}