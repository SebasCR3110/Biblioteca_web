using Biblioteca_web.Core.Enumeraciones;

namespace Biblioteca_web.Core.DTOs
{
    /// <summary>
    /// Autogenera un id por la entidad seguridad
    /// </summary>
    public class SeguridadDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public TipoRol? Rol { get; set; }
    }
}
