using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Interfaces;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Servicios
{

    public class ServicioSeguridad : IServicioSeguridad
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ServicioSeguridad(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;

        }

        public async Task<Seguridad> GetLoginPorCredenciales(UsuarioLogin usuarioLogin)
        {
            return await _unidadDeTrabajo.SeguridadRepositorio.GetLoginPorCredenciales(usuarioLogin);
        }

        public async Task RegistrarUsuario(Seguridad seguridad)
        {
            await _unidadDeTrabajo.SeguridadRepositorio.Insertar(seguridad);
            await _unidadDeTrabajo.SaveChangesAsync();
        }
    }
}
