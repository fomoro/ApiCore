using Incidencias.Modelos;
using System.Threading.Tasks;

namespace Incidencias.InterfacesAccesoDatos
{
    public interface IIncidenciasRepositorio : IRepositorioGenerico<Incidencia>
    {
        Task<Incidencia> ObtenerNombreAsync(string nombre);
    }
}
