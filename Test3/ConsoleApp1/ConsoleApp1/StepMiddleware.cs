using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.Net;

namespace ConsoleApp1
{
    public class StepMiddleware : IWorkflowStepMiddleware
    {

        public async Task<ExecutionResult> HandleAsync(IStepExecutionContext context, IStepBody body, WorkflowStepDelegate next)
        {

            var workflowId = context.Workflow.WorkflowDefinitionId;
            var workflowInstanceID = context.Workflow.Id;
            var stepId = context.Step.ExternalId;

            if (stepId != null)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/insertFollowingData");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                var WFollowingData = new Dictionary<string, string>
              {
                  { "WorkFlow", workflowId },
                  { "InstanceID", workflowInstanceID },
                  { "Step", stepId },
              };
                var reqBody = JsonConvert.SerializeObject(WFollowingData);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(reqBody);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
  
            return await next();
        }
    }
}
