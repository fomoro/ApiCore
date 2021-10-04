using Incidencias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.AccesoDatos.Contratos
{
    public interface IProyectosRepositorio : IRepositorioGenerico<Proyecto>
    {
        Task<Proyecto> ObtenerNombreAsync(string nombre);
        Task<IEnumerable<Proyecto>> ObtenerTodosConDetallesAsync();
        Task<Proyecto> ObtenerConDetallesAsync(int id);
    }
}
