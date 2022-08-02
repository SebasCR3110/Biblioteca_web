using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Biblioteca_web.Infraestructura.Repositorios
{
    public class SeguridadRepositorio : RepositorioBase<Seguridad>, ISeguridadRepositorio
    {
        public SeguridadRepositorio(BIBLIOTECAContext context) : base(context)
        {

        }

        public async Task<Seguridad> GetLoginPorCredenciales(UsuarioLogin login)
        {
            return await _Entidades.FirstOrDefaultAsync(x => x.Usuario == login.Usuario);
        }
    }
}
