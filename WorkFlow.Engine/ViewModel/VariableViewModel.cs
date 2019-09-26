using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFlow.Engine.ViewModel
{
    public class VariableViewModel
    {
        public int VariableId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int WorkFlowId { get; set; }

    }
}
