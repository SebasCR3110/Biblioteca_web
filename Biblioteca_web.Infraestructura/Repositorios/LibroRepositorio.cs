using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Data;

namespace Biblioteca_web.Infraestructura.Repositorios
{
    public class LibroRepositorio : RepositorioBase<Libros>, ILibroRepositorio
    {
        public LibroRepositorio(BIBLIOTECAContext context) : base(context)
        {

        }
    }
}
