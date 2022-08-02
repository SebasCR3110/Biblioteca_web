using Biblioteca_web.Core.ModificarEntidades;

namespace Biblioteca_web.API.Repuestas
{
    public class ApiRespuesta<T>
    {
        public ApiRespuesta(T dato)
        {
            Dato = dato;
        }

        public T Dato { get; set; }

        public Metadato Meta { get; set; }
    }
}
