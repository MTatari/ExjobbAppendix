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
    public class NumberInput : StepBody
    {

        public int firstNum { get; set; }
        public int secondNum { get; set; }
        public int sum { get; set; }
        public ArrayList numberList { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Mata in två siffror....första Siffran: ");
            firstNum = int.Parse(s: Console.ReadLine());
            Console.WriteLine("Andra Siffran:");
            secondNum = int.Parse(s: Console.ReadLine());
            sum = firstNum + secondNum;
            numberList = new ArrayList();
            numberList.Add(firstNum);
            numberList.Add(secondNum);
            numberList.Add(sum);
            return ExecutionResult.Next();
        }
    }
}
