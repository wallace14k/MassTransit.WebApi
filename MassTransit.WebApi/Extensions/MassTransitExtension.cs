using MassTransit.WebApi.Models.Consumers;

namespace MassTransit.WebApi.Extensions
{
    public static class MassTransitExtension
    {
        public static void AddMassTransitExtension(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();
                x.AddConsumer<MessageConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("amqp://localhost:5672"), h =>
                    {
                        h.Username("admin");
                        h.Password("admin");
                    });
                    cfg.ReceiveEndpoint("MensagemEnviada", e =>
                    {
                        e.ConfigureConsumer<MessageConsumer>(context);
                        e.Bind("Mensagem");
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
