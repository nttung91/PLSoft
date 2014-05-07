namespace Windows.Core.Forms.Wizard
{
    partial class FrmWizardBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWizardBase));
            this.ilWizard = new System.Windows.Forms.ImageList(this.components);
            this.pnlPluginArea = new DevExpress.XtraEditors.PanelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnFinish = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPluginArea)).BeginInit();
            this.SuspendLayout();
            // 
            // ilWizard
            // 
            this.ilWizard.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilWizard.ImageStream")));
            this.ilWizard.TransparentColor = System.Drawing.Color.White;
            this.ilWizard.Images.SetKeyName(0, "Cancel4.ico");
            this.ilWizard.Images.SetKeyName(1, "Pfeil zurück.ico");
            this.ilWizard.Images.SetKeyName(2, "Pfeil vor.ico");
            this.ilWizard.Images.SetKeyName(3, "saveHS.ico");
            this.ilWizard.Images.SetKeyName(4, "ok2.ico");
            this.ilWizard.Images.SetKeyName(5, "pencil.ico");
            this.ilWizard.Images.SetKeyName(6, "Shut down.ico");
            this.ilWizard.Images.SetKeyName(7, "Save.ico");
            this.ilWizard.Images.SetKeyName(8, "GoLtrHS.ico");
            this.ilWizard.Images.SetKeyName(9, "GoRtlHS.ico");
            this.ilWizard.Images.SetKeyName(10, "camera.ico");
            // 
            // pnlPluginArea
            // 
            resources.ApplyResources(this.pnlPluginArea, "pnlPluginArea");
            this.pnlPluginArea.Name = "pnlPluginArea";
            // 
            // btnBack
            // 
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.ImageIndex = 9;
            this.btnBack.ImageList = this.ilWizard;
            this.btnBack.Name = "btnBack";
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.ImageIndex = 8;
            this.btnNext.ImageList = this.ilWizard;
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnNext.Name = "btnNext";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ImageIndex = 6;
            this.btnCancel.ImageList = this.ilWizard;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnFinish
            // 
            resources.ApplyResources(this.btnFinish, "btnFinish");
            this.btnFinish.ImageIndex = 3;
            this.btnFinish.ImageList = this.ilWizard;
            this.btnFinish.Name = "btnFinish";
            // 
            // FrmWizardBase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlPluginArea);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmWizardBase";
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPluginArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ilWizard;
        public DevExpress.XtraEditors.PanelControl pnlPluginArea;
        public DevExpress.XtraEditors.SimpleButton btnNext;
        public DevExpress.XtraEditors.SimpleButton btnBack;
        public DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton btnFinish;

    }
}