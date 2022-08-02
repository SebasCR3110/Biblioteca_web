using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Data;
using System.Threading.Tasks;

namespace Biblioteca_web.Infraestructura.Repositorios
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly BIBLIOTECAContext _context;
        private readonly IPrestadoRepositorio _prestadoRepositorio;
        private readonly IEstudianteRepositorio _estudianteRepositorio;
        private readonly ILibroRepositorio _libroRepositorio;
        private readonly ISeguridadRepositorio _seguridadRepositorio;

        public UnidadDeTrabajo(BIBLIOTECAContext context)
        {
            _context = context;
        }

        public IPrestadoRepositorio PrestadoRepositorio => _prestadoRepositorio ?? new PrestadoRepositorio(_context);

        public IEstudianteRepositorio EstudianteRepositorio => _estudianteRepositorio ?? new EstudianteRepositorio(_context);

        public ILibroRepositorio LibroRepositorio => _libroRepositorio ?? new LibroRepositorio(_context);

        public ISeguridadRepositorio SeguridadRepositorio => _seguridadRepositorio ?? new SeguridadRepositorio(_context);

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
