using MediatR;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Commands.NewMessage;

public record NewMessageCommand(string Title, string Content, MessageType MessageType)
    : IRequest;