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
        private string topic;
         
        public KafkaProducerService(ILogger logger, IProducer<Null, string> producer, IReader reader)
        {
            _logger = logger;
            _producer = producer;
            _reader = reader;
        }

        public async Task Start()
        {
            Console.WriteLine("What topic to publish?");
            topic = Console.ReadLine();

            var dataObj = _reader.ReadData();
            string dataStr = JsonConvert.SerializeObject(dataObj);

            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = dataStr });
            _logger.Information("Published topic: {0}", topic);
            _logger.Information("Data string: {0}", dataStr);
        }

        public void Stop()
        {
            _producer.Dispose();
            _logger.Information("Disposing producer instance.");
        }

    }
}
