namespace Consumer.Handler
{
    public interface IMessageHandler<T>
    {
        void Handle(T message);
    }
}
