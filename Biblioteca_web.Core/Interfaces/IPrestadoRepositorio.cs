using Biblioteca_web.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface IPrestadoRepositorio : IRepositorio<Prestados>
    {
        Task<IEnumerable<Prestados>> GetPrestadoByEstudiante(int idEstudiante);

        Task<IEnumerable<Prestados>> GetPrestadoByLibro(int idLibro);

    }
}
