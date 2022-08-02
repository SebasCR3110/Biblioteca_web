using System;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IPrestadoRepositorio PrestadoRepositorio { get; }

        IEstudianteRepositorio EstudianteRepositorio { get; }

        ILibroRepositorio LibroRepositorio { get; }

        ISeguridadRepositorio SeguridadRepositorio { get; }

        void SaveChanges();

        Task SaveChangesAsync();

    }
}
