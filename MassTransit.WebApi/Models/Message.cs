namespace MassTransit.WebApi.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string? TextMessage { get; set; }
    }
}