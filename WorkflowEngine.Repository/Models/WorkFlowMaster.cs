using System;
using System.Collections.Generic;

namespace WorkflowEngine.Repository.Models
{
    public partial class WorkFlowMaster
    {
        public WorkFlowMaster()
        {
            WorkFlowTask = new HashSet<WorkFlowTask>();
            WorkFlowVariable = new HashSet<WorkFlowVariable>();
        }

        public int WorkFlowId { get; set; }
        public string WorkFlowName { get; set; }
        public string LaunchType { get; set; }
        public int? Period { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsApprovalRequired { get; set; }
        public string WorkFlowDescription { get; set; }

        public virtual ICollection<WorkFlowTask> WorkFlowTask { get; set; }
        public virtual ICollection<WorkFlowVariable> WorkFlowVariable { get; set; }
    }
}
