using Incidencias.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incidencias.WebApi.ViewModels
{
    public class TareaVM
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public int Duracion { get; set; }


        public int ProyectoId { get; set; }
    }

}
