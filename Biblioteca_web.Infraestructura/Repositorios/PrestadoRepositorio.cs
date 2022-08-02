using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Infraestructura.Repositorios
{
    public class PrestadoRepositorio : RepositorioBase<Prestados>, IPrestadoRepositorio
    {
        public PrestadoRepositorio(BIBLIOTECAContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Prestados>> GetPrestadoByEstudiante(int idEstudiante)
        {
            return await _Entidades.Where(x => x.IdEstudiante == idEstudiante).ToListAsync();
        }

        public async Task<IEnumerable<Prestados>> GetPrestadoByLibro(int idLibro)
        {
            return await _Entidades.Where(x => x.IdLibro == idLibro).ToListAsync();
        }
    }
}
