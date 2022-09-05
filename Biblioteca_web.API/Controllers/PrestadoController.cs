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
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadoController : ControllerBase
    {
        private readonly IServicioPrestado _servicioPrestado;
        private readonly IMapper _mapper;
        private readonly IServicioUri _servicioUri;
        public PrestadoController(IServicioPrestado servicioPrestado, IMapper mapper, IServicioUri servicioUri)
        {
            _servicioPrestado = servicioPrestado;
            _mapper = mapper;
            _servicioUri = servicioUri;
        }


        /// <summary>
        /// Retorna todos los prestados 
        /// </summary>
        /// <param name="filtro">Filtros para aplicar</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPrestados))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiRespuesta<IEnumerable<PrestadoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiRespuesta<IEnumerable<PrestadoDto>>))]
        public IActionResult GetPrestados([FromQuery]PrestadoConsultaFiltro filtro)
        {
            var prestados = _servicioPrestado.GetPrestados(filtro);
            var prestadosDtos = _mapper.Map<IEnumerable<PrestadoDto>>(prestados);

            var metadato = new Metadato
            {
                TotalRegistros = prestados.TotalRegistros,
                TamanoPaginas = prestados.TamanoPaginas,
                PaginaActual = prestados.PaginaActual,
                TotalPaginas = prestados.TotalPaginas,
                HayPaginaSiguiente = prestados.HayPaginaSiguiente,
                HayPaginaAnterior = prestados.HayPaginaAnterior
                /*PaginaSiguienteUrl = _servicioUri.GetPaginacionPrestadoUri(filtro, Url.RouteUrl(nameof(GetPrestados))).ToString(),
                PaginaAnteriorUrl = _servicioUri.GetPaginacionPrestadoUri(filtro, Url.RouteUrl(nameof(GetPrestados))).ToString()*/
            };

            var respuesta = new ApiRespuesta<IEnumerable<PrestadoDto>>(prestadosDtos)
            {
                Meta = metadato
            };

            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadato));

            return Ok(respuesta);

        }

        /// <summary>
        /// Retorna los prestados por el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrestado(int id)
        {
            var prestado = await _servicioPrestado.GetPrestado(id);
            var prestadoDto = _mapper.Map<PrestadoDto>(prestado);
            var respuesta = new ApiRespuesta<PrestadoDto>(prestadoDto);
            return Ok(respuesta);

        }

        /// <summary>
        /// Inserta prestados
        /// </summary>
        /// <param name="prestadoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Prestado(PrestadoDto prestadoDto)
        {
            var prestado = _mapper.Map<Prestados>(prestadoDto);

            await _servicioPrestado.InsertarPrestado(prestado);

            prestadoDto = _mapper.Map<PrestadoDto>(prestado);
            var respuesta = new ApiRespuesta<PrestadoDto>(prestadoDto);
            return Ok(respuesta);

        }

        /// <summary>
        /// Actualiza prestados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prestadoDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PrestadoPut(int id, PrestadoDto prestadoDto)
        {
            var prestado = _mapper.Map<Prestados>(prestadoDto);
            prestado.Id = id;

            var resultado = await _servicioPrestado.ActualizarPrestado(prestado);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);

        }

        /// <summary>
        /// Elimina prestados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> PrestadoDelete(int id)
        {
            var resultado = await _servicioPrestado.EliminarPrestado(id);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);

        }
        

    }
}
