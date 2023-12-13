using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Producer.Configuration;

namespace Producer.Setting
{
    public class KafkaProducer
    {
        private readonly KafkaProducerConfig _config;

        public KafkaProducer(IOptions<KafkaProducerConfig> config)
        {
            _config = config.Value;
        }

        public async Task<TopicPartitionOffset> ProduceAsync<T>(string Key, T message)
        {
            var config = new ProducerConfig { BootstrapServers = _config.BootstrapServers };
            string serializedMessage = JsonConvert.SerializeObject(message);
            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var result = await producer.ProduceAsync("your-topic", new Message<string, string> { Key = Key, Value = serializedMessage });

                return result.TopicPartitionOffset; 
            }
        }
    }
}
