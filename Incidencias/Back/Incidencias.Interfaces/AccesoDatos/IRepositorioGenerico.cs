using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Interfaces.AccesoDatos
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodos();
        Task<T> ObtenerPorId(int id);
        Task<T> Agregar(T entity);
        Task<bool> Actualizar(T entity);
        Task<bool> Eliminar(int id);
    }
}
