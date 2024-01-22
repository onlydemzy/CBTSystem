using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CBTSystem.Entities;
using CBTSystem.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CBTSystem.Infrastructure.Authentication;
public class JwtTokenGenerator(IOptions<JwtSettings> jwtOptions) : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings=jwtOptions.Value;
    public string GeneratJwtToken(User user)
    {
         var signInCredentials=new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256
         );
         //Creating claims
         var claims=new Claim[]
         {
            new(JwtRegisteredClaimNames.Sub,user.Id.ToString()!),
            new(JwtRegisteredClaimNames.FamilyName,user.FullName),
            new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            
            new("Role",user.UserRole)
         };
         var securityToken=new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            claims:claims,
            expires:DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials:signInCredentials
         );
         return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}