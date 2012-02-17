namespace espurl.explorer.Forms
{
   partial class ResponseForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResponseForm));
         this.imgQr = new System.Windows.Forms.PictureBox();
         this.label1 = new System.Windows.Forms.Label();
         this.txtUrl = new System.Windows.Forms.TextBox();
         this.btnSaveQrCode = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.imgQr)).BeginInit();
         this.SuspendLayout();
         // 
         // imgQr
         // 
         this.imgQr.Location = new System.Drawing.Point(12, 67);
         this.imgQr.Name = "imgQr";
         this.imgQr.Size = new System.Drawing.Size(200, 200);
         this.imgQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.imgQr.TabIndex = 0;
         this.imgQr.TabStop = false;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(9, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(152, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "URL Copied into the clipboard.";
         // 
         // txtUrl
         // 
         this.txtUrl.Location = new System.Drawing.Point(12, 29);
         this.txtUrl.Name = "txtUrl";
         this.txtUrl.ReadOnly = true;
         this.txtUrl.Size = new System.Drawing.Size(200, 20);
         this.txtUrl.TabIndex = 2;
         // 
         // btnSaveQrCode
         // 
         this.btnSaveQrCode.Location = new System.Drawing.Point(71, 273);
         this.btnSaveQrCode.Name = "btnSaveQrCode";
         this.btnSaveQrCode.Size = new System.Drawing.Size(90, 23);
         this.btnSaveQrCode.TabIndex = 3;
         this.btnSaveQrCode.Text = "Save QR code";
         this.btnSaveQrCode.UseVisualStyleBackColor = true;
         // 
         // ResponseForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(223, 304);
         this.Controls.Add(this.btnSaveQrCode);
         this.Controls.Add(this.txtUrl);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.imgQr);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ResponseForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "espUrl";
         ((System.ComponentModel.ISupportInitialize)(this.imgQr)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox imgQr;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtUrl;
      private System.Windows.Forms.Button btnSaveQrCode;
   }
}