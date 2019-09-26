using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlow.Engine.Task
{
    public class MailsSender
    {
        public string Host { get; }
        public int Port { get; }
        public bool EnableSsl { get; }
        public string User { get; }
        public string Password { get; }
        public bool IsBodyHtml { get; }


        public MailsSender()
        {
            //Host = GetMailSenderSetting("host");
            //Port = int.Parse(GetSetting("port"));
            //EnableSsl = bool.Parse(GetSetting("enableSsl"));
            //User = GetSetting("user");
            //Password = GetSetting("password");
            //IsBodyHtml = bool.Parse(GetSetting("isBodyHtml", "true"));
        }







    }
}
