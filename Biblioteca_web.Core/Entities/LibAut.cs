using System;
using System.Collections.Generic;

#nullable disable

namespace Biblioteca_web.Core.Entities
{
    public partial class LibAut
    {
        public int? IdAutor { get; set; }
        public int? IdLibro { get; set; }

        public virtual Autores IdAutorNavigation { get; set; }
        public virtual Libros IdLibroNavigation { get; set; }
    }
}
