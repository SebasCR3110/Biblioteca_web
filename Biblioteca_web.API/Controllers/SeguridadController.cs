using AutoMapper;
using Biblioteca_web.API.Repuestas;
using Biblioteca_web.Core.DTOs;
using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Enumeraciones;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Biblioteca_web.API.Controllers
{
    [Authorize(Roles = nameof(TipoRol.Administrador))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly IServicioSeguridad _servicioSeguridad;
        private readonly IMapper _mapper;
        private readonly IServicioContrasena _servicioContrasena;
        public SeguridadController(IServicioSeguridad servicioSeguridad, IMapper mapper, IServicioContrasena servicioContrasena)
        {
            _servicioSeguridad = servicioSeguridad;
            _mapper = mapper;
            _servicioContrasena = servicioContrasena;
        }

        
        [HttpPost]
        public async Task<IActionResult> Seguridad(SeguridadDto seguridadDto)
        {
            var seguridad = _mapper.Map<Seguridad>(seguridadDto);

            seguridad.Contrasena = _servicioContrasena.Hash(seguridad.Contrasena);
            await _servicioSeguridad.RegistrarUsuario(seguridad);

            seguridadDto = _mapper.Map<SeguridadDto>(seguridad);
            var respuesta = new ApiRespuesta<SeguridadDto>(seguridadDto);
            return Ok(respuesta);

        }
    }
}
