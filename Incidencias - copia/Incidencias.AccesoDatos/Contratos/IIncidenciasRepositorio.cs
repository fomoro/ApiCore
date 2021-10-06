using Incidencias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.AccesoDatos.Contratos
{
    public interface IIncidenciasRepositorio : IRepositorioGenerico<Incidencia>
    {
        Task<Incidencia> ObtenerNombreAsync(string nombre);
    }
}
