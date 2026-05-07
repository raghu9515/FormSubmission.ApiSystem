using FluentValidation;
using FormSubmission.Application.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace FormSubmission.Api.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator; private readonly IValidator<LoginCommand> _validator;
    public AuthController(IMediator mediator, IValidator<LoginCommand> validator) { _mediator=mediator; _validator=validator; }
    [HttpPost("login")] public async Task<IActionResult> Login(LoginCommand command) { await _validator.ValidateAndThrowAsync(command); return Ok(await _mediator.Send(command)); }
}
