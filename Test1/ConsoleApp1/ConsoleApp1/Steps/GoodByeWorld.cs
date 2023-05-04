using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;


namespace ConsoleApp1.Steps
{
    public class GoodbyeWorld : StepBody
    {
        private ManualResetEvent _signal;

        public GoodbyeWorld()
        {
            Console.WriteLine("Empty: Injection didn't work!");
        }
        public GoodbyeWorld(ManualResetEvent signal)
        {
            _signal = signal;
        }
        public string ByeMessage { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine(" ");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Recived that {ByeMessage}");
            _signal.Set();
            return ExecutionResult.Next();
        }
    }
}
