using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidencias.InterfacesLogicaDeNegocio
{
    public interface Ilogica<T> where T : class
    {
        Task<T> Agregar(T entity);
        Task<bool> Eliminar(int id);
        Task<bool> Actualizar(T entity);
        Task<T> ObtenerPorId(int id);
        Task<IEnumerable<T>> ObtenerTodos();
               
    }
}
