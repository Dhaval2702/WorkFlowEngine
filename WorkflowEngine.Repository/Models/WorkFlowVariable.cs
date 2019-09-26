using System;
using System.Collections.Generic;

namespace WorkflowEngine.Repository.Models
{
    public partial class WorkFlowVariable
    {
        public int VariableId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int WorkFlowId { get; set; }

        public virtual WorkFlowMaster WorkFlow { get; set; }
    }
}
