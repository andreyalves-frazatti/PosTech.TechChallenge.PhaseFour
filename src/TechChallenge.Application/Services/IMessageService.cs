using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Services;

public interface IMessageService
{
    Task NotifyAsync(Message message, CancellationToken cancellationToken);
}