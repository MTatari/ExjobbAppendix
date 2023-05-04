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
    public class SignalToFirstWF : StepBody
    {
        private IServiceProvider _provider;
        public SignalToFirstWF(IServiceProvider provider)
        {
            _provider = provider;
        }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var host = _provider.GetService<IWorkflowHost>();
            host.PublishEvent("MyEvent", "T25", "The event is published!");
            return ExecutionResult.Next();

        }
    }
}
