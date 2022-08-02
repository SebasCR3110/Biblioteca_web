namespace Biblioteca_web.Core.ModificarEntidades
{
    public class Metadato
    {
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanoPaginas { get; set; }
        public int TotalRegistros { get; set; }
        public bool HayPaginaAnterior { get; set; }
        public bool HayPaginaSiguiente { get; set; }
        /*public string PaginaSiguienteUrl { get; set; }
        public string PaginaAnteriorUrl { get; set; }*/
    }
}
