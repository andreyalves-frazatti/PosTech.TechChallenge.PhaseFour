using MongoDB.Driver;
using TechChallenge.Application.Gateways;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Gateways;

public class MessageGateway : IMessageGateway
{
    private readonly IMongoCollection<Message> _collection;

    public MessageGateway(IMongoClient mongoClient)
    {
        _collection = mongoClient
            .GetDatabase("TechChallenge")
            .GetCollection<Message>("Messages");
    }

    public Task InsertAsync(Message message, CancellationToken cancellationToken)
    {
        _collection.InsertOne(message, null, cancellationToken);

        return Task.CompletedTask;
    }

    public Task<Message> FindAsync(Guid messageId, CancellationToken cancellationToken)
    {
        var filter = Builders<Message>
            .Filter
            .Eq(c => c.Id, messageId);

        return _collection
            .Find(filter)
            .FirstOrDefaultAsync(cancellationToken);
    }
}