using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DomainObjects.DataTransferObjects
{
    /// <summary>
    /// Esta es una clase que, por lo simple del ejemplo vamos a usarla como DTO tanto para la operación POST como PUT.
    /// En escenarios más realistas y de mayor complejidad podríamos considerar tener clases DTO separadas en ambos casos.
    /// </summary>
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="El ID no puede estar en blanco")]
        [MaxLength(6, ErrorMessage = "El largo max. permitido es de 6 caractares")] //No necesito especificar un mensaje, es opcional, y puedo poner cuantas validaciones quiera sobre una propidad. //TODO: Exploren qué otras validaciones disponibles tienen
        public string StudentId { get; set; }

        [MaxLength(30, ErrorMessage = "El largo max. permitido es de 30 caracteres")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "El largo max. permitido es de 30 caracteres")]
        public string LastName { get; set; }
    }
}
