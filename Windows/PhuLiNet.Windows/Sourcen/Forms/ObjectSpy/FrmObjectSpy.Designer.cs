namespace Windows.Core.Forms.ObjectSpy
{
    partial class FrmObjectSpy
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
            this.gcSpy = new DevExpress.XtraGrid.GridControl();
            this.gvSpy = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSpy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSpy)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSpy
            // 
            this.gcSpy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSpy.Location = new System.Drawing.Point(0, 0);
            this.gcSpy.MainView = this.gvSpy;
            this.gcSpy.Name = "gcSpy";
            this.gcSpy.Size = new System.Drawing.Size(1053, 600);
            this.gcSpy.TabIndex = 0;
            this.gcSpy.UseEmbeddedNavigator = true;
            this.gcSpy.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSpy});
            // 
            // gvSpy
            // 
            this.gvSpy.GridControl = this.gcSpy;
            this.gvSpy.Name = "gvSpy";
            this.gvSpy.OptionsView.ColumnAutoWidth = false;
            // 
            // FrmObjectSpy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 600);
            this.Controls.Add(this.gcSpy);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmObjectSpy";
            this.Text = "Object Spy";
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSpy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSpy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSpy;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSpy;
    }
}