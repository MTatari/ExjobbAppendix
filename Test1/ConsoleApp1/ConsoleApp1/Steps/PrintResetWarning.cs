using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1.Steps
{

    public class PrintResetWarning : StepBody 
    {
       
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            
           Console.WriteLine("Reset Warning");
            return ExecutionResult.Next();
        }
    }
}
