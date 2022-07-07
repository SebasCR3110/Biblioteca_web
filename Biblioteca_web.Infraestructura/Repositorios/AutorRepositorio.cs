using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_web.Infraestructura.Repositorios
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly BIBLIOTECAContext _context;
        public AutorRepositorio(BIBLIOTECAContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autores>> GetAutores() 
        {
            var autors = await _context.Autores.ToListAsync();

            return autors;
        
        }

       
    }
}
