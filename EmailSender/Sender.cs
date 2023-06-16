using AttributeSharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{
    public class Sender
    {
        [DatabaseKey]
        public string Id { get; set; }

        public string EmailAddress { get; set; }

        public string EmailPassword { get; set; }

        public bool Use { get; set; }

        public Sender(string emailAddress, string emailPassword) 
        {
            this.Id = Guid.NewGuid().ToString();
            this.EmailAddress = emailAddress;
            this.EmailPassword = emailPassword;
            this.Use = false;
        }
    }
}
