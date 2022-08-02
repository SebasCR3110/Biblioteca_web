using Biblioteca_web.Core.ConsultaFiltros;
using Biblioteca_web.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_web.Infraestructura.Servicios
{
    public class ServicioUri : IServicioUri
    {
        private readonly string _baseUri;
        public ServicioUri(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPaginacionEstudianteUri(EstudianteConsultaFiltro filtro, string accionUri)
        {
            string baseUrl = $"{_baseUri}{accionUri}";
            return new Uri(baseUrl);
        }

        public Uri GetPaginacionLibroUri(LibroConsultaFiltro filtro, string accionUri)
        {
            string baseUrl = $"{_baseUri}{accionUri}";
            return new Uri(baseUrl);
        }

        public Uri GetPaginacionPrestadoUri(PrestadoConsultaFiltro filtros, string accionUri)
        {
            string baseUrl = $"{_baseUri}{accionUri}";
            return new Uri(baseUrl);
        }


    }
}
