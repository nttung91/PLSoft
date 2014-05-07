namespace Technical.Utilities.Mail
{
    public class MailerFactory
    {
        public static IMailer StandardMailer(string from, string to, string subject, string body)
        {
            return new Mailer(from, to, subject, body);
        }
    }
}