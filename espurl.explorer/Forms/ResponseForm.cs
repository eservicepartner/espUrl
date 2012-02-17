using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace espurl.explorer.Forms
{
   public partial class ResponseForm : Form
   {
      public FileUploadResponse Response { get; set; }

      public ResponseForm(FileUploadResponse response)
      {
         InitializeComponent();

         txtUrl.Text = response.redirectTo;

         btnSaveQrCode.Enabled = false;
         btnSaveQrCode.Click += new EventHandler(btnSaveQrCode_Click);

         imgQr.LoadCompleted += new AsyncCompletedEventHandler(imgQr_LoadCompleted);
         //imgQr.ImageLocation = response.qrUrl;
         imgQr.LoadAsync(response.qrUrl);

         Response = response;
      }

      private void btnSaveQrCode_Click(object sender, EventArgs e)
      {
         var dialog = new SaveFileDialog();
         dialog.FileName = "qr-code";
         dialog.DefaultExt = "png";
         dialog.Filter = "PNG image (*.png)|*.png";
         dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
         {
            try
            {
               using (var stream = dialog.OpenFile())
               {
                  imgQr.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "espUrl error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void imgQr_LoadCompleted(object sender, AsyncCompletedEventArgs e)
      {
         if (e.Error == null && !e.Cancelled)
         {
            btnSaveQrCode.Enabled = true;
         }
      }
   }
}
