using FormSubmission.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace FormSubmission.Application.Abstractions;
public interface IApplicationDbContext
{
    DbSet<Submission> Submissions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
