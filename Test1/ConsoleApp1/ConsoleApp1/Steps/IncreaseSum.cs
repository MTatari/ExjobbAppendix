using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1.Steps
{

    public class IncreaseSum : StepBody 
    {
        public int n { get; set; }
       
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            
            n = n + 1;
            return ExecutionResult.Next();
        }
    }
}
