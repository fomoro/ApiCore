using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DomainObjects
{

    /// <summary>
    /// Clase de uso general que me sirve para expresar un poco mejor el resultado de operaciones cuando me haga falta.
    /// Me sirve para dar un poco mas de contexto especialmente si hay errores, sin tener que lanzar una excepcion.
    /// </summary>
    public class OperationResult
    {
        //TODO: Clase nueva, una idea nada mas...

        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success
        {
            get;
            private set;
        }

        public string Message
        {
            get;
            private set;
        }
    }
}
