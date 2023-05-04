using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1.Steps
{
    public class NameInput : StepBody
    {
        public string name { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Skriv ditt namn: ");
            name = Console.ReadLine();
            return ExecutionResult.Next();
        }
    }
}
