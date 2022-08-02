using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Infraestructura.Repositorios
{
    public class RepositorioBase<T> : IRepositorio<T> where T : EntidadBase
    {
        private readonly BIBLIOTECAContext _context;
        protected readonly DbSet<T> _Entidades;
        public RepositorioBase(BIBLIOTECAContext context)
        {
            _context = context;
            _Entidades = context.Set<T>();
        }

        public IEnumerable<T> GetTodos()
        {
            return  _Entidades.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _Entidades.FindAsync(id);
        }

        public async Task Insertar(T entity)
        {
            await _Entidades.AddAsync(entity);
        }

        public void Actualizar(T entity)
        {
            _Entidades.Update(entity);
        }

        public async Task Eliminar(int id)
        {
            T entity = await GetById(id);
            _Entidades.Remove(entity);
        }

    }
}
