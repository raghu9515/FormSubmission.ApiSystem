using FormSubmission.Application.Abstractions;
using MediatR;
namespace FormSubmission.Application.Auth;
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IJwtTokenService _jwt;
    public LoginCommandHandler(IJwtTokenService jwt) => _jwt = jwt;
    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (request.Username != "admin" || request.Password != "Admin@123") throw new UnauthorizedAccessException("Invalid username or password.");
        var token = _jwt.CreateToken("admin", "Admin");
        return Task.FromResult(new LoginResponse(token, "admin", "Admin"));
    }
}
