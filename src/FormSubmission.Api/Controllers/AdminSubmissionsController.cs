using FluentValidation;
using FormSubmission.Application.Submissions.Commands;
using FormSubmission.Application.Submissions.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace FormSubmission.Api.Controllers;
[Authorize(Roles="Admin")]
[ApiController]
[Route("api/admin/submissions")]
public class AdminSubmissionsController : ControllerBase
{
    private readonly IMediator _mediator; private readonly IValidator<UpdateSubmissionStatusCommand> _validator;
    public AdminSubmissionsController(IMediator mediator, IValidator<UpdateSubmissionStatusCommand> validator) { _mediator=mediator; _validator=validator; }
    [HttpGet] public async Task<IActionResult> GetAll([FromQuery]string? status) => Ok(await _mediator.Send(new GetAllSubmissionsQuery(status)));
    [HttpPut("{id:guid}/status")] public async Task<IActionResult> UpdateStatus(Guid id, UpdateStatusRequest request) { var cmd = new UpdateSubmissionStatusCommand(id, request.Status); await _validator.ValidateAndThrowAsync(cmd); await _mediator.Send(cmd); return NoContent(); }
}
public record UpdateStatusRequest(string Status);
