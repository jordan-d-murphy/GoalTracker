using System.Text;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using GoalTracker.RabbitMQ;
using RabbitMQ.Client;

namespace GoalTracker.Utils;

public class RabbitMQProducer : IMessageProducer
{
    public void SendMessage<T> (T message)
    {
        // var factory = new ConnectionFactory { HostName = "localhost" };

        var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    DispatchConsumersAsync = false,
                    ConsumerDispatchConcurrency = 1,
                };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare("ApplicationNotifications",
                    durable: false,
                    exclusive: false,
                    autoDelete: true,
                    arguments: null);

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "", routingKey: "ApplicationNotifications", body: body);
    }

    public void SendOnlinePresence<T> (T message)
    {
        // var factory = new ConnectionFactory { HostName = "localhost" };

        var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    DispatchConsumersAsync = false,
                    ConsumerDispatchConcurrency = 1,
                };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare("OnlinePresenceIndications",
                    durable: false,
                    exclusive: false,
                    autoDelete: true,
                    arguments: null);

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "", routingKey: "OnlinePresenceIndications", body: body);
    }
}