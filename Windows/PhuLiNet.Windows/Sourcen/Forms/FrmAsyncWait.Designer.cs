namespace Windows.Core.Forms
{
    partial class FrmAsyncWait
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsyncWait));
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.meMessage = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picInfo
            // 
            this.picInfo.ErrorImage = null;
            this.picInfo.Image = ((System.Drawing.Image)(resources.GetObject("picInfo.Image")));
            this.picInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picInfo.Location = new System.Drawing.Point(12, 12);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(37, 37);
            this.picInfo.TabIndex = 12;
            this.picInfo.TabStop = false;
            // 
            // meMessage
            // 
            this.meMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meMessage.EditValue = "<MessageText>";
            this.meMessage.Location = new System.Drawing.Point(55, 12);
            this.meMessage.Name = "meMessage";
            this.meMessage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.meMessage.Properties.Appearance.Options.UseFont = true;
            this.meMessage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.meMessage.Properties.ReadOnly = true;
            this.meMessage.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.meMessage.Size = new System.Drawing.Size(307, 38);
            this.meMessage.TabIndex = 13;
            // 
            // FrmAsyncWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 62);
            this.ControlBox = false;
            this.Controls.Add(this.meMessage);
            this.Controls.Add(this.picInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmAsyncWait";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picInfo;
        private DevExpress.XtraEditors.MemoEdit meMessage;
    }
}