namespace Windows.Core.Forms
{
    partial class FrmWait
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWait));
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.lblStatusText = new DevExpress.XtraEditors.LabelControl();
            this.marqueeProgressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.peLogo = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peLogo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblInfo.Appearance.Font")));
            this.lblInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // lblStatusText
            // 
            this.lblStatusText.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblStatusText.Appearance.Font")));
            this.lblStatusText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lblStatusText, "lblStatusText");
            this.lblStatusText.Name = "lblStatusText";
            // 
            // marqueeProgressBar
            // 
            resources.ApplyResources(this.marqueeProgressBar, "marqueeProgressBar");
            this.marqueeProgressBar.Name = "marqueeProgressBar";
            // 
            // peLogo
            // 
            this.peLogo.EditValue = global::Windows.Core.Properties.Resources.manor_header_1_logo;
            resources.ApplyResources(this.peLogo, "peLogo");
            this.peLogo.Name = "peLogo";
            this.peLogo.Properties.ReadOnly = true;
            // 
            // FrmWait
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.peLogo);
            this.Controls.Add(this.marqueeProgressBar);
            this.Controls.Add(this.lblStatusText);
            this.Controls.Add(this.lblInfo);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWait";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peLogo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblInfo;
        private DevExpress.XtraEditors.LabelControl lblStatusText;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBar;
        private DevExpress.XtraEditors.PictureEdit peLogo;
    }
}