using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.Commands.NewMessage;

namespace TechChallenge.API.Controllers;

[ApiController]
[Route("Messages")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(NewMessageCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Accepted();
    }
}