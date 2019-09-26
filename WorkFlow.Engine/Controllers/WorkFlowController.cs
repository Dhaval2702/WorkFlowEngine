using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Engine.ViewModel;
using WorkflowEngine.Repository.Models;
using WorkflowEngine.Repository.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkFlow.Engine.Controllers
{
    public class WorkFlowController : Controller
    {
        private IWorkFlowRepository workFlowRepository;
        private readonly IMapper _mapper;

        public WorkFlowController(IWorkFlowRepository workFlowRepository, IMapper mapper)
        {
            this.workFlowRepository = workFlowRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("GetMasterWorkFlow")]
        public async Task<IActionResult> GetAllMasterWorkFlow()
        {
            try
            {
                var AllMasterWorkFlow = _mapper.Map<List<WorkflowViewModel>>(await workFlowRepository.GetAllMasterWorkFlow());
                if (AllMasterWorkFlow == null)
                {
                    return NotFound();
                }

                return Ok(AllMasterWorkFlow);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetWorkFlowById")]
        public async Task<IActionResult> GetWorkFlowById(int workflowId)
        {
            if (workflowId == null)
            {
                return BadRequest();
            }
            try
            {
                var workFlow = _mapper.Map<WorkflowViewModel>(await workFlowRepository.GetMasterWorkFlowById(workflowId));
                if (workFlow == null)
                {
                    return NotFound();
                }

                return Ok(workFlow);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("CreateWorkFlow")]
        public async Task<IActionResult> CreateWorkFlow([FromBody]WorkflowViewModel workflowViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var workFlow = _mapper.Map<WorkFlowMaster>(workflowViewModel);
                    var workflowId = await workFlowRepository.CreateNewWorkFlow(workFlow);
                    if (workflowId > 0)
                    {
                        return Ok(workflowId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateWorkFlow")]
        public async Task<IActionResult> UpdateWorkFlow([FromBody]WorkflowViewModel workflowViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updateworkFlow = _mapper.Map<WorkFlowMaster>(workflowViewModel);
                    await workFlowRepository.UpdateWorkFlow(updateworkFlow);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
