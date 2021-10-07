using School.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BussinessLogic
{
    public class AuthLogic : IAuth
    {
        public string GetAuthToken(int userId, string password)
        {
            //Esto es basicamente el Login, por lo que deberia:
            //     Verificar que el usuario existe, que las pass es valida, etc ETC
            //     Crear el token unico para ese usuario
            //     Almacenarlo en de alguna manera para saber que la sesion esta activa (Puede ser BBDD por ejemplo)

            //Por ahora, simplemente retorno un token fijo para asumiendo que es valido, ver el ejemplo
            return "39ea67c0-9076-41f0-b14d-0def4420dfa6";
        }


        public bool IsValidToken(string authToken, string[] roles)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                return false;
            }

            //"Busco el token en mi sesion" para ver si existe, que el usuario tenga el rol requerido
            // para la accion que se quiere ejecutar, et.
            // A efectos del ejemplo uso el mismo token fijo de arriba, asumo que el usuario asociado
            // tiene un rol que pongo "a fuego" tambien
            var sessionToken = "39ea67c0-9076-41f0-b14d-0def4420dfa6";
            var userRole = "professor";

            if (authToken != sessionToken)
            {
                //No esta autenticado
                return false;
            }

            //En este punto se que esta AUTENTICADO. Ahora me fijo si esta AUTORIZADO
            //Revisamos si el rol del usuario esta dentro de la lista de roles permitidos, unicamente si dicha
            //lista fue especificada
            if (roles != null && roles.Length > 0)
            {
                if (!roles.Contains(userRole))
                {
                    return false;
                }
            }
            //Todo salio bien
            return true;
        }
    }
}
