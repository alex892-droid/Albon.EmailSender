using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BasicLinkedObjectBase;

namespace EmailSender
{
    public class EmailSenderService : IEmailSenderService
    {
        public IObjectBaseService DatabaseService { get; set; }

        private Sender Sender { get; set; }

        private SmtpServer SmtpServer { get; set; }

        private SmtpClient SmtpClient { get; set; }
        
        public EmailSenderService(IObjectBaseService databaseService)
        {
            DatabaseService = databaseService;
            ActualizeSMTPParameters();
        }

        private void ActualizeSMTPParameters()
        {
            try
            {
                Sender = DatabaseService.Query<Sender>().Single(sender => sender.Use == true);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No usable sender found.", ex);
            }

            try
            {
                SmtpServer = DatabaseService.Query<SmtpServer>().Single(server => server.Use == true);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No usable SMTP server found.", ex);
            }

            SmtpClient = new SmtpClient(SmtpServer.SMTPServerAddress, SmtpServer.SMTPPort);
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Credentials = new NetworkCredential(Sender.EmailAddress, Sender.EmailPassword);
            SmtpClient.EnableSsl = true;
        }

        public void SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage(Sender.EmailAddress, recipientEmail, subject, body);
                SmtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email: " + ex.Message);
            }
        }

        public void AddSMTPServer(string smtpServerAddress, int smtpPort)
        {
            SmtpServer smtpServer = new SmtpServer(smtpServerAddress, smtpPort);
            DatabaseService.Add(smtpServer);
        }

        public void DefineSMTPServerToUse(string id)
        {
            var server = DatabaseService.Query<SmtpServer>().Single(server => server.Id == id);
            server.Use = true;
            DatabaseService.Update(server);
            ActualizeSMTPParameters();
        }

        public void DeleteSMTPServer(string id)
        {
            DatabaseService.Delete<SmtpServer>(id);
        }

        public void AddSender(string emailAddress, string emailAddressPassword)
        {
            Sender sender = new Sender(emailAddress, emailAddressPassword);
            DatabaseService.Add(sender);
        }

        public void DeleteSender(string id)
        {
            DatabaseService.Delete<Sender>(id);
        }

        public void DefineSenderToUse(string id)
        {
            var sender = DatabaseService.Query<Sender>().Single(sender => sender.Id == id);
            sender.Use = true;
            DatabaseService.Update(sender);
            ActualizeSMTPParameters();
        }

        public IEnumerable<Sender> SearchSenders()
        {
            return DatabaseService.Query<Sender>();
        }

        public IEnumerable<SmtpServer> SearchSMTPServers()
        {
            return DatabaseService.Query<SmtpServer>();
        }
    }
}
