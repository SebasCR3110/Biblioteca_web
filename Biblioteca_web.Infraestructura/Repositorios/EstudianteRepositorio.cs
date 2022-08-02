using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Data;

namespace Biblioteca_web.Infraestructura.Repositorios
{
    public class EstudianteRepositorio : RepositorioBase<Estudiantes>, IEstudianteRepositorio
    {
        public EstudianteRepositorio(BIBLIOTECAContext context) : base(context)
        {

        }
    }
}
