using System.Threading.Tasks;
using Incidencias.Modelos;

namespace Incidencias.AccesoDatos.Contratos
{
    public interface IUsuariosRepositorio : IRepositorioGenerico<Usuario>
    {
        Task<bool> CambiarContrasena(Usuario usuario);
        Task<bool> CambiarPerfil(Usuario usuario);
        Task<bool> ValidarContrasena(Usuario usuario);
    }
}
