using Confluent.Kafka;
using Newtonsoft.Json;
using ReadCSV.FileReader;
using Serilog;
using System;
using System.Threading.Tasks;

namespace ReadCSV.Service
{
    public class KafkaProducerService : IService
    {
        private ILogger _logger;
        private IProducer<Null, string> _producer;
        private IReader _reader;
        private string _topic;
         
        public KafkaProducerService(ILogger logger, IProducer<Null, string> producer, IReader reader)
        {
            _logger = logger;
            _producer = producer;
            _reader = reader;
        }

        public async Task Start()
        {
            Console.WriteLine("What topic to publish?");
            _topic = Console.ReadLine();

            var dataObj = _reader.ReadData();
            string dataStr = JsonConvert.SerializeObject(dataObj);

            await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = dataStr });
            _logger.Information("Published topic: {0}", _topic);
            _logger.Information("Data string: {0}", dataStr);
            _logger.Information("Total character received: {0}", dataStr.Length);
        }

        public void Stop()
        {
            _producer.Dispose();
            _logger.Information("Disposing producer instance.");
            _logger.Information("---------- Producer Instance Disposed ----------");
        }

    }
}
