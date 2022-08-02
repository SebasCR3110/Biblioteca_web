using Biblioteca_web.Core.ConsultaFiltros;
using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.ModificarEntidades;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface IServicioEstudiante
    {
        ListaPaginada<Estudiantes> GetEstudiantes(EstudianteConsultaFiltro filtro);

        Task<Estudiantes> GetEstudiante(int id);

        Task InsertarEstudiante(Estudiantes estudiante);

        Task<bool> ActualizarEstudiante(Estudiantes estudiante);

        Task<bool> EliminarEstudiante(int id);
    }
}
