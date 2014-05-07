using System.IO;

namespace Technical.Utilities.Mail
{
    public interface IMailer
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        string Cc { get; set; }
        string ReplyTo { get; set; }

        bool Send();

        void AddAttachment(string fileName);
        void AddAttachment(string fileName, string mediaType);
        void AddAttachment(string fileName, string mediaType, bool zipAttachment);

        void AddAttachment(Stream content, string mediaType, string attachmentName);
    }
}