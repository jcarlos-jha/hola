using Microsoft.IdentityModel.Tokens;
using pruebaTecnica1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pruebaTecnica1.Encript
{
    public class JwtHelper
    {
        private readonly IConfiguration _config;

        public JwtHelper(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            string rol = "";
            if (usuario.RolId == 1)
            {
                rol = "Admin";
            }
            else {
                rol = "Usuario";
            }
                var claims = new[]
                {
            new Claim("Usuario", usuario.NombreUsuario.ToString()),
            new Claim("Email", usuario.Email),
            new Claim("Roles", rol)
        };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
