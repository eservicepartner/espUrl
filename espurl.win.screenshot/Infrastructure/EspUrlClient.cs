using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using espurl.win.screenshot.Forms;

namespace espurl.win.screenshot.Infrastructure
{
	public class EspUrlClient
	{
#if DEBUG
		private string baseUrl = "http://espurl.local/api/";
#else
		private string baseUrl = "http://espurl.me/api/";
#endif

		public void Upload(Stream stream, string name)
		{
			try
			{
				TryUpload(stream, name);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void TryUpload(Stream stream, string name)
		{
			using (var client = new HttpClient(baseUrl))
			{
				var fileContent = new StreamContent(stream);
				var content = new MultipartFormDataContent { { fileContent, "UploadFile", name } };
				var response = client.Post("upload?AutoResize=true", content);
				var serializer = new DataContractJsonSerializer(typeof(FileUploadResponse));
				var streamReader = response.Content.ContentReadStream;
				response.EnsureSuccessStatusCode();

				var rspObject = serializer.ReadObject(streamReader) as FileUploadResponse;

				CheckSuccessfulUpload(rspObject);

				Clipboard.SetDataObject(rspObject.redirectTo, true);
				var form = new ResponseForm(rspObject);
				form.ShowDialog();
			}
		}

		private void CheckSuccessfulUpload(FileUploadResponse rspObject)
		{
			if (!rspObject.success)
			{
				if (rspObject.validators == null)
					throw new Exception("An error has been encountered on the server. \n" + rspObject.error);

				var validationErrorMessage = string.Join(Environment.NewLine, rspObject.validators);
				throw new Exception(validationErrorMessage);
			}

			if (string.IsNullOrWhiteSpace(rspObject.redirectTo))
				throw new Exception("Something's wrong. Response is empty!");
		}
	}
}