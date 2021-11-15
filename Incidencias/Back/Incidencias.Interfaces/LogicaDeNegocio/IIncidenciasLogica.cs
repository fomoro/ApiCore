using Incidencias.Interface.LogicaDeNegocio;
using Incidencias.Interfaces;
using Incidencias.Modelos;
using System.Threading.Tasks;

namespace Incidencias.Interfaces.LogicaDeNegocio
{
    public interface IIncidenciasLogica : Ilogica<Incidencia>
    {
        Task<Incidencia> ObtenerPorNombre(string nombre);
    }
}
