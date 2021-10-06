using Incidencias.Modelos.Enum;
using System;
using System.Collections.Generic;

namespace Incidencias.Modelos
{
    public class Proyecto
    {
        public Proyecto()
        {
            Incidencias = new HashSet<Incidencia>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }        
        public EstatusProyecto EstatusProyecto { get; set; }

        public ICollection<UsuariosProyectos> UsuariosProyectos { get; set; }
        public ICollection<Incidencia> Incidencias { get; set; }
    }
}
