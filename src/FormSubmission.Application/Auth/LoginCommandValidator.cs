using FluentValidation;
namespace FormSubmission.Application.Auth;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator() { RuleFor(x => x.Username).NotEmpty(); RuleFor(x => x.Password).NotEmpty(); }
}
