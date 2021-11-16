using Incidencias.Modelos;
using System.Threading.Tasks;

namespace Incidencias.Interfaces.AccesoDatos
{
    public interface IIncidenciasRepositorio : IRepositorioGenerico<Incidencia>
    {
        Task<Incidencia> ObtenerPorNombre(string nombre);
    }
}
