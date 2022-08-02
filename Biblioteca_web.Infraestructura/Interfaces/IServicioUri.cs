using Biblioteca_web.Core.ConsultaFiltros;
using System;

namespace Biblioteca_web.Infraestructura.Interfaces
{
    public interface IServicioUri
    {
        Uri GetPaginacionPrestadoUri(PrestadoConsultaFiltro filtro, string accionUri);

        Uri GetPaginacionEstudianteUri(EstudianteConsultaFiltro filtro, string accionUri);

        Uri GetPaginacionLibroUri(LibroConsultaFiltro filtro, string accionUri);
    }
}