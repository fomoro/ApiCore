namespace Incidencias.Modelos
{
    public partial class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public int Duracion { get; set; }

        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
