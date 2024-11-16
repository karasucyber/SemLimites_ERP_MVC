using Microsoft.IdentityModel.Tokens;
using MVC.models;
using MVC.settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVC.services
{
    public class TokenService
    {

        public static string CriarToken(User usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var criptoKey = Encoding.ASCII.GetBytes(JWTConfig.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, usuario.id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.name)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(criptoKey), SecurityAlgorithms.HmacSha256Signature),

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);



        }
    }
}