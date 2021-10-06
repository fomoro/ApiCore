using Incidencias.AccesoDatos.Contratos;
using Incidencias.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.WebApiTest.Mocks
{
    public class PerfilesRepositorioMock : IRepositorioGenerico<Perfil>
    {
        public bool Resultado { get; set; }
        public Task<bool> Actualizar(Perfil entity)
        {
            return Task.FromResult(Resultado);
        }

        public Task<Perfil> Agregar(Perfil entity)
        {
            return Task.FromResult(new Perfil());
        }

        public Task<bool> Eliminar(int id)
        {
            return Task.FromResult(Resultado);
        }

        public Task<Perfil> ObtenerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Perfil>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
