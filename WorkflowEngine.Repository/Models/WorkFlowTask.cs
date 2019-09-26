using System;
using System.Collections.Generic;

namespace WorkflowEngine.Repository.Models
{
    public partial class WorkFlowTask
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int WorkflowId { get; set; }

        public virtual WorkFlowMaster Workflow { get; set; }
    }
}
