using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace espurl.explorer
{
   [DataContract]
   public class FileUploadResponse
   {
      [DataMember]
      public bool success = false;

      [DataMember]
      public string error = null;

      [DataMember]
      public string[] validators = null;

      [DataMember]
      public string redirectTo = null;

      [DataMember]
      public string qrUrl { get; set; }
   }
}
