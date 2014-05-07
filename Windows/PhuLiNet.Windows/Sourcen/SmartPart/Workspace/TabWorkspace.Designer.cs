namespace Windows.Core.SmartPart.Workspace
{
    partial class TabWorkspace
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.smartPartPlaceholder = new Windows.Core.SmartPart.Controls.SmartPartPlaceholder();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.barSmartParts = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // smartPartPlaceholder
            // 
            this.smartPartPlaceholder.BackColor = System.Drawing.Color.Transparent;
            this.smartPartPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smartPartPlaceholder.Location = new System.Drawing.Point(24, 0);
            this.smartPartPlaceholder.Margin = new System.Windows.Forms.Padding(2);
            this.smartPartPlaceholder.Name = "smartPartPlaceholder";
            this.smartPartPlaceholder.PlaceholderName = "Shows the active Smart Part.";
            this.smartPartPlaceholder.Size = new System.Drawing.Size(539, 282);
            this.smartPartPlaceholder.TabIndex = 0;
            this.smartPartPlaceholder.Text = "smartPartPlaceholder";
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barSmartParts});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.MaxItemId = 2;
            // 
            // barSmartParts
            // 
            this.barSmartParts.BarName = "Tools";
            this.barSmartParts.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Left;
            this.barSmartParts.DockCol = 0;
            this.barSmartParts.DockRow = 0;
            this.barSmartParts.DockStyle = DevExpress.XtraBars.BarDockStyle.Left;
            this.barSmartParts.OptionsBar.AllowQuickCustomization = false;
            this.barSmartParts.OptionsBar.DisableClose = true;
            this.barSmartParts.OptionsBar.DrawDragBorder = false;
            this.barSmartParts.OptionsBar.RotateWhenVertical = false;
            this.barSmartParts.OptionsBar.UseWholeRow = true;
            this.barSmartParts.Text = "Tools";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(563, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 282);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(563, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(24, 282);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(563, 0);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 282);
            // 
            // TabWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.smartPartPlaceholder);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TabWorkspace";
            this.Size = new System.Drawing.Size(563, 282);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Core.SmartPart.Controls.SmartPartPlaceholder smartPartPlaceholder;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barSmartParts;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
