using Incidencias.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.WebApi.ViewModels
{
    public class IncidenciaVM
    {
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EstatusIncidencia EstatusIncidencia { get; set; }
        public float Version { get; set; }
        public int DesarrolladorId { get; set; }
        public int TesterId { get; set; }
    }

}
