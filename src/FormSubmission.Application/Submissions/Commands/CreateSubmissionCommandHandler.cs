using FormSubmission.Application.Abstractions;
using FormSubmission.Domain.Entities;
using MediatR;
namespace FormSubmission.Application.Submissions.Commands;
public class CreateSubmissionCommandHandler : IRequestHandler<CreateSubmissionCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateSubmissionCommandHandler(IApplicationDbContext db) => _db = db;
    public async Task<Guid> Handle(CreateSubmissionCommand request, CancellationToken cancellationToken)
    {
        var submission = new Submission(request.FullName, request.Email, request.Message);
        _db.Submissions.Add(submission);
        await _db.SaveChangesAsync(cancellationToken);
        return submission.Id;
    }
}
