using Incidencias.Modelos.Enum;
using System;
using System.Collections.Generic;

namespace Incidencias.Modelos
{
    public class UsuariosProyectos
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }

        
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }        
    }
}
