using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowEngine.Repository.EmailWorkFlow
{
    public class EmailModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string User { get; set; }

        public string FromEmail { get; set; }

        public string ToEmail { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }

        public string Password { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
