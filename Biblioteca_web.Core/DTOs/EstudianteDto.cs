namespace Biblioteca_web.Core.DTOs
{
    public class EstudianteDto
    {
        /// <summary>
        /// Autogenera un id por la entidad estudiante
        /// </summary>
        public int Id { get; set; }
        public string CedulaIdentidad { get; set; }
        public string NombreEstudiante { get; set; }
        public int? EdadEstudiante { get; set; }
        public string DireccionEstudiante { get; set; }
        public string CarreraEstudiante { get; set; }
    }
}
