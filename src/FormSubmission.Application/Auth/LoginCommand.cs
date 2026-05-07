using MediatR;
namespace FormSubmission.Application.Auth;
public record LoginCommand(string Username, string Password) : IRequest<LoginResponse>;
public record LoginResponse(string Token, string Username, string Role);
