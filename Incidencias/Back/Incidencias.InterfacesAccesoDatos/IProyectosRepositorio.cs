using Incidencias.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.Interfaces.AccesoDatos
{
    public interface IProyectosRepositorio : IRepositorioGenerico<Proyecto>
    {
        Task<Proyecto> ObtenerPorNombre(string nombre);
        Task<IEnumerable<Proyecto>> ObtenerTodosConDetalle();
        Task<Proyecto> ObtenerConDetallesPorId(int id);
    }
}
