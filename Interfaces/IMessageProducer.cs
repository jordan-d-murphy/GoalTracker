namespace GoalTracker.RabbitMQ
{
    public interface IMessageProducer 
    {
        void SendMessage<T> (T message);

        void SendOnlinePresence<T> (T message);
    }
}
