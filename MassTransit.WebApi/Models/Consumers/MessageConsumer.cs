namespace MassTransit.WebApi.Models.Consumers
{
    public class MessageConsumer: IConsumer<Message>
    {
        private readonly ILogger<MessageConsumer> _logger;
        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Message> context)
        {
            await context.GetSendEndpoint(new Uri("exchange:Mensagem"));
            _logger.LogWarning("Sua Mensagem é {0}",context.Message.TextMessage);
        }
    }
    
}