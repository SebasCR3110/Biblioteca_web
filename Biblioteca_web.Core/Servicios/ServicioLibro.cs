using Biblioteca_web.Core.ConsultaFiltros;
using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Excepciones;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Core.ModificarEntidades;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Servicios
{
    public class ServicioLibro : IServicioLibro
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly OpcionesPaginacion _opcionesPaginacion;

        public ServicioLibro(IUnidadDeTrabajo unidadDeTrabajo, IOptions<OpcionesPaginacion> opciones)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _opcionesPaginacion = opciones.Value;
        }

        public ListaPaginada<Libros> GetLibros(LibroConsultaFiltro filtro)
        {
            filtro.NumeroPagina = filtro.NumeroPagina == 0 ? _opcionesPaginacion.DefaultNumeroPagina : filtro.NumeroPagina;
            filtro.TamanoPagina = filtro.TamanoPagina == 0 ? _opcionesPaginacion.DefaultTamanoPagina : filtro.TamanoPagina;

            var libro = _unidadDeTrabajo.LibroRepositorio.GetTodos();

            var libroPaginados = ListaPaginada<Libros>.Crear(libro, filtro.NumeroPagina, filtro.TamanoPagina);

            return libroPaginados;
        }

        public async Task<Libros> GetLibro(int id)
        {
            return await _unidadDeTrabajo.LibroRepositorio.GetById(id);
        }

        public async Task InsertarLibro(Libros libro)
        {
            await _unidadDeTrabajo.LibroRepositorio.Insertar(libro);
            await _unidadDeTrabajo.SaveChangesAsync();
        }

        public async Task<bool> ActualizarLibro(Libros libro)
        {
            _unidadDeTrabajo.LibroRepositorio.Actualizar(libro);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarLibro(int id)
        {
            var libro = await _unidadDeTrabajo.LibroRepositorio.GetById(id);

            if (libro == null)
            {
                throw new ExcepcionNegocio("El libro no existe");
            }

            await _unidadDeTrabajo.LibroRepositorio.Eliminar(id);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }
        
    }
}
