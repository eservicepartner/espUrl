using System.Runtime.Serialization;

namespace espurl.win.screenshot.Infrastructure
{
	[DataContract]
	public class FileUploadResponse
	{
		[DataMember] 
		public bool success;

		[DataMember] 
		public string error;

		[DataMember] 
		public string[] validators;

		[DataMember] 
		public string redirectTo;

		[DataMember] 
		public string qrUrl;
	}
}