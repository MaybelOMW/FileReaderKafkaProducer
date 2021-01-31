using Autofac; // for using IContainer
using Confluent.Kafka;
using ReadCSV.FileReader;
using ReadCSV.Service;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Net;
using System.Threading.Tasks;
// using System.Configuration;

namespace ReadCSV
{
    class Program
    {
        // Local container only accessible by local static method
        private static IContainer _container;
        // Register Dependencies for building container during Program class contruction.
        static Program()
        {
            var logger = new LoggerConfiguration().MinimumLevel.Debug()
                                                  .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                                                  .WriteTo.File("Logs\\PublisherLog.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
                                                  .CreateLogger();
            
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = Dns.GetHostName(),
            };

            var producer = new ProducerBuilder<Null, string>(config).Build();

            // Registers instances into builder and assign to Autofac container
            var builder = new ContainerBuilder();
            builder.RegisterInstance(logger).As<ILogger>().SingleInstance();
            builder.RegisterInstance(producer).As<IProducer<Null, string>>().SingleInstance();
            builder.RegisterType<Reader>().As<IReader>().SingleInstance();
            builder.RegisterType<KafkaProducerService>().As<IService>().SingleInstance();
            _container = builder.Build();
        }

        static async Task Main(string[] args)
        {
            var service = _container.Resolve<IService>();
            await service.Start();
            service.Stop();
            Console.ReadLine();
        }
    }
}
