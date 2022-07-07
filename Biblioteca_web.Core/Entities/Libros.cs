using System;
using System.Collections.Generic;

#nullable disable

namespace Biblioteca_web.Core.Entities
{
    public partial class Libros
    {
        public Libros()
        {
            Prestados = new HashSet<Prestados>();
        }

        public int IdLibro { get; set; }
        public string TituloLibro { get; set; }
        public string EditorialLibro { get; set; }
        public string AreaLibro { get; set; }

        public virtual ICollection<Prestados> Prestados { get; set; }
    }
}
