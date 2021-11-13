using System;

namespace Incidencias.WebApi.ViewModels
{
    public class UsuariosProyectosVM
    {
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }

}
