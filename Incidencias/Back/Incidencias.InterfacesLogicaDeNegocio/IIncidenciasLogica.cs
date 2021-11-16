using Incidencias.Modelos;
using System.Threading.Tasks;

namespace Incidencias.InterfacesLogicaDeNegocio
{
    public interface IIncidenciasLogica : Ilogica<Incidencia>
    {
        Task<Incidencia> ObtenerPorNombre(string nombre);
    }
}
