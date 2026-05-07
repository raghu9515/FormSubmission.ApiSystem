using FormSubmission.Application.Abstractions;
using FormSubmission.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace FormSubmission.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Submission> Submissions => Set<Submission>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Submission>(b =>
        {
            b.HasKey(x => x.Id); b.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            b.Property(x => x.Email).HasMaxLength(150).IsRequired(); b.Property(x => x.Message).HasMaxLength(1000).IsRequired();
            b.Property(x => x.Status).HasMaxLength(30).IsRequired(); b.HasIndex(x => x.Email); b.HasIndex(x => x.Status); b.HasIndex(x => x.CreatedAtUtc);
        });
    }
}
