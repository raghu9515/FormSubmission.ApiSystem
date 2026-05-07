using FormSubmission.Application.DTOs;
using MediatR;
namespace FormSubmission.Application.Submissions.Queries;
public record GetSubmissionByIdQuery(Guid Id) : IRequest<SubmissionDto?>;
