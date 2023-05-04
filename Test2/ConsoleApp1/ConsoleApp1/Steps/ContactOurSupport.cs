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
    public class ContactOurSupport : StepBody
    {

       
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Kontakta gärna vår kundservice");

            return ExecutionResult.Next();
        }
    }
}
