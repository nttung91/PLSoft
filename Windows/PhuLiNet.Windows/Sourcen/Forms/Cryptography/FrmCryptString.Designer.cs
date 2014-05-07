namespace Windows.Core.Forms.Cryptography
{
    partial class FrmCryptString
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCryptString));
            this.mePlainText = new DevExpress.XtraEditors.MemoEdit();
            this.lblPlainText = new DevExpress.XtraEditors.LabelControl();
            this.lblCryptedText = new DevExpress.XtraEditors.LabelControl();
            this.meCryptedText = new DevExpress.XtraEditors.MemoEdit();
            this.sbCrypt = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mePlainText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meCryptedText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mePlainText
            // 
            this.mePlainText.Location = new System.Drawing.Point(12, 27);
            this.mePlainText.Name = "mePlainText";
            this.mePlainText.Properties.NullText = "Bitte Text eingeben";
            this.mePlainText.Size = new System.Drawing.Size(352, 146);
            this.mePlainText.TabIndex = 0;
            // 
            // lblPlainText
            // 
            this.lblPlainText.Location = new System.Drawing.Point(12, 8);
            this.lblPlainText.Name = "lblPlainText";
            this.lblPlainText.Size = new System.Drawing.Size(110, 13);
            this.lblPlainText.TabIndex = 1;
            this.lblPlainText.Text = "Unverschlüsselter Text";
            // 
            // lblCryptedText
            // 
            this.lblCryptedText.Location = new System.Drawing.Point(12, 236);
            this.lblCryptedText.Name = "lblCryptedText";
            this.lblCryptedText.Size = new System.Drawing.Size(97, 13);
            this.lblCryptedText.TabIndex = 3;
            this.lblCryptedText.Text = "Verschlüsselter Text";
            // 
            // meCryptedText
            // 
            this.meCryptedText.Location = new System.Drawing.Point(12, 255);
            this.meCryptedText.Name = "meCryptedText";
            this.meCryptedText.Size = new System.Drawing.Size(352, 146);
            this.meCryptedText.TabIndex = 2;
            // 
            // sbCrypt
            // 
            this.sbCrypt.Location = new System.Drawing.Point(271, 179);
            this.sbCrypt.Name = "sbCrypt";
            this.sbCrypt.Size = new System.Drawing.Size(93, 29);
            this.sbCrypt.TabIndex = 4;
            this.sbCrypt.Text = "Verschlüsseln";
            this.sbCrypt.Click += new System.EventHandler(this.sbCrypt_Click);
            // 
            // FrmCryptString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 566);
            this.Controls.Add(this.sbCrypt);
            this.Controls.Add(this.lblCryptedText);
            this.Controls.Add(this.meCryptedText);
            this.Controls.Add(this.lblPlainText);
            this.Controls.Add(this.mePlainText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "FrmCryptString";
            this.Text = "Text Verschlüsselung";
            ((System.ComponentModel.ISupportInitialize)(this.depBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mePlainText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meCryptedText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit mePlainText;
        private DevExpress.XtraEditors.LabelControl lblPlainText;
        private DevExpress.XtraEditors.LabelControl lblCryptedText;
        private DevExpress.XtraEditors.MemoEdit meCryptedText;
        private DevExpress.XtraEditors.SimpleButton sbCrypt;
    }
}