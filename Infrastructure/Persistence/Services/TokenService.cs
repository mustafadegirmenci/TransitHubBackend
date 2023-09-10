using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Services;
using Domain.Constants;
using Domain.Enums;
using Microsoft.IdentityModel.Tokens;

namespace Persistence.Services;

public class TokenService : ITokenService
{
    public string GenerateToken(string seed, UserRole userRole)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.JwtSecret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("role", userRole == UserRole.Customer ? "Customer" : "Company"),
            new Claim(JwtRegisteredClaimNames.Sub, seed),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64)
        };

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Constants.JwtExpirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}