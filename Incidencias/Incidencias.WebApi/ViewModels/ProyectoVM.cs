using Incidencias.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.WebApi.ViewModels
{
    public class ProyectoVM
    {
        public ProyectoVM()
        {
            Incidencias = new List<IncidenciaVM>();
            UsuariosProyectos = new List<UsuariosProyectosVM>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadIncidencias { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }       



        public List<IncidenciaVM> Incidencias { get; set; }
        public List<UsuariosProyectosVM> UsuariosProyectos { get; set; }
    }

}
