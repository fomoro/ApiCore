using System;

namespace Incidencias.LogicaDeNegocio.Exceptions
{
    public class DuplicatedObjectException : Exception
    {
        public DuplicatedObjectException(string message) : base(message) { }

        public DuplicatedObjectException(string message, Exception inner) : base(message, inner) { }
    }
}