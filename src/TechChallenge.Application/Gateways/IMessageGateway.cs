using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Gateways;

public interface IMessageGateway
{
    Task InsertAsync(Message message, CancellationToken cancellationToken);

    Task<Message> FindAsync(Guid messageId, CancellationToken cancellationToken);
}