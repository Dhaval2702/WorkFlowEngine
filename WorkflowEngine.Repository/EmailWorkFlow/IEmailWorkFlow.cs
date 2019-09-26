using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Repository.Models;

namespace WorkflowEngine.Repository.EmailWorkFlow
{
   public interface IEmailWorkFlow
    {
        EmailModel GetVariableConfigration(int workFlowId);

        void SendEmail(EmailModel emailModel);
    }
}
