using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstwebapp.Email
{
        public class AuthMessageSenderOptions
        {
            public string SendGridUser { get; set; }
            public string SENDGRID_APIKEY { get; set; } = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
        }
}
