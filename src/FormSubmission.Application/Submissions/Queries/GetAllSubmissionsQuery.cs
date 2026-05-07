using FormSubmission.Application.DTOs;
using MediatR;
namespace FormSubmission.Application.Submissions.Queries;
public record GetAllSubmissionsQuery(string? Status) : IRequest<IReadOnlyList<SubmissionDto>>;
