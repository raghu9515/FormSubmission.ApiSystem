using FluentValidation;
using FormSubmission.Application.Submissions.Commands;
using FormSubmission.Application.Submissions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace FormSubmission.Api.Controllers;
[ApiController]
[Route("api/submissions")]
public class SubmissionsController : ControllerBase
{
    private readonly IMediator _mediator; private readonly IValidator<CreateSubmissionCommand> _validator;
    public SubmissionsController(IMediator mediator, IValidator<CreateSubmissionCommand> validator) { _mediator=mediator; _validator=validator; }
    [HttpPost] public async Task<IActionResult> Create(CreateSubmissionCommand command) { await _validator.ValidateAndThrowAsync(command); var id = await _mediator.Send(command); return CreatedAtAction(nameof(GetById), new { id }, new { id }); }
    [HttpGet("{id:guid}")] public async Task<IActionResult> GetById(Guid id) { var result = await _mediator.Send(new GetSubmissionByIdQuery(id)); return result is null ? NotFound() : Ok(result); }
}
