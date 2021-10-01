using Incidencias.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Modelos
{
    public class Incidencia
    {
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EstatusIncidencia EstatusIncidencia { get; set; }
        public float Version { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
