using Incidencias.Interface.LogicaDeNegocio;
using Incidencias.Interfaces;
using Incidencias.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.Interfaces.LogicaDeNegocio
{
    public interface IProyectosLogica : Ilogica<Proyecto>
    {
        Task<Proyecto> ObtenerPorNombre(string nombre);
        Task<IEnumerable<Proyecto>> ObtenerTodosConDetalle();
        Task<Proyecto> ObtenerConDetallesPorId(int id);
    }
}
