namespace Windows.Core.Forms.Logging
{
    partial class FrmShowLog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowLog));
            this.rttLogging = new System.Windows.Forms.RichTextBox();
            this.bmLog = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbiShowLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelLog = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ilToolbar = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmLog)).BeginInit();
            this.SuspendLayout();
            // 
            // rttLogging
            // 
            resources.ApplyResources(this.rttLogging, "rttLogging");
            this.rttLogging.Name = "rttLogging";
            // 
            // bmLog
            // 
            this.bmLog.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.bmLog.DockControls.Add(this.barDockControlTop);
            this.bmLog.DockControls.Add(this.barDockControlBottom);
            this.bmLog.DockControls.Add(this.barDockControlLeft);
            this.bmLog.DockControls.Add(this.barDockControlRight);
            this.bmLog.Form = this;
            this.bmLog.Images = this.ilToolbar;
            this.bmLog.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiDelLog,
            this.bbiShowLog});
            this.bmLog.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiShowLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelLog, true)});
            this.bar1.OptionsBar.DisableClose = true;
            resources.ApplyResources(this.bar1, "bar1");
            // 
            // bbiShowLog
            // 
            resources.ApplyResources(this.bbiShowLog, "bbiShowLog");
            this.bbiShowLog.Id = 2;
            this.bbiShowLog.ImageIndex = 64;
            this.bbiShowLog.Name = "bbiShowLog";
            this.bbiShowLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiShowLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLogApp_ItemClick);
            // 
            // bbiDelLog
            // 
            resources.ApplyResources(this.bbiDelLog, "bbiDelLog");
            this.bbiDelLog.Id = 0;
            this.bbiDelLog.ImageIndex = 68;
            this.bbiDelLog.Name = "bbiDelLog";
            this.bbiDelLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiDelLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelLog_ItemClick);
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlTop.Appearance.GradientMode")));
            this.barDockControlTop.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlTop.Appearance.Image")));
            this.barDockControlTop.CausesValidation = false;
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlBottom.Appearance.GradientMode")));
            this.barDockControlBottom.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlBottom.Appearance.Image")));
            this.barDockControlBottom.CausesValidation = false;
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlLeft.Appearance.GradientMode")));
            this.barDockControlLeft.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlLeft.Appearance.Image")));
            this.barDockControlLeft.CausesValidation = false;
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlRight.Appearance.GradientMode")));
            this.barDockControlRight.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlRight.Appearance.Image")));
            this.barDockControlRight.CausesValidation = false;
            // 
            // ilToolbar
            // 
            this.ilToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolbar.ImageStream")));
            this.ilToolbar.TransparentColor = System.Drawing.Color.Magenta;
            this.ilToolbar.Images.SetKeyName(0, "");
            this.ilToolbar.Images.SetKeyName(1, "");
            this.ilToolbar.Images.SetKeyName(2, "");
            this.ilToolbar.Images.SetKeyName(3, "");
            this.ilToolbar.Images.SetKeyName(4, "");
            this.ilToolbar.Images.SetKeyName(5, "");
            this.ilToolbar.Images.SetKeyName(6, "");
            this.ilToolbar.Images.SetKeyName(7, "");
            this.ilToolbar.Images.SetKeyName(8, "");
            this.ilToolbar.Images.SetKeyName(9, "");
            this.ilToolbar.Images.SetKeyName(10, "");
            this.ilToolbar.Images.SetKeyName(11, "");
            this.ilToolbar.Images.SetKeyName(12, "");
            this.ilToolbar.Images.SetKeyName(13, "");
            this.ilToolbar.Images.SetKeyName(14, "");
            this.ilToolbar.Images.SetKeyName(15, "");
            this.ilToolbar.Images.SetKeyName(16, "");
            this.ilToolbar.Images.SetKeyName(17, "");
            this.ilToolbar.Images.SetKeyName(18, "");
            this.ilToolbar.Images.SetKeyName(19, "");
            this.ilToolbar.Images.SetKeyName(20, "");
            this.ilToolbar.Images.SetKeyName(21, "");
            this.ilToolbar.Images.SetKeyName(22, "");
            this.ilToolbar.Images.SetKeyName(23, "");
            this.ilToolbar.Images.SetKeyName(24, "");
            this.ilToolbar.Images.SetKeyName(25, "");
            this.ilToolbar.Images.SetKeyName(26, "");
            this.ilToolbar.Images.SetKeyName(27, "");
            this.ilToolbar.Images.SetKeyName(28, "");
            this.ilToolbar.Images.SetKeyName(29, "");
            this.ilToolbar.Images.SetKeyName(30, "");
            this.ilToolbar.Images.SetKeyName(31, "");
            this.ilToolbar.Images.SetKeyName(32, "");
            this.ilToolbar.Images.SetKeyName(33, "");
            this.ilToolbar.Images.SetKeyName(34, "");
            this.ilToolbar.Images.SetKeyName(35, "");
            this.ilToolbar.Images.SetKeyName(36, "");
            this.ilToolbar.Images.SetKeyName(37, "");
            this.ilToolbar.Images.SetKeyName(38, "");
            this.ilToolbar.Images.SetKeyName(39, "");
            this.ilToolbar.Images.SetKeyName(40, "");
            this.ilToolbar.Images.SetKeyName(41, "");
            this.ilToolbar.Images.SetKeyName(42, "");
            this.ilToolbar.Images.SetKeyName(43, "");
            this.ilToolbar.Images.SetKeyName(44, "");
            this.ilToolbar.Images.SetKeyName(45, "");
            this.ilToolbar.Images.SetKeyName(46, "");
            this.ilToolbar.Images.SetKeyName(47, "");
            this.ilToolbar.Images.SetKeyName(48, "");
            this.ilToolbar.Images.SetKeyName(49, "");
            this.ilToolbar.Images.SetKeyName(50, "");
            this.ilToolbar.Images.SetKeyName(51, "");
            this.ilToolbar.Images.SetKeyName(52, "");
            this.ilToolbar.Images.SetKeyName(53, "");
            this.ilToolbar.Images.SetKeyName(54, "");
            this.ilToolbar.Images.SetKeyName(55, "");
            this.ilToolbar.Images.SetKeyName(56, "");
            this.ilToolbar.Images.SetKeyName(57, "");
            this.ilToolbar.Images.SetKeyName(58, "");
            this.ilToolbar.Images.SetKeyName(59, "");
            this.ilToolbar.Images.SetKeyName(60, "");
            this.ilToolbar.Images.SetKeyName(61, "");
            this.ilToolbar.Images.SetKeyName(62, "");
            this.ilToolbar.Images.SetKeyName(63, "magic-wand-plus.ico");
            this.ilToolbar.Images.SetKeyName(64, "ok_leger.ico");
            this.ilToolbar.Images.SetKeyName(65, "house.ico");
            this.ilToolbar.Images.SetKeyName(66, "printer.png");
            this.ilToolbar.Images.SetKeyName(67, "pdficon_large.gif");
            this.ilToolbar.Images.SetKeyName(68, "Stop.ico");
            this.ilToolbar.Images.SetKeyName(69, "Write.ico");
            this.ilToolbar.Images.SetKeyName(70, "Copy.ico");
            this.ilToolbar.Images.SetKeyName(71, "New Doc.ico");
            this.ilToolbar.Images.SetKeyName(72, "Search.ico");
            // 
            // FrmShowLog
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.rttLogging);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmShowLog";
            this.Shown += new System.EventHandler(this.FrmShowLog_Shown);
            this.Enter += new System.EventHandler(this.FrmShowLog_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rttLogging;
        private DevExpress.XtraBars.BarManager bmLog;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiDelLog;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiShowLog;
        private System.Windows.Forms.ImageList ilToolbar;
    }
}
