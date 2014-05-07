namespace Windows.Core.Forms
{
    partial class FrmProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProgress));
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.lblStatusText = new DevExpress.XtraEditors.LabelControl();
            this.pbgProgress = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbgProgress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblInfo.Appearance.DisabledImage")));
            this.lblInfo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblInfo.Appearance.Font")));
            this.lblInfo.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblInfo.Appearance.GradientMode")));
            this.lblInfo.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblInfo.Appearance.HoverImage")));
            this.lblInfo.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblInfo.Appearance.Image")));
            this.lblInfo.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblInfo.Appearance.PressedImage")));
            this.lblInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInfo.Name = "lblInfo";
            // 
            // lblStatusText
            // 
            resources.ApplyResources(this.lblStatusText, "lblStatusText");
            this.lblStatusText.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblStatusText.Appearance.DisabledImage")));
            this.lblStatusText.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblStatusText.Appearance.Font")));
            this.lblStatusText.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblStatusText.Appearance.GradientMode")));
            this.lblStatusText.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblStatusText.Appearance.HoverImage")));
            this.lblStatusText.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblStatusText.Appearance.Image")));
            this.lblStatusText.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblStatusText.Appearance.PressedImage")));
            this.lblStatusText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatusText.Name = "lblStatusText";
            // 
            // pbgProgress
            // 
            resources.ApplyResources(this.pbgProgress, "pbgProgress");
            this.pbgProgress.Name = "pbgProgress";
            this.pbgProgress.Properties.AccessibleDescription = resources.GetString("pbgProgress.Properties.AccessibleDescription");
            this.pbgProgress.Properties.AccessibleName = resources.GetString("pbgProgress.Properties.AccessibleName");
            this.pbgProgress.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pbgProgress.Properties.Appearance.GradientMode")));
            this.pbgProgress.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("pbgProgress.Properties.Appearance.Image")));
            this.pbgProgress.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pbgProgress.Properties.AppearanceDisabled.GradientMode")));
            this.pbgProgress.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("pbgProgress.Properties.AppearanceDisabled.Image")));
            this.pbgProgress.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pbgProgress.Properties.AppearanceFocused.GradientMode")));
            this.pbgProgress.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("pbgProgress.Properties.AppearanceFocused.Image")));
            this.pbgProgress.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pbgProgress.Properties.AppearanceReadOnly.GradientMode")));
            this.pbgProgress.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("pbgProgress.Properties.AppearanceReadOnly.Image")));
            this.pbgProgress.Properties.AutoHeight = ((bool)(resources.GetObject("pbgProgress.Properties.AutoHeight")));
            this.pbgProgress.Properties.ShowTitle = true;
            // 
            // FrmProgress
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pbgProgress);
            this.Controls.Add(this.lblStatusText);
            this.Controls.Add(this.lblInfo);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbgProgress.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblInfo;
        private DevExpress.XtraEditors.LabelControl lblStatusText;
        private DevExpress.XtraEditors.ProgressBarControl pbgProgress;
    }
}