using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DevFreela.Infra.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(string email, string role)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new("userName", email),
            new("role", role)
        };

        var token = new JwtSecurityToken(issuer,
            audience,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials,
            claims: claims
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    public string ComputeSha256Hash(string password)
    {
        var builder = new StringBuilder();
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        foreach (var t in bytes) builder.Append(t.ToString("x2"));

        return builder.ToString();
    }
}