using Biblioteca_web.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface IRepositorio<T> where T : EntidadBase
    {
        IEnumerable<T> GetTodos();
        Task<T> GetById(int id);
        Task Insertar(T entity);
        void Actualizar(T entity);
        Task Eliminar(int id);
    }
}
