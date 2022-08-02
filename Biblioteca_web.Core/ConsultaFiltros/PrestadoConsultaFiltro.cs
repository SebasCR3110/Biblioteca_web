using System;

namespace Biblioteca_web.Core.ConsultaFiltros
{
    public class PrestadoConsultaFiltro
    {
        public int? IdEstudiante { get; set; }
        public int? IdLibro { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Devuelto { get; set; }

        public DateTime? FechaPrestamoDesde { get; set; }
        public DateTime? FechaPrestamoHasta { get; set; }

        public int TamanoPagina { get; set; }

        public int NumeroPagina { get; set; }
    }
}
