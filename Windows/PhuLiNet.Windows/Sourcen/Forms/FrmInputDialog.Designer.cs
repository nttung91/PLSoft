namespace Windows.Core.Forms
{
    partial class FrmInputDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInputDialog));
            this.lblInputInfo = new DevExpress.XtraEditors.LabelControl();
            this.lcInput = new DevExpress.XtraLayout.LayoutControl();
            this.lcgInput = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciInputInfo = new DevExpress.XtraLayout.LayoutControlItem();
            this.esiInput = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcInput)).BeginInit();
            this.lcInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciInputInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiInput)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInputInfo
            // 
            resources.ApplyResources(this.lblInputInfo, "lblInputInfo");
            this.lblInputInfo.Name = "lblInputInfo";
            this.lblInputInfo.StyleController = this.lcInput;
            // 
            // lcInput
            // 
            this.lcInput.Controls.Add(this.lblInputInfo);
            resources.ApplyResources(this.lcInput, "lcInput");
            this.lcInput.Name = "lcInput";
            this.lcInput.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(54, 151, 250, 350);
            this.lcInput.Root = this.lcgInput;
            // 
            // lcgInput
            // 
            resources.ApplyResources(this.lcgInput, "lcgInput");
            this.lcgInput.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgInput.GroupBordersVisible = false;
            this.lcgInput.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciInputInfo,
            this.esiInput});
            this.lcgInput.Location = new System.Drawing.Point(0, 0);
            this.lcgInput.Name = "lcgInput";
            this.lcgInput.Size = new System.Drawing.Size(273, 71);
            // 
            // lciInputInfo
            // 
            this.lciInputInfo.Control = this.lblInputInfo;
            resources.ApplyResources(this.lciInputInfo, "lciInputInfo");
            this.lciInputInfo.Location = new System.Drawing.Point(0, 34);
            this.lciInputInfo.Name = "lciInputInfo";
            this.lciInputInfo.Size = new System.Drawing.Size(253, 17);
            this.lciInputInfo.TextSize = new System.Drawing.Size(0, 0);
            this.lciInputInfo.TextToControlDistance = 0;
            this.lciInputInfo.TextVisible = false;
            // 
            // esiInput
            // 
            this.esiInput.AllowHotTrack = false;
            resources.ApplyResources(this.esiInput, "esiInput");
            this.esiInput.Location = new System.Drawing.Point(0, 0);
            this.esiInput.Name = "esiInput";
            this.esiInput.Size = new System.Drawing.Size(253, 34);
            this.esiInput.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FrmInputDialog
            // 
            this.AcceptButtonVisible = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButtonVisible = true;
            this.Controls.Add(this.lcInput);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmInputDialog";
            this.RememberPosition = false;
            this.Controls.SetChildIndex(this.lcInput, 0);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcInput)).EndInit();
            this.lcInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciInputInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblInputInfo;
        private DevExpress.XtraLayout.LayoutControl lcInput;
        private DevExpress.XtraLayout.LayoutControlGroup lcgInput;
        private DevExpress.XtraLayout.LayoutControlItem lciInputInfo;
        private DevExpress.XtraLayout.EmptySpaceItem esiInput;
    }
}