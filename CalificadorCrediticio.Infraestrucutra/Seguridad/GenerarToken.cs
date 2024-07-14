using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CalificadorCrediticio.Dominio.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CalificadorCrediticio.Infraestructura.Seguridad
{
	public class GenerarToken: IGenerarToken
    {
		private readonly IConfiguration Config;

		public GenerarToken(IConfiguration Config)
		{
			this.Config = Config;

        }

		public string Generar(string usuario)	
		{
			var key = Config["Seguridad:key"];
			var issuer = Config["Seguridad:issuer"];
			var expireTime = Config["Seguridad:expiresin"];

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var permClaims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim("cliente", usuario),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User")
            };

            DateTime ExpireTime = DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime));

			var token = new JwtSecurityToken(
                issuer,
                issuer,
				permClaims,
				expires: ExpireTime,
				signingCredentials: credentials
            );


			return	new JwtSecurityTokenHandler()
								.WriteToken(token);

        }
	}
}

