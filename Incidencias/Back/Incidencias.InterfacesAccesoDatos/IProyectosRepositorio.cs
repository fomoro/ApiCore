using Incidencias.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.InterfacesAccesoDatos
{
    public interface IProyectosRepositorio : IRepositorioGenerico<Proyecto>
    {
        Task<Proyecto> ObtenerNombreAsync(string nombre);
        Task<IEnumerable<Proyecto>> ObtenerTodosConDetallesAsync();
        Task<Proyecto> ObtenerConIncidenciasPorId(int id);
        Task<Proyecto> ObtenerConTareasPorId(int id);
        Task<IEnumerable<Proyecto>> ObtenerProyectosPorUsuario(int idUsuario);
    }
}
