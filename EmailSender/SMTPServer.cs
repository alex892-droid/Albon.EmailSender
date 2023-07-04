namespace Albon.EmailSender
{
    public class SmtpServer
    {
        public string SMTPServerAddress { get; set; }

        public int SMTPPort {get; set;}

        public SmtpServer(string smtpServerAddress, int smtpPort) 
        {
            this.SMTPServerAddress = smtpServerAddress;
            this.SMTPPort = smtpPort;
        }
    }
}
