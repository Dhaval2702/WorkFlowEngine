using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Repository.Models;

namespace WorkflowEngine.Repository.Repository
{
    public class WorkFlowRepository : IWorkFlowRepository
    {
        private WorkFlowDbContext dBContext;

        public WorkFlowRepository(WorkFlowDbContext wkdbContext)
        {
            this.dBContext = wkdbContext;
        }

        public async Task<int> CreateNewWorkFlow(WorkFlowMaster workFlowMaster)
        {
            if (dBContext != null)
            {
                await dBContext.WorkFlowMaster.AddAsync(workFlowMaster);
                await dBContext.SaveChangesAsync();

                return workFlowMaster.WorkFlowId;
            }

            return 0;
        }
        
        public async Task<int> DeleteWorkFlow(int? workflowId)
        {
            int result = 0;
            if (dBContext != null)
            {
                //Find the post for specific post id
                var post = await dBContext.WorkFlowMaster.FirstOrDefaultAsync(x => x.WorkFlowId == workflowId);

                if (post != null)
                {
                    //Delete that post
                    dBContext.WorkFlowMaster.Remove(post);

                    //Commit the transaction
                    result = await dBContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<WorkFlowMaster>> GetAllMasterWorkFlow()
        {
            if (dBContext != null)
            {
                return await dBContext.WorkFlowMaster.Include(x=>x.WorkFlowTask).Include(x=>x.WorkFlowVariable).ToListAsync();
            }

            return null;
        }

        public async Task<WorkFlowMaster> GetMasterWorkFlowById(int workflowId)
        {
            if (dBContext != null)
            {
                return await dBContext.WorkFlowMaster
                            .Include(x=>x.WorkFlowTask)
                            .Include(x=>x.WorkFlowVariable)
                            .FirstOrDefaultAsync(x=>x.WorkFlowId == workflowId);
            }

            return null;
        }

       
        public async Task UpdateWorkFlow(WorkFlowMaster workFlowMaster)
        {
            if (dBContext != null)
            {
                //Delete that post
                dBContext.WorkFlowMaster.Update(workFlowMaster);

                //Commit the transaction
                await dBContext.SaveChangesAsync();
            }
        }
    }
}
