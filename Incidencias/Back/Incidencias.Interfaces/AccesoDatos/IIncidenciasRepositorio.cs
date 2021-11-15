using Incidencias.Interfaces;
using Incidencias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Interfaces.AccesoDatos
{
    public interface IIncidenciasRepositorio : IRepositorioGenerico<Incidencia>
    {
        Task<Incidencia> ObtenerPorNombre(string nombre);
    }
}
