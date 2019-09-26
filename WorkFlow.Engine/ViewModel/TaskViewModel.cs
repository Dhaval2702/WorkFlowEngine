using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlow.Engine.ViewModel
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskType { get; set; }

        public string TaskDescription { get; set; }

        public int WorkFlowId { get; set; }
    }
}
