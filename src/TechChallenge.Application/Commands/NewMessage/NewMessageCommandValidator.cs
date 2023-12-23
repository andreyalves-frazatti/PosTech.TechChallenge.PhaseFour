using FluentValidation;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Commands.NewMessage;

public class NewMessageCommandValidator : AbstractValidator<NewMessageCommand>
{
    public NewMessageCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .Length(min: 1, max: 80);

        RuleFor(c => c.Content)
            .NotEmpty()
            .Length(min: 10, max: 800);

        RuleFor(c => c.MessageType)
            .NotEqual(MessageType.Undefined);
    }
}