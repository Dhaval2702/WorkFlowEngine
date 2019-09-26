using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlow.Engine.ViewModel
{
    public class WorkflowViewModel
    {
        public int WorkFlowId { get; set; }

        public string WorkFlowName { get; set; }

        public string LaunchType { get; set; }

        public int Period { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsApprovalRequired { get; set; }

        public string WorkFlowDescription { get; set; }

        public List<VariableViewModel> variableViewModels { get; set; }

        public List<TaskViewModel> taskViewModels { get; set; }

    }



    public enum  LaunchType
    {
        Startup =0,
        Trigger =1,
        Periodic =2,
        Cron=3
    }
}
