using Biblioteca_web.Core.ConsultaFiltros;
using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.ModificarEntidades;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface IServicioLibro
    {
        ListaPaginada<Libros> GetLibros(LibroConsultaFiltro filtro);

        Task<Libros> GetLibro(int id);

        Task InsertarLibro(Libros libro);

        Task<bool> ActualizarLibro(Libros libro);

        Task<bool> EliminarLibro(int id);
    }
}
