using Incidencias.Modelos.Enum;

namespace Incidencias.Modelos
{
    public class Incidencia
    {
        public int Id { get; set; }        
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EstatusIncidencia EstatusIncidencia { get; set; }
        public float Version { get; set; }
        public int Duracion { get; set; }


        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public int DesarrolladorId { get; set; }
        public int TesterId { get; set; }
        
    }
}
