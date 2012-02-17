using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using espurl.explorer.Forms;

namespace espurl.explorer
{
   class UploadFileHandler : IFileHandler
   {
#if DEBUG
      private string espUrl = "http://espurl.local/api/upload";
#else 
      private string espUrl = "http://espurl.me/api/upload";
#endif

      public void HandleFile(string filePath)
      {
         var thread = new Thread(new ParameterizedThreadStart(HandleFileInternal));
         thread.SetApartmentState(ApartmentState.STA);
         thread.Start(filePath);
      }

      public void HandleFileInternal(object param)
      {
         string filePath = (string)param;
         try
         {
            var request = GetRequest(filePath);
            var response = request.GetResponse();
            FileUploadResponse rspObject = GetObjectResponse(response);
            if (rspObject.success)
            {
               if (string.IsNullOrWhiteSpace(rspObject.redirectTo))
               {
                  MessageBox.Show("Something wrong espUrl is empty.", "espUrl is empty");
               }
               else
               {
                  Clipboard.SetDataObject(rspObject.redirectTo, true);
                  var form = new ResponseForm(rspObject);
                  form.ShowDialog();
               }
            }
            else
            {
               if (rspObject.validators != null)
               {
                  var str = new StringBuilder();
                  str.AppendLine("An error has been encountered while validating your file. See detailed error messages below:");
                  foreach (var validError in rspObject.validators)
                  {
                     str.AppendLine(validError);
                  }
                  MessageBox.Show(str.ToString(), "espUrl error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else
               {
                  MessageBox.Show("An error has been encountered on the server. \n" + rspObject.error, "espUrl error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "espUrl error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
      }

      private WebRequest GetRequest(string file)
      {
         var httpRequest = WebRequest.Create(espUrl);
         var builder = new MultiPart();
         builder.AddField("AutoResize", "true");
         builder.AddFileField("UploadFile", file);
         httpRequest.ContentType = "multipart/form-data; boundary=" + builder.Boundary;
         httpRequest.Method = "POST";
         using (var stream = httpRequest.GetRequestStream())
         {
            builder.GetStream().CopyTo(stream);
         }
         return httpRequest;
      }

      private FileUploadResponse GetObjectResponse(WebResponse rsp)
      {
         var serializer = new DataContractJsonSerializer(typeof(FileUploadResponse));
         using (var stream = rsp.GetResponseStream())
         {
            return (FileUploadResponse)serializer.ReadObject(stream);
         }
      }
   }
}
