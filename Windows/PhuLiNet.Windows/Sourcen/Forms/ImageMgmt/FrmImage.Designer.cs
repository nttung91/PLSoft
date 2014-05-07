using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Windows.Core.Forms.ImageMgmt
{
    partial class FrmImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImage));
            this.peBild = new DevExpress.XtraEditors.PictureEdit();
            this.bmBild = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbiUebernehmen = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAbbrechen = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStandard2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStandard3 = new DevExpress.XtraBars.BarButtonItem();
            this.bbi90m = new DevExpress.XtraBars.BarButtonItem();
            this.bbi90p = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOriginalBild = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGroesser = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKleiner = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bsiGroesse = new DevExpress.XtraBars.BarStaticItem();
            this.bsibmessung = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ilBild = new System.Windows.Forms.ImageList(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.sfdBild = new System.Windows.Forms.SaveFileDialog();
            this.ofdBild = new System.Windows.Forms.OpenFileDialog();
            this.imageOpenFileDialog = new ImageOpenFileDialogWithCheck(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peBild.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmBild)).BeginInit();
            this.SuspendLayout();
            // 
            // peBild
            // 
            resources.ApplyResources(this.peBild, "peBild");
            this.peBild.Name = "peBild";
            this.peBild.Properties.AccessibleDescription = resources.GetString("peBild.Properties.AccessibleDescription");
            this.peBild.Properties.AccessibleName = resources.GetString("peBild.Properties.AccessibleName");
            // 
            // bmBild
            // 
            this.bmBild.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.bmBild.DockControls.Add(this.barDockControlTop);
            this.bmBild.DockControls.Add(this.barDockControlBottom);
            this.bmBild.DockControls.Add(this.barDockControlLeft);
            this.bmBild.DockControls.Add(this.barDockControlRight);
            this.bmBild.Form = this;
            this.bmBild.Images = this.ilBild;
            this.bmBild.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiGroesser,
            this.bbi90p,
            this.bbi90m,
            this.bbiUebernehmen,
            this.bbiKleiner,
            this.bsiGroesse,
            this.bsibmessung,
            this.bbiStandard,
            this.barButtonItem2,
            this.bbiStandard2,
            this.bbiSave,
            this.bbiOriginalBild,
            this.bbiStandard3,
            this.bbiAbbrechen});
            this.bmBild.MaxItemId = 16;
            this.bmBild.StatusBar = this.bar2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUebernehmen),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAbbrechen),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStandard, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStandard2),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStandard3),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi90m, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi90p),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOriginalBild, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiGroesser, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiKleiner),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSave)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            resources.ApplyResources(this.bar1, "bar1");
            // 
            // bbiUebernehmen
            // 
            resources.ApplyResources(this.bbiUebernehmen, "bbiUebernehmen");
            this.bbiUebernehmen.Id = 5;
            this.bbiUebernehmen.ImageIndex = 1;
            this.bbiUebernehmen.Name = "bbiUebernehmen";
            this.bbiUebernehmen.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiUebernehmen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUebernehmen_ItemClick);
            // 
            // bbiAbbrechen
            // 
            resources.ApplyResources(this.bbiAbbrechen, "bbiAbbrechen");
            this.bbiAbbrechen.Id = 15;
            this.bbiAbbrechen.ImageIndex = 0;
            this.bbiAbbrechen.Name = "bbiAbbrechen";
            this.bbiAbbrechen.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiAbbrechen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAbbrechen_ItemClick);
            // 
            // bbiStandard
            // 
            resources.ApplyResources(this.bbiStandard, "bbiStandard");
            this.bbiStandard.Id = 9;
            this.bbiStandard.ImageIndex = 6;
            this.bbiStandard.Name = "bbiStandard";
            this.bbiStandard.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStandard_ItemClick);
            // 
            // bbiStandard2
            // 
            resources.ApplyResources(this.bbiStandard2, "bbiStandard2");
            this.bbiStandard2.Id = 11;
            this.bbiStandard2.ImageIndex = 6;
            this.bbiStandard2.Name = "bbiStandard2";
            this.bbiStandard2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiStandard2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStandard2_ItemClick);
            // 
            // bbiStandard3
            // 
            resources.ApplyResources(this.bbiStandard3, "bbiStandard3");
            this.bbiStandard3.Id = 14;
            this.bbiStandard3.ImageIndex = 6;
            this.bbiStandard3.Name = "bbiStandard3";
            this.bbiStandard3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiStandard3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStandard3_ItemClick);
            // 
            // bbi90m
            // 
            resources.ApplyResources(this.bbi90m, "bbi90m");
            this.bbi90m.Id = 4;
            this.bbi90m.ImageIndex = 5;
            this.bbi90m.Name = "bbi90m";
            this.bbi90m.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbi90m.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi90m_ItemClick);
            // 
            // bbi90p
            // 
            resources.ApplyResources(this.bbi90p, "bbi90p");
            this.bbi90p.Id = 3;
            this.bbi90p.ImageIndex = 4;
            this.bbi90p.Name = "bbi90p";
            this.bbi90p.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbi90p.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi90p_ItemClick);
            // 
            // bbiOriginalBild
            // 
            resources.ApplyResources(this.bbiOriginalBild, "bbiOriginalBild");
            this.bbiOriginalBild.Id = 13;
            this.bbiOriginalBild.ImageIndex = 8;
            this.bbiOriginalBild.Name = "bbiOriginalBild";
            this.bbiOriginalBild.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiOriginalBild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOriginalBild_ItemClick);
            // 
            // bbiGroesser
            // 
            resources.ApplyResources(this.bbiGroesser, "bbiGroesser");
            this.bbiGroesser.Id = 2;
            this.bbiGroesser.ImageIndex = 2;
            this.bbiGroesser.Name = "bbiGroesser";
            this.bbiGroesser.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiGroesser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGroesser_ItemClick);
            // 
            // bbiKleiner
            // 
            resources.ApplyResources(this.bbiKleiner, "bbiKleiner");
            this.bbiKleiner.Id = 6;
            this.bbiKleiner.ImageIndex = 3;
            this.bbiKleiner.Name = "bbiKleiner";
            this.bbiKleiner.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiKleiner.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiKleiner_ItemClick);
            // 
            // bbiSave
            // 
            resources.ApplyResources(this.bbiSave, "bbiSave");
            this.bbiSave.Id = 12;
            this.bbiSave.ImageIndex = 7;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiGroesse),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsibmessung)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar2, "bar2");
            // 
            // bsiGroesse
            // 
            resources.ApplyResources(this.bsiGroesse, "bsiGroesse");
            this.bsiGroesse.Id = 7;
            this.bsiGroesse.Name = "bsiGroesse";
            this.bsiGroesse.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bsiGroesse.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsibmessung
            // 
            resources.ApplyResources(this.bsibmessung, "bsibmessung");
            this.bsibmessung.Id = 8;
            this.bsibmessung.Name = "bsibmessung";
            this.bsibmessung.TextAlignment = System.Drawing.StringAlignment.Near;
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
            // ilBild
            // 
            this.ilBild.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilBild.ImageStream")));
            this.ilBild.TransparentColor = System.Drawing.Color.Transparent;
            this.ilBild.Images.SetKeyName(0, "close_b_24.gif");
            this.ilBild.Images.SetKeyName(1, "ok.ico");
            this.ilBild.Images.SetKeyName(2, "LupeGroesser.ico");
            this.ilBild.Images.SetKeyName(3, "LupeKleiner.ico");
            this.ilBild.Images.SetKeyName(4, "rotateminus.ico");
            this.ilBild.Images.SetKeyName(5, "rotateplus.ico");
            this.ilBild.Images.SetKeyName(6, "magic-wand.ico");
            this.ilBild.Images.SetKeyName(7, "Save2.ico");
            this.ilBild.Images.SetKeyName(8, "refresh_24.gif");
            this.ilBild.Images.SetKeyName(9, "Achtung.ico");
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // sfdBild
            // 
            this.sfdBild.FileName = "Picture.jpg";
            resources.ApplyResources(this.sfdBild, "sfdBild");
            // 
            // ofdBild
            // 
            this.ofdBild.FileName = "*.jpg";
            resources.ApplyResources(this.ofdBild, "ofdBild");
            // 
            // imageOpenFileDialog
            // 
            this.imageOpenFileDialog.PictureAsBytes = null;
            // 
            // FrmImage
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.peBild);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmImage";
            this.Load += new System.EventHandler(this.FrmBild_Load);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peBild.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmBild)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private PictureEdit peBild;
        private DevExpress.XtraBars.BarManager bmBild;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiGroesser;
        private DevExpress.XtraBars.BarButtonItem bbi90p;
        private DevExpress.XtraBars.BarButtonItem bbi90m;
        private DevExpress.XtraBars.BarButtonItem bbiUebernehmen;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ImageList ilBild;
        private DevExpress.XtraBars.BarButtonItem bbiKleiner;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem bsiGroesse;
        private DevExpress.XtraBars.BarStaticItem bsibmessung;
        private DevExpress.XtraBars.BarButtonItem bbiStandard;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem bbiStandard2;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiOriginalBild;
        private DevExpress.XtraBars.BarButtonItem bbiStandard3;
        private SaveFileDialog sfdBild;
        private OpenFileDialog ofdBild;
        private DevExpress.XtraBars.BarButtonItem bbiAbbrechen;
        private ImageOpenFileDialogWithCheck imageOpenFileDialog;
    }
}
