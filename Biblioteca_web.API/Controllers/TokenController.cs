using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServicioSeguridad _servicioSeguridad;
        private readonly IConfiguration _configuration;
        private readonly IServicioContrasena _servicioContrasena;
        public TokenController(IConfiguration configuration, IServicioSeguridad servicioSeguridad, IServicioContrasena servicioContrasena)
        {
            _configuration = configuration;
            _servicioSeguridad = servicioSeguridad;
            _servicioContrasena = servicioContrasena;
        }

        [HttpPost]
        public async Task<IActionResult> Autenticacion(UsuarioLogin login)
        {
            //Si es un usuario valido
            var validacion = await EsUsuarioValido(login);
            if(validacion.Item1)
            {
                var token = GenerarToken(validacion.Item2);
                return Ok(new { token = token});
            }

            return NotFound();
        }
        private async Task<(bool, Seguridad)> EsUsuarioValido(UsuarioLogin login)
        {
            var usuario = await _servicioSeguridad.GetLoginPorCredenciales(login);
            var esValido = _servicioContrasena.Verificar(usuario.Contrasena, login.Contrasena);
            return (esValido, usuario);
        }

        private string GenerarToken(Seguridad seguridad)
        {
            //Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var firmaCredenciales = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(firmaCredenciales);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, seguridad.NombreUsuario),
                new Claim("Usuario", seguridad.Usuario),
                new Claim(ClaimTypes.Role, seguridad.Rol.ToString())
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(20)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
