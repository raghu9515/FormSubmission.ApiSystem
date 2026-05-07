using FormSubmission.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace FormSubmission.Application.Submissions.Commands;
public class UpdateSubmissionStatusCommandHandler : IRequestHandler<UpdateSubmissionStatusCommand>
{
    private readonly IApplicationDbContext _db;
    public UpdateSubmissionStatusCommandHandler(IApplicationDbContext db) => _db = db;
    public async Task Handle(UpdateSubmissionStatusCommand request, CancellationToken cancellationToken)
    {
        var submission = await _db.Submissions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (submission is null) throw new KeyNotFoundException("Submission not found.");
        submission.UpdateStatus(request.Status);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
