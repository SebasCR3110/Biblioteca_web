namespace Biblioteca_web.Infraestructura.Interfaces
{
    public interface IServicioContrasena
    {
        string Hash(string contrasena);

        bool Verificar(string hash, string contrasena);
    }
}
