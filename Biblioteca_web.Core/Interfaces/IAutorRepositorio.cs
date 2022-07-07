using Biblioteca_web.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface IAutorRepositorio 
    {
        Task<IEnumerable<Autores>> GetAutores();
    }
}
