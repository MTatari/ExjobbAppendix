using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1.Steps
{
    public class Write1IfExecuted : StepBodyAsync
    {
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
           
            await Task.Delay(10000);
            Console.WriteLine("1");
            return ExecutionResult.Next();
        }
    }
}
