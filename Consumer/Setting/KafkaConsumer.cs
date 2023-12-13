using Confluent.Kafka;
using MediatR;
using Newtonsoft.Json;

namespace Consumer.Setting
{


    public class KafkaConsumer<T>
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly IMediator _mediator;
        public KafkaConsumer(IConfiguration configuration, IMediator mediator)
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration["KafkaConsumer:BootstrapServers"],
                GroupId = "your-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
                // Add more configuration as needed
            };
            _mediator = mediator;
            _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
        }

        public void Subscribe(string topic)
        {
            _consumer.Subscribe(topic);
        }

        public async void Consume()
        {
            try
            {
                while (true)
                {
                    var consumeResult = _consumer.Consume();

                    if (consumeResult.IsPartitionEOF)
                        continue;

                    var key = consumeResult.Message.Key;
                    var value = consumeResult.Message.Value;

                    Type type = Type.GetType(key);
                    if(type != null)
                    { 
                        object instance = Activator.CreateInstance(type);
                        JsonConvert.PopulateObject(value, instance);
                        await _mediator.Send(instance);
                    } 

                }
            }
            catch (OperationCanceledException)
            {
                _consumer.Close();
            }
        }

        public void Dispose()
        {
            _consumer.Close();
        }
    }


}
