using MassTransit;
using Microsoft.Extensions.Logging;
using TechChallenge.Application.Services;
using TechChallenge.Contracts;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Services;

public class MessageService : IMessageService
{
    private const string Exchange = "exchange:message";

    private readonly IBus _bus;
    private readonly ILogger<MessageService> _logger;

    public MessageService(IBus bus, ILogger<MessageService> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    public async Task NotifyAsync(Message message, CancellationToken cancellationToken)
    {
        var endpoint = await _bus.GetSendEndpoint(new Uri(Exchange));
        
        MessageContract messageContract = new(
            message.Id,
            message.Title,
            message.Content,
            (int) message.MessageType,
            message.CreatedAt);
        
        await endpoint.Send(messageContract, cancellationToken);

        _logger.LogInformation("Message ID: {MessageId} published", message.Id);
    }
}