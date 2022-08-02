using Biblioteca_web.Core.Entities;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface ISeguridadRepositorio : IRepositorio<Seguridad>
    {
        Task<Seguridad> GetLoginPorCredenciales(UsuarioLogin login);
    }
}