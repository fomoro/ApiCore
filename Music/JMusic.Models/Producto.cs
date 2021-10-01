using JMusic.Models.Enum;
using System;
using System.Collections.Generic;

#nullable disable

namespace JMusic.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesOrden = new HashSet<DetalleOrden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public EstatusProducto Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<DetalleOrden> DetallesOrden { get; set; }
    }
}
