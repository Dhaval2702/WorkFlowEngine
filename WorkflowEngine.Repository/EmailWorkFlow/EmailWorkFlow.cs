using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Repository.Models;
using WorkflowEngine.Repository.Repository;

namespace WorkflowEngine.Repository.EmailWorkFlow
{
    public class EmailWorkFlow : IEmailWorkFlow
    {

        private IWorkFlowRepository workFlowRepository;

        public EmailWorkFlow(IWorkFlowRepository workFlowRepository)
        {
            this.workFlowRepository = workFlowRepository;
        }

        public EmailModel GetVariableConfigration(int workFlowId)
        {
            var emailModel = new EmailModel();
            var emailconfig = workFlowRepository.GetMasterWorkFlowById(workFlowId).Result;
            foreach (var wkVariable in emailconfig.WorkFlowVariable)
            {
                switch (wkVariable.Name.ToUpper())
                {
                    case "HOST":
                        emailModel.Host = wkVariable.Value;
                        break;

                    case "PORT":
                        emailModel.Port = Convert.ToInt32(wkVariable.Value);
                        break;

                    case "FROM":
                        emailModel.FromEmail = wkVariable.Value;
                        break;

                    case "TO":
                        emailModel.ToEmail = wkVariable.Value;
                        break;

                    case "BODY":
                        emailModel.Body = wkVariable.Value;
                        break;

                    case "SUBJECT":
                        emailModel.Subject = wkVariable.Value;
                        break;

                    case "PASSWORD":
                        emailModel.Password = wkVariable.Value;
                        break;
                }
            }

            return emailModel;

        }

        public void SendEmail(EmailModel emailModel)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(emailModel.FromEmail);
                message.To.Add(new MailAddress(emailModel.ToEmail));
                message.Subject = emailModel.Subject;
                message.IsBodyHtml = true;
                message.Body = emailModel.Body;
                smtp.Port = emailModel.Port;
                smtp.Host = emailModel.Host;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emailModel.FromEmail, emailModel.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception)
            {
            }
        }


    }
}
