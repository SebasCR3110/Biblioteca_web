namespace Biblioteca_web.Core.DTOs
{
    public class LibroDto
    {
        /// <summary>
        /// Autogenera un id por la entidad libro
        /// </summary>
        public int Id { get; set; }
        public string TituloLibro { get; set; }
        public string EditorialLibro { get; set; }
        public string AreaLibro { get; set; }
    }
}
