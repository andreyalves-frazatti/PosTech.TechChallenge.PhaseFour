using TechChallenge.Domain.Entities;

namespace TechChallenge.Contracts;

public record MessageContract(Guid Id, string? Title, string? Content, int MessageType, DateTime CreatedAt)
{
    public override string ToString()
        => $"Id: {Id} - Title: {Title} | Content: {Content}";

    public Message ToMessage() 
        => Message.Factory.FromId(Id, Title!, Content!, CreatedAt, (MessageType) MessageType);
}