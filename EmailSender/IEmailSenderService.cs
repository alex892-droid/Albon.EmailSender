using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{
    public interface IEmailSenderService
    {
        public void SendEmail(string recipientEmail, string subject, string body);

        public void AddSMTPServer(string smtpServerAddress, int smtpPort);

        public void DeleteSMTPServer(string id);

        public void DefineSMTPServerToUse(string id);

        public void AddSender(string emailAddress, string emailAddressPassword);

        public void DeleteSender(string id);

        public void DefineSenderToUse(string id);

        public IEnumerable<Sender> SearchSenders();

        public IEnumerable<SmtpServer> SearchSMTPServers();
    }
}
