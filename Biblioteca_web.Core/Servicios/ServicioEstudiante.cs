using Biblioteca_web.Core.ConsultaFiltros;
using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Excepciones;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Core.ModificarEntidades;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Servicios
{
    public class ServicioEstudiante : IServicioEstudiante
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly OpcionesPaginacion _opcionesPaginacion;

        public ServicioEstudiante(IUnidadDeTrabajo unidadDeTrabajo, IOptions<OpcionesPaginacion> opciones)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _opcionesPaginacion = opciones.Value;
        }

        public ListaPaginada<Estudiantes> GetEstudiantes(EstudianteConsultaFiltro filtro)
        {
            filtro.NumeroPagina = filtro.NumeroPagina == 0 ? _opcionesPaginacion.DefaultNumeroPagina : filtro.NumeroPagina;
            filtro.TamanoPagina = filtro.TamanoPagina == 0 ? _opcionesPaginacion.DefaultTamanoPagina : filtro.TamanoPagina;

            var estudiante = _unidadDeTrabajo.EstudianteRepositorio.GetTodos();

            var estudiantePaginados = ListaPaginada<Estudiantes>.Crear(estudiante, filtro.NumeroPagina, filtro.TamanoPagina);

            return estudiantePaginados;
        }

        public async Task<Estudiantes> GetEstudiante(int id)
        {
            return await _unidadDeTrabajo.EstudianteRepositorio.GetById(id);
        }

        public async Task InsertarEstudiante(Estudiantes estudiante)
        {
            
            await _unidadDeTrabajo.EstudianteRepositorio.Insertar(estudiante);
            await _unidadDeTrabajo.SaveChangesAsync();
        }

        public async Task<bool> ActualizarEstudiante(Estudiantes estudiante)
        {
            _unidadDeTrabajo.EstudianteRepositorio.Actualizar(estudiante);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarEstudiante(int id)
        {
            var estudiante = await _unidadDeTrabajo.EstudianteRepositorio.GetById(id);

            if (estudiante == null)
            {
                throw new ExcepcionNegocio("El estudiante no existe");
            }

            await _unidadDeTrabajo.EstudianteRepositorio.Eliminar(id);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }
        
    }
}
