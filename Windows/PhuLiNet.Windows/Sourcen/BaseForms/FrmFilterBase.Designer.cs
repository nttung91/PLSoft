using PhuLiNet.Business.Common.Interfaces;

namespace Windows.Core.BaseForms
{
    partial class FrmFilterBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilterBase));
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.tlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.ceSeparateWindow = new DevExpress.XtraEditors.CheckEdit();
            this.bsFilterSelection = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceSeparateWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilterSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            this.pnlButtons.Controls.Add(this.tlButtons);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // tlButtons
            // 
            resources.ApplyResources(this.tlButtons, "tlButtons");
            this.tlButtons.Controls.Add(this.btnCancel, 3, 0);
            this.tlButtons.Controls.Add(this.btnOk, 2, 0);
            this.tlButtons.Controls.Add(this.btnReset, 0, 0);
            this.tlButtons.Controls.Add(this.ceSeparateWindow, 1, 0);
            this.tlButtons.Name = "tlButtons";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // ceSeparateWindow
            // 
            resources.ApplyResources(this.ceSeparateWindow, "ceSeparateWindow");
            this.ceSeparateWindow.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsFilterSelection, "SeperateWindow", true));
            this.ceSeparateWindow.Name = "ceSeparateWindow";
            this.ceSeparateWindow.Properties.AccessibleDescription = resources.GetString("ceSeparateWindow.Properties.AccessibleDescription");
            this.ceSeparateWindow.Properties.AccessibleName = resources.GetString("ceSeparateWindow.Properties.AccessibleName");
            this.ceSeparateWindow.Properties.AutoHeight = ((bool)(resources.GetObject("ceSeparateWindow.Properties.AutoHeight")));
            this.ceSeparateWindow.Properties.Caption = resources.GetString("ceSeparateWindow.Properties.Caption");
            this.ceSeparateWindow.Properties.DisplayValueChecked = resources.GetString("ceSeparateWindow.Properties.DisplayValueChecked");
            this.ceSeparateWindow.Properties.DisplayValueGrayed = resources.GetString("ceSeparateWindow.Properties.DisplayValueGrayed");
            this.ceSeparateWindow.Properties.DisplayValueUnchecked = resources.GetString("ceSeparateWindow.Properties.DisplayValueUnchecked");
            // 
            // bsFilterSelection
            // 
            this.bsFilterSelection.DataSource = typeof(PhuLiNet.Business.Common.Interfaces.IFilterSelection);
            // 
            // FrmFilterBase
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.pnlButtons);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmFilterBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCslaDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceSeparateWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilterSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlButtons;
        private DevExpress.XtraEditors.PanelControl pnlButtons;
        protected DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.CheckEdit ceSeparateWindow;
        private System.Windows.Forms.BindingSource bsFilterSelection;
    }
}
