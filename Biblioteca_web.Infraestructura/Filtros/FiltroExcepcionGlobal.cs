using Biblioteca_web.Core.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Biblioteca_web.Infraestructura.Filtros
{
    public class FiltroExcepcionGlobal : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType() == typeof(ExcepcionNegocio))
            {
                var excepcion = (ExcepcionNegocio)context.Exception;
                var validacion = new
                {
                    Estado = 400,
                    Titulo = "Solicitud Invalida",
                    Detalle = excepcion.Message
                };

                var json = new
                {
                    errores = new[] { validacion }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
