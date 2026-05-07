using MediatR;
namespace FormSubmission.Application.Submissions.Commands;
public record CreateSubmissionCommand(string FullName, string Email, string Message) : IRequest<Guid>;
