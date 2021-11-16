using System;
using System.Collections.Generic;
using System.Text;

namespace Incidencias.WebApi.ViewModels
{
    public class UsuarioListaVM
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }        
        public string Email { get; set; }
        public string Username { get; set; }
        public string Perfil { get; set; }
    }
}
