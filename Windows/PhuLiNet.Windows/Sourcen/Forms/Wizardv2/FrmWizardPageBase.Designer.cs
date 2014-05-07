namespace Windows.Core.Forms.Wizardv2
{
    partial class FrmWizardPageBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWizardPageBase));
            this.ilWizard = new System.Windows.Forms.ImageList(this.components);
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnFinish = new DevExpress.XtraEditors.SimpleButton();
            this.pnlButtonArea = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtonArea)).BeginInit();
            this.pnlButtonArea.SuspendLayout();
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
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.ImageIndex = 9;
            this.btnBack.ImageList = this.ilWizard;
            this.btnBack.Location = new System.Drawing.Point(498, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 26);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "&Zurück";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.ImageIndex = 8;
            this.btnNext.ImageList = this.ilWizard;
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(604, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 26);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "&Weiter";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageIndex = 6;
            this.btnCancel.ImageList = this.ilWizard;
            this.btnCancel.Location = new System.Drawing.Point(816, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Abbrechen";
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.ImageIndex = 3;
            this.btnFinish.ImageList = this.ilWizard;
            this.btnFinish.Location = new System.Drawing.Point(710, 7);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(100, 26);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "&Speichern";
            // 
            // pnlButtonArea
            // 
            this.pnlButtonArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.pnlButtonArea.Controls.Add(this.btnFinish);
            this.pnlButtonArea.Controls.Add(this.btnCancel);
            this.pnlButtonArea.Controls.Add(this.btnBack);
            this.pnlButtonArea.Controls.Add(this.btnNext);
            this.pnlButtonArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonArea.Location = new System.Drawing.Point(0, 591);
            this.pnlButtonArea.Name = "pnlButtonArea";
            this.pnlButtonArea.Size = new System.Drawing.Size(921, 38);
            this.pnlButtonArea.TabIndex = 0;
            // 
            // FrmWizardPageBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 629);
            this.ControlBox = false;
            this.Controls.Add(this.pnlButtonArea);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmWizardPageBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmWizardPageBase";
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtonArea)).EndInit();
            this.pnlButtonArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ilWizard;
        private DevExpress.XtraEditors.PanelControl pnlButtonArea;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnFinish;

    }
}