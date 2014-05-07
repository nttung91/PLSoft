namespace Windows.Core.Forms.AdminConsole
{
    partial class FrmSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectForm));
            this.lbcForms = new DevExpress.XtraEditors.ListBoxControl();
            this.formBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbcForms
            // 
            resources.ApplyResources(this.lbcForms, "lbcForms");
            this.lbcForms.DataSource = this.formBindingSource;
            this.lbcForms.DisplayMember = "Text";
            this.lbcForms.Name = "lbcForms";
            this.lbcForms.DoubleClick += new System.EventHandler(this.lbcForms_DoubleClick);
            // 
            // formBindingSource
            // 
            this.formBindingSource.DataSource = typeof(System.Windows.Forms.Form);
            // 
            // FrmSelectForm
            // 
            this.AcceptButtonVisible = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButtonVisible = true;
            this.Controls.Add(this.lbcForms);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmSelectForm";
            this.Controls.SetChildIndex(this.lbcForms, 0);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcForms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl lbcForms;
        private System.Windows.Forms.BindingSource formBindingSource;
    }
}