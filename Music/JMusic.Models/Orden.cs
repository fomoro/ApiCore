﻿using JMusic.Models.Enum;
using System;
using System.Collections.Generic;

namespace JMusic.Models
{
    public class Orden
    {
        public Orden()
        {
            DetallesOrden = new HashSet<DetalleOrden>();
        }

        public int Id { get; set; }
        public decimal CantidadArticulos { get; set; }
        public decimal Importe { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int UsuarioId { get; set; }
        public EstatusOrden EstatusOrden { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<DetalleOrden> DetallesOrden { get; set; }
    }
}
