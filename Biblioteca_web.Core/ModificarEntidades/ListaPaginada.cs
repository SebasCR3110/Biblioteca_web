using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca_web.Core.ModificarEntidades
{
    public class ListaPaginada<T> : List<T>
    {
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanoPaginas { get; set; }
        public int TotalRegistros { get; set; }

        public bool HayPaginaAnterior => PaginaActual > 1;
        public bool HayPaginaSiguiente => PaginaActual < TotalPaginas;
        public int? NumeroSiguientePagina => HayPaginaSiguiente ? PaginaActual + 1 : (int?)null;
        public int? NumeroPaginaAnteriror => HayPaginaAnterior ? PaginaActual - 1 : (int?)null;

        public ListaPaginada(List<T> items, int cantidad, int numeroPagina, int tamanoPagina)
        {
            TotalRegistros = cantidad;
            TamanoPaginas = tamanoPagina;
            PaginaActual = numeroPagina;
            TotalPaginas = (int)Math.Ceiling(cantidad / (double)tamanoPagina);

            AddRange(items);
        }

        public static ListaPaginada<T> Crear(IEnumerable<T> origen, int numeroPagina, int tamanoPagina)
        {
            var cantidad = origen.Count();
            var items = origen.Skip((numeroPagina - 1) * tamanoPagina).Take(tamanoPagina).ToList();

            return new ListaPaginada<T>(items, cantidad, numeroPagina, tamanoPagina);
        }
    }
}
