using Biblioteca_web.Core.ConsultaFiltros;
using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Excepciones;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Core.ModificarEntidades;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Servicios
{
    public class ServicioPrestado : IServicioPrestado
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly OpcionesPaginacion _opcionesPaginacion;

        public ServicioPrestado(IUnidadDeTrabajo unidadDeTrabajo, IOptions<OpcionesPaginacion> opciones)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _opcionesPaginacion = opciones.Value;
        }

        public ListaPaginada<Prestados> GetPrestados(PrestadoConsultaFiltro filtro)
        {
            filtro.NumeroPagina = filtro.NumeroPagina == 0 ? _opcionesPaginacion.DefaultNumeroPagina : filtro.NumeroPagina;
            filtro.TamanoPagina = filtro.TamanoPagina == 0 ? _opcionesPaginacion.DefaultTamanoPagina : filtro.TamanoPagina;

            var prestados = _unidadDeTrabajo.PrestadoRepositorio.GetTodos();
            
            if(filtro.IdEstudiante != null)
            {
                prestados = prestados.Where(x => x.IdEstudiante == filtro.IdEstudiante);
            }

            if (filtro.IdLibro != null)
            {
                prestados = prestados.Where(x => x.IdLibro == filtro.IdLibro);
            }

            if (filtro.FechaPrestamo != null)
            {
                prestados = prestados.Where(x => x.FechaPrestamo.ToShortDateString() == filtro.FechaPrestamo?.ToShortDateString());
            }

            if (filtro.FechaDevolucion != null)
            {
                prestados = prestados.Where(x => x.FechaDevolucion.ToShortDateString() == filtro.FechaDevolucion?.ToShortDateString());
            }

            if (filtro.Devuelto != null)
            {
                prestados = prestados.Where(x => x.Devuelto.ToUpper().Contains(filtro.Devuelto.ToUpper()));
            }

            if (filtro.FechaPrestamoDesde != null && filtro.FechaPrestamoHasta != null)
            {
                var fechaHasta = Convert.ToDateTime(filtro.FechaPrestamoHasta?.ToShortDateString());
                var fechaDesde = Convert.ToDateTime(filtro.FechaPrestamoDesde?.ToShortDateString());
                prestados = prestados.OrderByDescending(x => x.FechaPrestamo.ToShortDateString()).Where(x => x.FechaPrestamo >= fechaDesde && x.FechaPrestamo <= fechaHasta);
            }


            var prestadosPaginados = ListaPaginada<Prestados>.Crear(prestados, filtro.NumeroPagina, filtro.TamanoPagina);

            return prestadosPaginados; 
        }

        public async Task<Prestados> GetPrestado(int id)
        {
            return await _unidadDeTrabajo.PrestadoRepositorio.GetById(id);
        }

        public async Task InsertarPrestado(Prestados prestado)
        {
            var estudiante = await _unidadDeTrabajo.EstudianteRepositorio.GetById(prestado.IdEstudiante);
            var libro = await _unidadDeTrabajo.LibroRepositorio.GetById(prestado.IdLibro);

            if (estudiante == null)
            {
                throw new ExcepcionNegocio("El estudiante no existe");
            }
            if (libro == null)
            {
                throw new ExcepcionNegocio("El libro no existe");
            }


            var libroPrestado = await _unidadDeTrabajo.PrestadoRepositorio.GetPrestadoByLibro(prestado.IdLibro);
            var librosPrestados = libroPrestado.Count();

            if (librosPrestados >= 1)
            {
                throw new ExcepcionNegocio("El Libro se encuentra en prestamo actualmente");
            }


            var estudiantePrestado = await _unidadDeTrabajo.PrestadoRepositorio.GetPrestadoByEstudiante(prestado.IdEstudiante);
            var estudianteDevuelto = estudiantePrestado.Count(x => x.Devuelto.ToUpper().Equals("NO"));

            if (estudianteDevuelto >= 3)
            {
                throw new ExcepcionNegocio("El estudiante actual tiene 3 libros que no ha devuelto");
            }

            await _unidadDeTrabajo.PrestadoRepositorio.Insertar(prestado);
            await _unidadDeTrabajo.SaveChangesAsync();
        }

        public async Task<bool> ActualizarPrestado(Prestados prestado)
        {
            var estudiante = _unidadDeTrabajo.EstudianteRepositorio.GetById(prestado.IdEstudiante);
            var libro = _unidadDeTrabajo.LibroRepositorio.GetById(prestado.IdLibro);

            if (estudiante == null)
            {
                throw new ExcepcionNegocio("El estudiante no existe");
            }
            if (libro == null)
            {
                throw new ExcepcionNegocio("El libro no existe");
            }

            var libroPrestado = await _unidadDeTrabajo.PrestadoRepositorio.GetPrestadoByLibro(prestado.IdLibro);
            var librosPrestados = libroPrestado.Count();

            if (librosPrestados >= 1)
            {
                throw new ExcepcionNegocio("El Libro se encuentra en prestamo actualmente");
            }

            _unidadDeTrabajo.PrestadoRepositorio.Actualizar(prestado);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarPrestado(int id)
        {
            var prestado = await _unidadDeTrabajo.PrestadoRepositorio.GetById(id);

            if (prestado == null)
            {
                throw new ExcepcionNegocio("El prestamo no existe");
            }

            await _unidadDeTrabajo.PrestadoRepositorio.Eliminar(id);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }



    }
}
