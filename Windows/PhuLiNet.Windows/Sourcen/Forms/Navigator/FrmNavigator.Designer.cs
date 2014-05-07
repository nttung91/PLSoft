namespace Windows.Core.Forms.Navigator
{
    partial class FrmNavigator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNavigator));
            this.ucNavigator = new Windows.Core.Forms.Navigator.Controls.UCNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            this.SuspendLayout();
            // 
            // ucNavigator
            // 
            resources.ApplyResources(this.ucNavigator, "ucNavigator");
            this.ucNavigator.Name = "ucNavigator";
            // 
            // FrmNavigator
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucNavigator);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmNavigator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNavigator_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Core.Forms.Navigator.Controls.UCNavigator ucNavigator;
    }
}