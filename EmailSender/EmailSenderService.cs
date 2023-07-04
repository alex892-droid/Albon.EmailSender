using System.Net.Mail;
using System.Net;

namespace Albon.EmailSender
{
    public class EmailSenderService
    {
        public IEmailSenderConfiguration EmailSenderConfiguration { get; set; }

        private SmtpClient SmtpClient { get; set; }
        
        public EmailSenderService(IEmailSenderConfiguration emailSenderConfiguration)
        {
            EmailSenderConfiguration = emailSenderConfiguration;
            SmtpClient = new SmtpClient(EmailSenderConfiguration.SmtpServer.SMTPServerAddress, EmailSenderConfiguration.SmtpServer.SMTPPort);
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Credentials = new NetworkCredential(EmailSenderConfiguration.Sender.EmailAddress, EmailSenderConfiguration.Sender.EmailPassword);
            SmtpClient.EnableSsl = true;
        }

        public void SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage(EmailSenderConfiguration.Sender.EmailAddress, recipientEmail, subject, body);
                SmtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email: " + ex.Message);
            }
        }
    }
}
