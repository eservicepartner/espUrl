using System;
using System.ComponentModel;
using System.Windows.Forms;
using espurl.win.screenshot.Infrastructure;

namespace espurl.win.screenshot.Forms
{
	public partial class ResponseForm : Form
	{
		public FileUploadResponse Response { get; set; }

		public ResponseForm(FileUploadResponse response)
		{
			InitializeComponent();

			txtUrl.Text = response.redirectTo;

			btnSaveQrCode.Enabled = false;
			btnSaveQrCode.Click += btnSaveQrCode_Click;
			imgQr.LoadCompleted += imgQr_LoadCompleted;

			imgQr.LoadAsync(response.qrUrl);

			Response = response;
		}

		private void btnSaveQrCode_Click(object sender, EventArgs e)
		{
			var dialog = SavePngImageDialog();
			if (dialog.ShowDialog() != DialogResult.OK) 
				return;

			try
			{
				using (var stream = dialog.OpenFile())
				{
					imgQr.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private SaveFileDialog SavePngImageDialog()
		{
			return new SaveFileDialog
			{
				FileName = "qr-code",
				DefaultExt = "png",
				Filter = "PNG image (*.png)|*.png",
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			};
		}

		private void imgQr_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			btnSaveQrCode.Enabled = e.Error == null && !e.Cancelled;
		}
	}
}
