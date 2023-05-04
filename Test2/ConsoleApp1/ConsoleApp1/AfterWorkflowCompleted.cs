using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ConsoleApp1
{
    public class AfterWorkflowCompleted : IWorkflowMiddleware
    {
        public WorkflowMiddlewarePhase Phase => WorkflowMiddlewarePhase.PostWorkflow;

        public Task HandleAsync(WorkflowInstance workflow, WorkflowDelegate next)
        {
            if (!workflow.CompleteTime.HasValue || workflow.WorkflowDefinitionId != "HelloWorld")
            {
                return next();
            }
            else
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/insertFollowingData");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                var WF = new Dictionary<string, string>
              {
                  { "InstanceID", workflow.Id },

              };
                var reqBody = JsonConvert.SerializeObject(WF);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(reqBody);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                return next();
            }
        }
    }
}
