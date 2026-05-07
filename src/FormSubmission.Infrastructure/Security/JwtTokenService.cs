using FormSubmission.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace FormSubmission.Infrastructure.Security;
public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    public JwtTokenService(IConfiguration configuration) => _configuration = configuration;
    public string CreateToken(string username, string role)
    {
        var key = _configuration["Jwt:Key"] ?? "THIS_IS_A_DEMO_SECRET_KEY_CHANGE_IN_PRODUCTION_123456";
        var issuer = _configuration["Jwt:Issuer"] ?? "FormSubmission.Api";
        var audience = _configuration["Jwt:Audience"] ?? "FormSubmission.Clients";
        var claims = new[] { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Role, role) };
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.UtcNow.AddHours(2), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
