namespace espurl.win.screenshot.Forms
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.imgQr)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// imgQr
			// 
			this.imgQr.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imgQr.Location = new System.Drawing.Point(20, 77);
			this.imgQr.Margin = new System.Windows.Forms.Padding(0);
			this.imgQr.Name = "imgQr";
			this.imgQr.Size = new System.Drawing.Size(269, 271);
			this.imgQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgQr.TabIndex = 0;
			this.imgQr.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(20, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.label1.Size = new System.Drawing.Size(213, 30);
			this.label1.TabIndex = 1;
			this.label1.Text = "URL Copied into the clipboard:";
			// 
			// txtUrl
			// 
			this.txtUrl.BackColor = System.Drawing.Color.White;
			this.txtUrl.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtUrl.Location = new System.Drawing.Point(20, 50);
			this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.ReadOnly = true;
			this.txtUrl.Size = new System.Drawing.Size(269, 27);
			this.txtUrl.TabIndex = 2;
			// 
			// btnSaveQrCode
			// 
			this.btnSaveQrCode.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSaveQrCode.Location = new System.Drawing.Point(19, 15);
			this.btnSaveQrCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSaveQrCode.Name = "btnSaveQrCode";
			this.btnSaveQrCode.Size = new System.Drawing.Size(125, 35);
			this.btnSaveQrCode.TabIndex = 3;
			this.btnSaveQrCode.Text = "Save QR code";
			this.btnSaveQrCode.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.btnSaveQrCode);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 368);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
			this.panel1.Size = new System.Drawing.Size(309, 65);
			this.panel1.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Right;
			this.label2.Location = new System.Drawing.Point(144, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 35);
			this.label2.TabIndex = 5;
			this.label2.Text = " ";
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(164, 15);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(125, 35);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.imgQr);
			this.panel2.Controls.Add(this.txtUrl);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(20);
			this.panel2.Size = new System.Drawing.Size(309, 368);
			this.panel2.TabIndex = 5;
			// 
			// ResponseForm
			// 
			this.AcceptButton = this.btnClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(309, 433);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ResponseForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "espUrl";
			((System.ComponentModel.ISupportInitialize)(this.imgQr)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.PictureBox imgQr;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtUrl;
      private System.Windows.Forms.Button btnSaveQrCode;
	  private System.Windows.Forms.Panel panel1;
	  private System.Windows.Forms.Panel panel2;
	  private System.Windows.Forms.Label label2;
	  private System.Windows.Forms.Button btnClose;
   }
}