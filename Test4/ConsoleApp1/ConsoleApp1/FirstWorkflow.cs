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

    public class FirstWorkflow : IWorkflow<MyData>
    {
        public string Id => "HelloWorld";
        public int Version => 1;

        public void Build(IWorkflowBuilder<MyData> builder)
        {
            builder
                .StartWith(context => ExecutionResult.Next()) 
                .Then<RegisterDataFromUser>()
                    .Input(step => step.Id, data => data.Id)
                    .Input(step => step.Name, data => data.Name)
                    .Output(data => data.RejectedName, step => step.Name)
                    .Output(data => data.Description, step => step.Description)
                .WaitFor("MyEvent", data => "T25", data => new DateTime(2023, 4, 1), data => data.RejectedName.Equals("Stop") ) // context.Workflow.Id == ExecutionResult.Next() returned in the previous comment. Observer the Cancelcondition
                    .Output(data => data.ExternalData, step => step.EventData) //Observe step.EventData
                .Then<RegisterMoreDetailsFromUser>()
                    .Input(step => step.DescriptionWithHobbies, data => data.Description)
                    .Output(data => data.Description, step => step.DescriptionWithHobbies)
                .Then<GoodbyeWorld>()
                    .Input(step => step.ByeMessage, data => data.Description + "\nAnd recived the following data from external event: " + data.ExternalData + "\n-------------------------");
        }
    }
    }


