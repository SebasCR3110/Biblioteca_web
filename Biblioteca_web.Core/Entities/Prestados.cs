using System;

#nullable disable

namespace Biblioteca_web.Core.Entities
{
    public partial class Prestados : EntidadBase
    {
        public int IdEstudiante { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string Devuelto { get; set; }

        public virtual Estudiantes IdEstudianteNavigation { get; set; }
        public virtual Libros IdLibroNavigation { get; set; }
    }
}
