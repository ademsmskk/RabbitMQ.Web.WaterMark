using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Udemy.RabbitMQ.Web.WaterMark.Services
{
    public class RabbitMQPublisher
    {
        private readonly RabbitMQClientService _rabbitMQClientService;

        public RabbitMQPublisher(RabbitMQClientService rabbitMQClientService)
        {
            _rabbitMQClientService = rabbitMQClientService;
        }
        public void Publish(ProductImageCreatedEvent productImageCreatedEvent)
        {
            var channel = _rabbitMQClientService.Connect();
            var bodystring= JsonSerializer.Serialize(productImageCreatedEvent);
            var bodybyte=Encoding.UTF8.GetBytes(bodystring);
            var properties=channel.CreateBasicProperties();
            properties.Persistent = true;
            channel.BasicPublish(exchange: RabbitMQClientService.ExchangeName, routingKey: RabbitMQClientService.RoutingWaterMark, basicProperties: properties, body: bodybyte);
        }
    }
}
