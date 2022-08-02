using Biblioteca_web.Core.Enumeraciones;

namespace Biblioteca_web.Core.Entities
{
    public class Seguridad : EntidadBase
    {
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public TipoRol Rol { get; set; }
    }
}
