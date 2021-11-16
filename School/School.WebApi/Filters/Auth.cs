using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using School.BussinessLogic;
using School.Interfaces;

namespace School.WebApi.Filters
{
    public class Auth : Attribute, IAuthorizationFilter
    {
        private IAuth _auth;
        private readonly string[] _roles;

        public Auth(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _auth = (IAuth)context.HttpContext.RequestServices.GetService(typeof(IAuth));

            string token = context.HttpContext.Request.Headers["auth"];
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No presento las credenciales de autenticacion"
                };
                return;
            }
           if (!_auth.IsValidToken(token, _roles))
           {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Sesion no valida, o no tiene permisos para ejecutar la accion solicitada"
                };
                return;
            }
        }
    }
}
