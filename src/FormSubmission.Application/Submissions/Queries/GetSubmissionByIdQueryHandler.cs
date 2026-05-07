using FormSubmission.Application.Abstractions;
using FormSubmission.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace FormSubmission.Application.Submissions.Queries;
public class GetSubmissionByIdQueryHandler : IRequestHandler<GetSubmissionByIdQuery, SubmissionDto?>
{
    private readonly IApplicationDbContext _db;
    public GetSubmissionByIdQueryHandler(IApplicationDbContext db) => _db = db;
    public async Task<SubmissionDto?> Handle(GetSubmissionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _db.Submissions.AsNoTracking().Where(x => x.Id == request.Id)
            .Select(x => new SubmissionDto(x.Id, x.FullName, x.Email, x.Message, x.Status, x.CreatedAtUtc, x.UpdatedAtUtc))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
