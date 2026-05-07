namespace FormSubmission.Application.Abstractions;
public interface IJwtTokenService { string CreateToken(string username, string role); }
