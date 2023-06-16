using AttributeSharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{
    public class SmtpServer
    {
        [DatabaseKey]
        public string Id { get; set; }

        public string SMTPServerAddress { get; set; }

        public int SMTPPort {get; set;}

        public bool Use { get; set; }

        public SmtpServer(string smtpServerAddress, int smtpPort) 
        {
            Id = Guid.NewGuid().ToString();
            SMTPServerAddress = smtpServerAddress;
            SMTPPort = smtpPort;
            Use = false;
        }
    }
}
