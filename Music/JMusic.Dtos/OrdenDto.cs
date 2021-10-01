using JMusic.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMusic.Dtos
{

    public class OrdenDto
    {
        public OrdenDto()
        {
            DetallesOrden = new List<DetalleOrdenDto>();
        }

        public int Id { get; set; }
        public decimal CantidadArticulos { get; set; }
        public decimal Importe { get; set; }
        //[Required]
        public DateTime? FechaRegistro { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        //public EstatusOrden EstatusOrden { get; set; }
        public List<DetalleOrdenDto> DetallesOrden { get; set; }
    }

}
