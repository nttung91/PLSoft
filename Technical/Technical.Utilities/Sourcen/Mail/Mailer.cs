using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Technical.Utilities.Helpers;
using Technical.Utilities.Properties;

namespace Technical.Utilities.Mail
{
    /// <summary>
    /// Standard SendMail class.
    /// If you need special features create a new implementation of IMailer
    /// </summary>
    internal class Mailer : IMailer
    {
        private const string zipExtension = ".zip";

        private string _from;
        private string _to;
        private string _cc;
        private string _subject;
        private string _body;
        private string _replyTo;

        private IList<AttachmentBase> _attachments;

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        public string Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }

        public string ReplyTo
        {
            get { return _replyTo; }
            set { _replyTo = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public Mailer(string from, string to, string subject, string body) : this(from, to, null, subject, body)
        {
        }

        public Mailer(string from, string to, string cc, string subject, string body)
        {
            Debug.Assert(from != null, "from is null");
            Debug.Assert(to != null, "to is null");
            Debug.Assert(subject != null, "subject is null");

            _from = from;
            _to = to;
            _cc = cc;
            _subject = subject;
            _body = body;
            _attachments = new List<AttachmentBase>();
        }

        public Mailer(string from, string to, string cc, string subject, string body, string replyTo)
            : this(from, to, cc, subject, body)
        {
            _replyTo = replyTo;
        }

        public bool Send()
        {
            Debug.Assert(_body != null || _attachments.Count > 0, "Body or Attachment required");

            bool send = false;

            var mm = new MailMessage(_from, _to);
            mm.Subject = _subject;
            mm.Body = _body;
            mm.Sender = mm.From;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            if (!string.IsNullOrEmpty(_replyTo))
            {
                mm.ReplyToList.Add(_replyTo);
            }

            if (!string.IsNullOrEmpty(_cc))
            {
                mm.CC.Add(_cc);
            }

            //add attachments
            foreach (Attachment attachment in _attachments)
            {
                mm.Attachments.Add(attachment);
            }

            var sc = new SmtpClient();
            sc.Credentials = CredentialCache.DefaultNetworkCredentials;
            sc.Host = Settings.Default.ExchangeServer;
            sc.Timeout = 60000;
            sc.Send(mm);

            //cleanup all resources
            foreach (Attachment attachment in _attachments)
                attachment.Dispose();

            mm.Dispose();

            return send;
        }

        private void AddFileInfo(Attachment attachment, string fileName)
        {
            var fi = new FileInfo(fileName);

            // In die Disposition werden die Zeitstempel des Files geschrieben
            ContentDisposition dispo = attachment.ContentDisposition;
            dispo.CreationDate = fi.CreationTime;
            dispo.ModificationDate = fi.LastWriteTime;
            dispo.ReadDate = fi.LastAccessTime;
            dispo.FileName = fi.Name;
        }

        public void AddAttachment(string fileName)
        {
            Debug.Assert(fileName != null, "fileName is null");
            Debug.Assert(FileHelper.IsAccessible(fileName), "fileName not accessible");

            if (FileHelper.IsAccessible(fileName))
            {
                var attachment = new Attachment(fileName);
                AddFileInfo(attachment, fileName);

                _attachments.Add(attachment);
            }
        }

        public void AddAttachment(string fileName, string mediaType)
        {
            Debug.Assert(fileName != null, "fileName is null");
            Debug.Assert(mediaType != null, "mediaType is null");
            Debug.Assert(FileHelper.IsAccessible(fileName), "fileName not accessible");

            if (FileHelper.IsAccessible(fileName))
            {
                var attachment = new Attachment(fileName, mediaType);
                AddFileInfo(attachment, fileName);

                _attachments.Add(attachment);
            }
        }

        public void AddAttachment(string fileName, string mediaType, bool zipAttachment)
        {
            Debug.Assert(fileName != null, "fileName is null");
            Debug.Assert(mediaType != null, "mediaType is null");
            Debug.Assert(FileHelper.IsAccessible(fileName), "fileName not accessible");

            if (FileHelper.IsAccessible(fileName))
            {
                var fi = new FileInfo(fileName);
                Stream stream = null;

                if (zipAttachment)
                {
                    stream = Zip.Zip.ToMemoryStream(fileName);
                    mediaType = "application/zip";
                }
                else
                {
                    stream = File.OpenRead(fileName);
                }

                var attachment = new Attachment(stream, mediaType);
                AddFileInfo(attachment, fileName);

                if (zipAttachment)
                {
                    attachment.ContentDisposition.Size = stream.Length;
                    attachment.Name = FileHelper.GetFileNameWithoutExtention(fileName) + ".zip";
                    attachment.ContentDisposition.FileName = FileHelper.GetFileNameWithoutExtention(fileName) + ".zip";
                }

                _attachments.Add(attachment);
            }
        }

        public void AddAttachment(Stream content, string mediaType, string attachmentName)
        {
            Debug.Assert(content != null, "content is null");
            Debug.Assert(mediaType != null, "mediaType is null");

            var attachment = new Attachment(content, mediaType);
            attachment.Name = attachmentName;

            ContentDisposition dispo = attachment.ContentDisposition;
            dispo.FileName = attachmentName;
            dispo.CreationDate = DateTime.Today;
            dispo.ModificationDate = DateTime.Today;
            dispo.ReadDate = DateTime.Today;

            _attachments.Add(attachment);
        }
    }
}