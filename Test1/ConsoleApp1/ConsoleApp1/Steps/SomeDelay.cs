using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1.Steps
{

    public class SomeDelay : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("How many seconds you want the delay");
            var sec = int.Parse(Console.ReadLine()) * 1000;
            Thread.Sleep(sec);
            return ExecutionResult.Next();

        }
    }

}
