using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1.Steps
{
    public class InvalidName : StepBody
    {

       
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Du har uppgett ett ogiltigt namn ");
            return ExecutionResult.Next();
        }
    }
}
