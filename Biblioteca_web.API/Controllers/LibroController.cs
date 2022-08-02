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
    public class LibroController : ControllerBase
    {
       
        private readonly IServicioLibro _servicioLibro;
        private readonly IMapper _mapper;
        private readonly IServicioUri _servicioUri;
        public LibroController(IServicioLibro servicioLibro, IMapper mapper, IServicioUri servicioUri)
        {
            _servicioLibro = servicioLibro;
            _mapper = mapper;
            _servicioUri = servicioUri;
        }


        /// <summary>
        /// Retorna todos los libros 
        /// </summary>
        /// <param name="filtro">filtro para aplicar</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetLibros))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiRespuesta<IEnumerable<LibroDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiRespuesta<IEnumerable<LibroDto>>))]
        public IActionResult GetLibros([FromQuery]LibroConsultaFiltro filtro)
        {
            var libros = _servicioLibro.GetLibros(filtro);
            var librosDtos = _mapper.Map<IEnumerable<LibroDto>>(libros);

            var metadato = new Metadato
            {
                TotalRegistros = libros.TotalRegistros,
                TamanoPaginas = libros.TamanoPaginas,
                PaginaActual = libros.PaginaActual,
                TotalPaginas = libros.TotalPaginas,
                HayPaginaSiguiente = libros.HayPaginaSiguiente,
                HayPaginaAnterior = libros.HayPaginaAnterior
                /*PaginaSiguienteUrl = _servicioUri.GetPaginacionLibroUri(filtro, Url.RouteUrl(nameof(GetLibros))).ToString(),
                PaginaAnteriorUrl = _servicioUri.GetPaginacionLibroUri(filtro, Url.RouteUrl(nameof(GetLibros))).ToString()*/
            };

            var respuesta = new ApiRespuesta<IEnumerable<LibroDto>>(librosDtos)
            {
                Meta = metadato
            };

            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadato));

            return Ok(respuesta);

        }

        /// <summary>
        /// Retorna los libros por el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibro(int id)
        {
            var libro = await _servicioLibro.GetLibro(id);
            var libroDto = _mapper.Map<LibroDto>(libro);
            var respuesta = new ApiRespuesta<LibroDto>(libroDto);
            return Ok(respuesta);

        }

        /// <summary>
        /// Inserta libro
        /// </summary>
        /// <param name="libroDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Libro(LibroDto libroDto)
        {
            var libro = _mapper.Map<Libros>(libroDto);

            await _servicioLibro.InsertarLibro(libro);

            libroDto = _mapper.Map<LibroDto>(libro);
            var respuesta = new ApiRespuesta<LibroDto>(libroDto);
            return Ok(respuesta);

        }

        /// <summary>
        /// Actualiza libros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libroDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> LibroPut(int id, LibroDto libroDto)
        {
            var libro = _mapper.Map<Libros>(libroDto);
            libro.Id = id;

            var resultado = await _servicioLibro.ActualizarLibro(libro);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);

        }

        /// <summary>
        /// Elimina libros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> LibroDelete(int id)
        {
            var resultado = await _servicioLibro.EliminarLibro(id);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);

        }
    }
}
