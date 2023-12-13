namespace Consumer.Setting
{
    public class KafkaConsumerService:IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public KafkaConsumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Start the Kafka consumer in a background thread
            Task.Run(() => ConsumeMessages());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Stop any necessary cleanup or shutdown logic
            return Task.CompletedTask;
        }

        private void ConsumeMessages()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var consumer = scope.ServiceProvider.GetRequiredService<KafkaConsumer<dynamic>>();
                consumer.Subscribe("your-topic");
                consumer.Consume();
            }
        }
    }


}
