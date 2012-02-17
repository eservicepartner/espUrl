using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace espurl.explorer
{
   enum FieldType
   {
      Text,
      File,
      End,
      Spacer
   }

   class Field : ICloneable
   {
      public string name;
      public FieldType type;
      public string fileName;
      public Stream stream;
      public string contentType;
      public string header;
      public string value;
      public byte[] headerBytes;

      public object Clone()
      {
         var field = new Field();
         field.name = name;
         field.type = type;
         field.fileName = fileName;
         field.contentType = contentType;
         field.value = value;
         return field;
      }
   }

   class MultiPartStream : Stream
   {
      private List<Field> _fields;
      private long _bytesRead = 0;
      private int _currentField = 0;
      private bool _disposed = false;
      private string _boundary;
      private int _currentPosition = 0;

      public MultiPartStream(List<Field> fields, string boundary)
      {
         _fields = new List<Field>(fields.Count);
         foreach (var field in fields)
            _fields.Add((Field)field.Clone());
         _boundary = boundary;
      }

      public override bool CanRead
      {
         get { return true; }
      }

      public override bool CanSeek
      {
         get { return false; }
      }

      public override bool CanWrite
      {
         get { return false; }
      }

      public override void Flush()
      {

      }

      public override long Length
      {
         get
         {
            throw new NotSupportedException();
         }
      }

      public override long Position
      {
         get
         {
            return _bytesRead;
         }
         set
         {
            throw new NotSupportedException();
         }
      }

      public override int Read(byte[] buffer, int offset, int count)
      {
         if (_disposed)
            throw new ObjectDisposedException(null);
         if (buffer == null)
            throw new ArgumentNullException("buffer");
         if (offset + count > buffer.Length)
            throw new ArgumentException("The sum of offset and count is larger than the buffer length.");
         if (offset < 0)
            throw new ArgumentOutOfRangeException("offset");
         if (count < 0)
            throw new ArgumentOutOfRangeException("count");
         int readCurrent = 0;
         while (readCurrent < count)
         {
            if (_currentField >= _fields.Count)
               break;
            var cField = _fields[_currentField];
            PreProcessField(cField);
            var cStream = cField.stream;
            while (readCurrent < count)
            {
               if (_currentPosition < cField.headerBytes.Length)
               {
                  int amountToCopy = cField.headerBytes.Length - _currentPosition;
                  if (amountToCopy > count - readCurrent)
                     amountToCopy = count - readCurrent;
                  Array.Copy(cField.headerBytes, _currentPosition, buffer, readCurrent, amountToCopy);
                  _currentPosition += amountToCopy;
                  readCurrent += amountToCopy;
               }
               var read = cStream.Read(buffer, readCurrent, count - readCurrent);
               if (read == 0)
               {
                  _currentField++;
                  _currentPosition = 0;
                  break;
               }
               readCurrent += read;
               _currentPosition += read;
            }
         }
         _bytesRead += readCurrent;
         return readCurrent;
      }

      public override long Seek(long offset, SeekOrigin origin)
      {
         throw new NotSupportedException();
      }

      public override void SetLength(long value)
      {
         throw new NotSupportedException();
      }

      public override void Write(byte[] buffer, int offset, int count)
      {
         throw new NotSupportedException();
      }

      protected override void Dispose(bool disposing)
      {
         // If you need thread safety, use a lock around these 
         // operations, as well as in your methods that use the resource.
         if (!_disposed)
         {
            if (disposing)
            {
               foreach (var field in _fields)
               {
                  if (field.stream != null)
                  {
                     field.stream.Dispose();
                     field.stream = null;
                  }
               }
            }

            // Indicate that the instance has been disposed.
            _disposed = true;
         }
      }

      private void PreProcessField(Field field)
      {
         if (field.type == FieldType.File)
         {
            if (field.stream == null)
               field.stream = File.OpenRead(field.fileName);
         }
         else if (field.type == FieldType.Text || field.type == FieldType.End || field.type == FieldType.Spacer)
         {
            if (field.stream == null)
               field.stream = new MemoryStream(Encoding.UTF8.GetBytes(field.value));
         }
         if (field.header == null)
         {
            field.header = GetHeader(field);
            field.headerBytes = Encoding.ASCII.GetBytes(field.header);
         }
      }

      private string GetHeader(Field field)
      {
         if (field.type == FieldType.End)
            return string.Format("--{0}--", _boundary);
         if (field.type == FieldType.Spacer)
            return "\r\n";
         var str = new StringBuilder();
         str.AppendFormat("--{0}", _boundary);
         str.Append(NewLine);
         str.AppendFormat(@"Content-Disposition: form-data; name=""{0}""", field.name);
         if (field.type == FieldType.File)
            str.AppendFormat(@"; filename=""{0}""", Path.GetFileName(field.fileName));
         str.Append(NewLine);
         if (field.type == FieldType.File)
         {
            if (string.IsNullOrWhiteSpace(field.contentType))
               field.contentType = "application/octet-stream";
         }
         str.AppendFormat(@"Content-Type: {0}", field.contentType);
         str.Append(NewLine);
         str.Append(NewLine);
         return str.ToString();
      }

      private string NewLine
      {
         get
         {
            return "\r\n";
         }
      }
   }

   /// <summary>
   /// A Multipart body composer.
   /// </summary>
   public class MultiPart
   {
      private List<Field> _fields = new List<Field>();
      private string _boundary;

      public string Boundary
      {
         get { return _boundary; }
      }

      public MultiPart()
      {
         _boundary = GenerateBoundary();
      }

      protected string GenerateBoundary()
      {
         return Guid.NewGuid().ToString();
      }

      public void AddField(string field, string value)
      {
         if (_fields.Count > 0)
            AddSpacer();
         _fields.Add(new Field() { name = field, value = value, type = FieldType.Text, contentType = "text/plain; charset=utf-8" });
      }

      public void AddFileField(string field, string fileName)
      {
         if (_fields.Count > 0)
            AddSpacer();
         _fields.Add(new Field() { name = field, type = FieldType.File, fileName = fileName, contentType = "application/octet-stream" });
      }

      public void AddFileField(string field, string fileName, Stream stream)
      {
         if (_fields.Count > 0)
            AddSpacer();
         _fields.Add(new Field() { name = field, type = FieldType.File, fileName = fileName, stream = stream });
      }

      private void AddSpacer()
      {
         _fields.Add(new Field() { type = FieldType.Spacer, value = "" });
      }

      public Stream GetStream()
      {
         if (_fields.Count > 0)
         {
            AddSpacer();
            AddEnd();
         }
         return new MultiPartStream(_fields, _boundary);
      }

      private void AddEnd()
      {
         _fields.Add(new Field() { type = FieldType.End, value = "" });
      }

      public byte[] GetBytes()
      {
         var stream = GetStream();
         var memStream = new MemoryStream();
         stream.CopyTo(memStream);
         return memStream.ToArray();
      }
   }
}
