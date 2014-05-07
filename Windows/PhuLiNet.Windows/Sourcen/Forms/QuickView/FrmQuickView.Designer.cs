namespace Windows.Core.Forms.QuickView
{
    partial class FrmQuickView
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
            this.pgcQuick = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgcQuick)).BeginInit();
            this.SuspendLayout();
            // 
            // pgcQuick
            // 
            this.pgcQuick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgcQuick.Location = new System.Drawing.Point(0, 0);
            this.pgcQuick.Name = "pgcQuick";
            this.pgcQuick.OptionsBehavior.Editable = false;
            this.pgcQuick.OptionsView.ShowButtons = false;
            this.pgcQuick.ServiceProvider = null;
            this.pgcQuick.Size = new System.Drawing.Size(331, 288);
            this.pgcQuick.TabIndex = 0;
            // 
            // FrmQuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 288);
            this.Controls.Add(this.pgcQuick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmQuickView";
            this.Text = "QuickView";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgcQuick)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl pgcQuick;
	}
}