using ConsoleApp1.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1
{

    public class SecondWorkflow : IWorkflow<MyData>
    {
        public string Id => "HelloWorld2";
        public int Version => 1;

        public void Build(IWorkflowBuilder<MyData> builder)
        {
            builder
                .StartWith(context => ExecutionResult.Next()) //The execution can match the key that the host send, in this way we can create instances of same workflow
                .Then<SomeDelay>()
                .Then<SignalToFirstWF>();
        }
    }
}


