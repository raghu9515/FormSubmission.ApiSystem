namespace FormSubmission.Domain.Entities;
public static class SubmissionStatus
{
    public const string Pending = "Pending";
    public const string InReview = "InReview";
    public const string Approved = "Approved";
    public const string Rejected = "Rejected";
    public static readonly string[] All = [Pending, InReview, Approved, Rejected];
}
