using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ru_pert0_back.api.DTO;
using ru_pert0_back.api.Models;

namespace ru_pert0_back.api.Customs;

public class Utils(IConfiguration configuration)
{
    public string EncriptToken(string token)
    {
        using var sha256Hash = SHA256.Create();
        {
            var bytes = Encoding.UTF8.GetBytes(token);
            var builder = new StringBuilder();
            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public string GenerateToken(User user)
    {
        var userClaim = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
        };
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
     var jwtConfig = new  JwtSecurityToken
         (claims: userClaim, 
         expires:DateTime.UtcNow.AddHours(10), 
         signingCredentials: credentials
         );
        return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
    }
    
}
