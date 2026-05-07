using FluentValidation;
using FormSubmission.Domain.Entities;
namespace FormSubmission.Application.Submissions.Commands;
public class UpdateSubmissionStatusCommandValidator : AbstractValidator<UpdateSubmissionStatusCommand>
{
    public UpdateSubmissionStatusCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Status).Must(x => SubmissionStatus.All.Contains(x)).WithMessage("Invalid status.");
    }
}
