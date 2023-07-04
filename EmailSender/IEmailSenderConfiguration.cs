namespace Albon.EmailSender
{
    public interface IEmailSenderConfiguration
    {
        public Sender Sender { get; }

        public SmtpServer SmtpServer { get; }
    }
}
