namespace Windows.Core.Forms.Validation
{
    partial class FrmBrokenRules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrokenRules));
            this.brokenRulesControl = new Windows.Core.Validation.UCBrokenRules();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            this.SuspendLayout();
            // 
            // brokenRulesControl
            // 
            resources.ApplyResources(this.brokenRulesControl, "brokenRulesControl");
            this.brokenRulesControl.Name = "brokenRulesControl";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblMessage.Appearance.DisabledImage")));
            this.lblMessage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblMessage.Appearance.Font")));
            this.lblMessage.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblMessage.Appearance.GradientMode")));
            this.lblMessage.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblMessage.Appearance.HoverImage")));
            this.lblMessage.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblMessage.Appearance.Image")));
            this.lblMessage.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblMessage.Appearance.PressedImage")));
            this.lblMessage.Name = "lblMessage";
            // 
            // FrmBrokenRules
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.brokenRulesControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmBrokenRules";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBrokenRules_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Windows.Core.Validation.UCBrokenRules brokenRulesControl;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblMessage;

    }
}