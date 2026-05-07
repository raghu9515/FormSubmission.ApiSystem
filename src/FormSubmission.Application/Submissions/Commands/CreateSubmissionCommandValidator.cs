using FluentValidation;
namespace FormSubmission.Application.Submissions.Commands;
public class CreateSubmissionCommandValidator : AbstractValidator<CreateSubmissionCommand>
{
    public CreateSubmissionCommandValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(150);
        RuleFor(x => x.Message).NotEmpty().MinimumLength(5).MaximumLength(1000);
    }
}
