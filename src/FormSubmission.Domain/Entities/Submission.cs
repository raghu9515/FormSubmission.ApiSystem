namespace FormSubmission.Domain.Entities;
public class Submission
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Message { get; private set; } = string.Empty;
    public string Status { get; private set; } = SubmissionStatus.Pending;
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; private set; }
    private Submission() { }
    public Submission(string fullName, string email, string message)
    {
        FullName = fullName.Trim(); Email = email.Trim().ToLowerInvariant(); Message = message.Trim();
    }
    public void UpdateStatus(string status)
    {
        if (!SubmissionStatus.All.Contains(status)) throw new InvalidOperationException($"Invalid status: {status}");
        Status = status; UpdatedAtUtc = DateTime.UtcNow;
    }
}
