using Microsoft.Extensions.DependencyInjection;
using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Services.DefinitionStorage;

namespace Program // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi from main");
            IServiceProvider serviceProvider = ConfigureServicesDSL();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<HelloWorldWorkflow>(); //Workflow builder from the code
            //Workflow builder from Json
            LoadDefinition(serviceProvider, "C:/Users/semutat001/source/repos/DSLExempel/ConsoleApp1/", "HelloWorldWorkflow", "json");
            //Workflow builder from Yaml
            LoadDefinition(serviceProvider, "C:/Users/semutat001/source/repos/DSLExempel/ConsoleApp1/", "HelloWorldWorkflow", "yaml"); //instead of "yaml", null could be passed also
            host.Start();

            host.StartWorkflow("HelloWorld", 1, null); //Workflow builder from the code
            host.StartWorkflow("DSLHelloWorld", 1, null); //Workflow builder from Json
            host.StartWorkflow("DSLHelloWorld2", 1, null); //Workflow builder from Yaml


            Console.ReadLine();
            host.Stop();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private static IServiceProvider ConfigureServicesDSL()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            services.AddWorkflowDSL();
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }
        }
    }


    public class HelloWorldWorkflow : IWorkflow
    {
        public string Id => "HelloWorld";
        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<HelloWorld>()
                .Then<GoodbyeWorld>();
        }
    }
    public class GoodbyeWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Goodbye");
            return ExecutionResult.Next();
        }
    }

    public class HelloWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello world");
            return ExecutionResult.Next();
        }
    }
}