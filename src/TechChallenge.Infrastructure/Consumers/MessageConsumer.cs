using MassTransit;
using Microsoft.Extensions.Logging;
using TechChallenge.Application.Gateways;
using TechChallenge.Contracts;

namespace TechChallenge.Infrastructure.Consumers;

public class MessageConsumer : IConsumer<MessageContract>
{
    private readonly ILogger<MessageConsumer> _logger;
    private readonly IMessageGateway _messageGateway;

    public MessageConsumer(ILogger<MessageConsumer> logger, IMessageGateway messageGateway)
    {
        _logger = logger;
        _messageGateway = messageGateway;
    }

    public Task Consume(ConsumeContext<MessageContract> context)
    {
        _logger.LogInformation("[{Class}] Consumed message: {@Message}", nameof(MessageConsumer), context.Message);

        return _messageGateway.InsertAsync(context.Message.ToMessage(), context.CancellationToken);
    }
}