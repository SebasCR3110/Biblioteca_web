using System.Collections.Generic;

#nullable disable

namespace Biblioteca_web.Core.Entities
{
    public partial class Estudiantes : EntidadBase
    {
        public Estudiantes()
        {
            Prestados = new HashSet<Prestados>();
        }

        public string CedulaIdentidad { get; set; }
        public string NombreEstudiante { get; set; }
        public int EdadEstudiante { get; set; }
        public string DireccionEstudiante { get; set; }
        public string CarreraEstudiante { get; set; }

        public virtual ICollection<Prestados> Prestados { get; set; }
    }
}
