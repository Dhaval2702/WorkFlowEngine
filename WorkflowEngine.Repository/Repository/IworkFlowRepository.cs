using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Repository.Models;

namespace WorkflowEngine.Repository.Repository
{
   public interface IWorkFlowRepository
    {
        Task<List<WorkFlowMaster>> GetAllMasterWorkFlow();

        Task<WorkFlowMaster> GetMasterWorkFlowById(int workflowId);

        Task<int> CreateNewWorkFlow(WorkFlowMaster workFlowMaster);

        Task<int> DeleteWorkFlow(int? workFlowId);

        Task UpdateWorkFlow(WorkFlowMaster workFlowMaster);


    }
}
