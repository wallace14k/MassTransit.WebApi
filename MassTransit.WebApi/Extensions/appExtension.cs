using MassTransit.WebApi.Models;

namespace MassTransit.WebApi.Extensions
{
    public static class appExtension
    {
        public static void AddAppMap(this WebApplication app)
        {
            var _bus = app.Services.GetRequiredService<IBus>();

            app.MapGet("SendMessage", async (string message, CancellationToken cancellation = default) =>
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri("exchange:Mensagem"));
                await endpoint.Send(new Message { Id = Guid.NewGuid(), TextMessage = message }, cancellation);
            });
        }
    }
}