using FormSubmission.Application.Abstractions;
using FormSubmission.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace FormSubmission.Application.Submissions.Queries;
public class GetAllSubmissionsQueryHandler : IRequestHandler<GetAllSubmissionsQuery, IReadOnlyList<SubmissionDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllSubmissionsQueryHandler(IApplicationDbContext db) => _db = db;
    public async Task<IReadOnlyList<SubmissionDto>> Handle(GetAllSubmissionsQuery request, CancellationToken cancellationToken)
    {
        var query = _db.Submissions.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(request.Status)) query = query.Where(x => x.Status == request.Status);
        return await query.OrderByDescending(x => x.CreatedAtUtc)
            .Select(x => new SubmissionDto(x.Id, x.FullName, x.Email, x.Message, x.Status, x.CreatedAtUtc, x.UpdatedAtUtc))
            .ToListAsync(cancellationToken);
    }
}
