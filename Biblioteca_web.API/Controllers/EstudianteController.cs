using AutoMapper;
using Biblioteca_web.API.Repuestas;
using Biblioteca_web.Core.ConsultaFiltros;
using Biblioteca_web.Core.DTOs;
using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Core.ModificarEntidades;
using Biblioteca_web.Infraestructura.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Biblioteca_web.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        
        private readonly IServicioEstudiante _servicioEstudiante;
        private readonly IMapper _mapper;
        private readonly IServicioUri _servicioUri;
        public EstudianteController(IServicioEstudiante servicioEstudiante, IMapper mapper, IServicioUri servicioUri)
        {
            _servicioEstudiante = servicioEstudiante;
            _mapper = mapper;
            _servicioUri = servicioUri;
        }


        /// <summary>
        /// Retorna todos los estudiantes 
        /// </summary>
        /// <param name="filtro">filtro para aplicar</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetEstudiantes))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiRespuesta<IEnumerable<EstudianteDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiRespuesta<IEnumerable<EstudianteDto>>))]
        public IActionResult GetEstudiantes([FromQuery] EstudianteConsultaFiltro filtro)
        {
            var estudiantes = _servicioEstudiante.GetEstudiantes(filtro);
            var estudiantesDtos = _mapper.Map<IEnumerable<EstudianteDto>>(estudiantes);

            var metadato = new Metadato
            {
                TotalRegistros = estudiantes.TotalRegistros,
                TamanoPaginas = estudiantes.TamanoPaginas,
                PaginaActual = estudiantes.PaginaActual,
                TotalPaginas = estudiantes.TotalPaginas,
                HayPaginaSiguiente = estudiantes.HayPaginaSiguiente,
                HayPaginaAnterior = estudiantes.HayPaginaAnterior
                /*PaginaSiguienteUrl = _servicioUri.GetPaginacionEstudianteUri(filtro, Url.RouteUrl(nameof(GetEstudiantes))).ToString(),
                PaginaAnteriorUrl = _servicioUri.GetPaginacionEstudianteUri(filtro, Url.RouteUrl(nameof(GetEstudiantes))).ToString()*/
            };

            var respuesta = new ApiRespuesta<IEnumerable<EstudianteDto>>(estudiantesDtos)
            {
                Meta = metadato
            };

            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadato));

            return Ok(respuesta);

        }

        /// <summary>
        /// Retorna los estudiantes por el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudiante(int id)
        {
            var estudiante = await _servicioEstudiante.GetEstudiante(id);
            var estudianteDto = _mapper.Map<EstudianteDto>(estudiante);
            var respuesta = new ApiRespuesta<EstudianteDto>(estudianteDto);
            return Ok(respuesta);

        }

        /// <summary>
        /// Inserta estudiante
        /// </summary>
        /// <param name="estudianteDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Estudiante(EstudianteDto estudianteDto)
        {
            var estudiante = _mapper.Map<Estudiantes>(estudianteDto);

            await _servicioEstudiante.InsertarEstudiante(estudiante);

            estudianteDto = _mapper.Map<EstudianteDto>(estudiante);
            var respuesta = new ApiRespuesta<EstudianteDto>(estudianteDto);
            return Ok(respuesta);

        }

        /// <summary>
        /// Actualiza libros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estudianteDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EstudiantePut(int id, EstudianteDto estudianteDto)
        {
            var estudiante = _mapper.Map<Estudiantes>(estudianteDto);
            estudiante.Id = id;

            var resultado = await _servicioEstudiante.ActualizarEstudiante(estudiante);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);

        }

        /// <summary>
        /// Elimina estudiante
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EstudianteDelete(int id)
        {
            var resultado = await _servicioEstudiante.EliminarEstudiante(id);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);

        }
    }
}
