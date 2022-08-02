using System;

namespace Biblioteca_web.Core.Excepciones
{
    public class ExcepcionNegocio : Exception
    {
        public ExcepcionNegocio()
        {

        }

        public ExcepcionNegocio(string mensaje) : base(mensaje)
        {

        }
    }
}
