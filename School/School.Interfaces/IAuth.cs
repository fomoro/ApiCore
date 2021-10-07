using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Interfaces
{
    public interface IAuth
    {
        /// <summary>
        /// Dado un identificador de usuario, obtiene un token de autorizacion
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetAuthToken(int userId, string password);

        /// <summary>
        /// Valida un token para verificar que el usuario tenga una sesion activa y que pueda ejecutar la accion 
        /// solicitada en base a su rol por ejemplo
        /// </summary>
        /// <param name="authToken">Token de autenticacion</param>
        /// <param name="roleName">Rol del usuario</param>
        /// <returns></returns>
        bool IsValidToken(string authToken, params string[] roles);
    }
}
