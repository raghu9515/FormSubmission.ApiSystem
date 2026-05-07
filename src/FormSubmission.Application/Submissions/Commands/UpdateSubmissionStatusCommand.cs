using MediatR;
namespace FormSubmission.Application.Submissions.Commands;
public record UpdateSubmissionStatusCommand(Guid Id, string Status) : IRequest;
