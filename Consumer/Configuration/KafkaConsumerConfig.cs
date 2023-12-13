namespace Consumer.Configuration
{
    public class KafkaConsumerConfig
    {
        public string BootstrapServers { get; set; }
        public string GroupId { get; set; } 
    }
}
