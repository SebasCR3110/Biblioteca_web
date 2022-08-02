using System;

namespace Biblioteca_web.Core.DTOs
{
    /// <summary>
    /// Autogenera un id por la entidad prestado
    /// </summary>
    public class PrestadoDto
    {
        public int Id { get; set; }
        public int? IdEstudiante { get; set; }
        public int? IdLibro { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Devuelto { get; set; }
    }
}
