using Incidencias.Modelos;
using System.Threading.Tasks;

namespace Incidencias.InterfacesLogicaDeNegocio
{
    public interface IUsuariosLogica : Ilogica<Usuario>
    {
        Task<bool> CambiarContrasena(Usuario usuario);
        Task<bool> CambiarPerfil(Usuario usuario);
        Task<bool> ValidarContrasena(Usuario usuario);
        Task<(bool resultado, Usuario usuario)> ValidarDatosLogin(Usuario datosLoginUsuario);
    }
}
