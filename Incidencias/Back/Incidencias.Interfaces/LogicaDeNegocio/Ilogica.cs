using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Interface.LogicaDeNegocio
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
