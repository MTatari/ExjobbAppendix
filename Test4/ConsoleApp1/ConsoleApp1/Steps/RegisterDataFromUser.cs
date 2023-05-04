using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1.Steps
{

    public class RegisterDataFromUser : StepBody 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.Write("Enter a Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter an ID");
            Id = int.Parse(s: Console.ReadLine());
            Description = $"{Name} has {Id} as an Id";
            return ExecutionResult.Next();
        }
    }
}
