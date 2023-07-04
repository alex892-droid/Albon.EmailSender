namespace Albon.EmailSender
{
    public class Sender
    {
        public string EmailAddress { get; set; }

        public string EmailPassword { get; set; }

        public Sender(string emailAddress, string emailPassword) 
        {
            this.EmailAddress = emailAddress;
            this.EmailPassword = emailPassword;
        }
    }
}
