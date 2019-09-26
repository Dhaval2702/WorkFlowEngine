using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Engine.ViewModel;
using WorkflowEngine.Repository.EmailWorkFlow;
using WorkflowEngine.Repository.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkFlow.Engine.Controllers
{
    public class EventTriggerController : Controller
    {
        private IWorkFlowRepository workFlowRepository;
        private IEmailWorkFlow emailWorkFlow;
        private readonly IMapper _mapper;


        public EventTriggerController(IWorkFlowRepository workFlowRepository, IMapper mapper,IEmailWorkFlow emailWorkFlow )
        {
            this.workFlowRepository = workFlowRepository;
            this.emailWorkFlow = emailWorkFlow;
            this._mapper = mapper;
        }

        // GET: /<controller>/
        public async Task<IActionResult> EmailEventTriggerAsync(int workflowId)
        {
            if (workflowId == null)
            {
                return BadRequest();
            }
            try
            {
                var emailConfigration = emailWorkFlow.GetVariableConfigration(workflowId);
                if (emailConfigration == null)
                {
                    return NotFound();
                }

                emailWorkFlow.SendEmail(emailConfigration);
                return Ok(emailConfigration);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
