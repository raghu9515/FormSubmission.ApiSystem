namespace FormSubmission.Application.DTOs;
public record SubmissionDto(Guid Id, string FullName, string Email, string Message, string Status, DateTime CreatedAtUtc, DateTime? UpdatedAtUtc);
