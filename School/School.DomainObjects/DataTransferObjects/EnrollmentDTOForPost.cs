using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DomainObjects.DataTransferObjects
{

    /// <summary>
    /// Clase DTO especialmente hecha para la operacion POST
    /// </summary>
    public class EnrollmentDTOForPost
    {
        [Required(ErrorMessage = "Identificador de estudiante debe ser mayor que cero")]
        public string StudentId { get; set; }

        //TODO: Esta es una mejor manera de validar propiedades del tipo int. Si ponen simplemente[Required] se va
        //a cumplir siempre. Si no lo mandan desde el Front End, C# asumia el valor por defecto, que es 0, y por lo tanto es valido.
        //Lo que estamos diciendo es que StudentId y CourseId deben estar en el rango de cero y "el mayor entero porsible"
        [Range(1, int.MaxValue, ErrorMessage = "Identificador de curso debe ser mayor que cero")]
        public int CourseId { get; set; }
    }
}
