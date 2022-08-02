using Biblioteca_web.Core.Entities;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface IServicioSeguridad
    {
        Task<Seguridad> GetLoginPorCredenciales(UsuarioLogin usuarioLogin);
        Task RegistrarUsuario(Seguridad seguridad);
    }
}