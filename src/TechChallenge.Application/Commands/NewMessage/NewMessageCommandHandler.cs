using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Commands.NewMessage;

public class NewMessageCommandHandler : IRequestHandler<NewMessageCommand>
{
    private readonly ILogger<NewMessageCommandHandler> _logger;
    private readonly IValidator<NewMessageCommand> _validator;
    private readonly IMessageService _messageService;
    
    public NewMessageCommandHandler
    (
        ILogger<NewMessageCommandHandler> logger,
        IValidator<NewMessageCommand> validator,
        IMessageService messageService
    )
    {
        _logger = logger;
        _validator = validator;
        _messageService = messageService;
    }

    public async Task Handle(NewMessageCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validation = await _validator.ValidateAsync(command, cancellationToken);
            
            if (!validation.IsValid)
            {
                _logger.LogError("Invalid command. Errors: {Errors}", validation.Errors);
                return;
            }

            var message = Message.Factory.New(command.Title, command.Content);

            await _messageService.NotifyAsync(message, cancellationToken);

            _logger.LogInformation("Message published successfully. ID: {MessageId}", message.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to publish message. Error: {Message}", e.Message);
        }
    }
}