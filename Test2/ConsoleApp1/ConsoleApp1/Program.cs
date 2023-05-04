using ConsoleApp1;
using ConsoleApp1.Steps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Services.DefinitionStorage;

namespace Program // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static ManualResetEvent signal;

        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServicesDSL();
            var host = serviceProvider.GetService<IWorkflowHost>();
            //host.RegisterWorkflow<FirstWorkflow, MyData>(); //FirstWorkflow: Workflow builder from the code
            //This is identical to host.RegisterWorkflow<FirstWorkflow, MyData>(); but in JSON
            LoadDefinition(serviceProvider, "C:/Users/semutat001/source/repos/ConsoleApp1/ConsoleApp1", "FirstWorkflow", "json");




            host.Start();


            MyData InitializeData = new MyData();


             host.StartWorkflow("HelloWorld", 1, InitializeData);


            //signal = new ManualResetEvent(false);
            //signal.WaitOne();

            while (true)
            {
                
            }

            host.Stop();
        }

        private static IServiceProvider ConfigureServicesDSL()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            services.AddWorkflowDSL();

            //For Dependecy injections
            //services.AddTransient<GoodbyeWorld>();
            //services.AddTransient(provider => signal);
            //services.AddTransient<SignalToFirstWF>();
            //services.AddTransient<IServiceProvider, ServiceProvider>();

            // Add step middleware
            services.AddWorkflowStepMiddleware<StepMiddleware>();

            // Add post middleware
            services.AddWorkflowMiddleware<AfterWorkflowCompleted>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
        static void LoadDefinition(IServiceProvider serviceProvider, String folderPath, String fileName, String type)
        {
            var serializerType = Deserializers.Yaml;

            if (string.Equals(type, "json", StringComparison.OrdinalIgnoreCase))
            {
                serializerType = Deserializers.Json;
            }
            try
            {
                var filePath = Path.Combine(folderPath, $"{fileName}.{(serializerType == Deserializers.Yaml ? "yml" : "json")}");
                var file = File.ReadAllText(filePath);
                
                var loader = serviceProvider.GetService<IDefinitionLoader>();
                if (loader == null)
                {
                    throw new Exception("Loader not initialized");

                }

                
                loader.LoadDefinition(file, serializerType);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while reading the file: {e.Message}");
            }
        }
    }

}