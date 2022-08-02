using Biblioteca_web.Core.ConsultaFiltros;
using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.ModificarEntidades;
using System.Threading.Tasks;

namespace Biblioteca_web.Core.Interfaces
{
    public interface IServicioPrestado
    {
        ListaPaginada<Prestados> GetPrestados(PrestadoConsultaFiltro filtro);
         
        Task<Prestados> GetPrestado(int id);

        Task InsertarPrestado(Prestados prestado);

        Task<bool> ActualizarPrestado(Prestados prestado);

        Task<bool> EliminarPrestado(int id);
    }
}