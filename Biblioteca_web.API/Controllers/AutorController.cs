using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Biblioteca_web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepositorio _autorRepositorio;
        public AutorController(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutor()
        {
            var autor = await _autorRepositorio.GetAutores();
            return Ok(autor);
        
        }
    }
}
