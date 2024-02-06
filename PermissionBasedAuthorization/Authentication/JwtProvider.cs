using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PermissionBasedAuthorization.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string Generate(User user)
        {
            var permissions = new List<string>()
            {
                Permissions.Cards.Create,
                Permissions.Cards.List
            };
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };
            foreach (var item in permissions)
            {
                claims.Add(new Claim(CustomClaims.Permissions, item));
            }
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_options.Issuer,
                                             _options.Audience,
                                             claims,
                                             null,
                                             DateTime.UtcNow.AddHours(1),
                                             signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);
            return tokenValue;
        }
    }
}
