using Incidencias.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.InterfacesLogicaDeNegocio
{
    public interface IProyectosLogica : Ilogica<Proyecto>
    {
        Task<Proyecto> ObtenerPorNombre(string nombre);
        Task<IEnumerable<Proyecto>> ObtenerTodosConDetalle();
        Task<Proyecto> ObtenerConIncidenciasPorId(int id);
        Task<Proyecto> ObtenerConTareasPorId(int id);
        Task<IEnumerable<Proyecto>> GetProyectosPorUsuario(int idUsuario);
        Task<decimal> GetCostoPorProyecto(int idProyecto);
    }
}
