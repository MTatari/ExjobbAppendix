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
    public class RegisterMoreDetailsFromUser : StepBody
    {

        public string DescriptionWithHobbies { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine(" ");
            Console.WriteLine("-------------------------------------------------------");
            DescriptionWithHobbies += " and likes the following hobbies: ";
            Console.WriteLine("Enter How many hobbies you have");
            int leng = int.Parse(s: Console.ReadLine());
            for (int i = 0; i < leng; i++) {
                Console.Write("Enter a hobby: ");
                String hobby = Console.ReadLine();
                DescriptionWithHobbies += $" {i+1} " + hobby;
            }

            return ExecutionResult.Next();
        }
    }
}
