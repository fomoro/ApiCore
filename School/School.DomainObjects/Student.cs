using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.DomainObjects
{
    public class Student 
    {

        //TODO: Obsevar las propiedades de colecciones

        public int Id { get; set; }

        [Required]        
        public string StudentId { get; set; }

        [MaxLength(30, ErrorMessage = "El largo max. permitido es de 30 caracteres" )]
        public string Name { get; set; } 

        public string LastName { get; set; }

        public virtual ICollection<Course> Courses { get; set; } //TODO: Para que ponemos "virtual"? :)
        
        //TODO: Habilitamos la propiedad Enrollments
       // public ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            //Si no las tenemos instanciadas, al intentar hacer insert va a fallar
            Courses = new List<Course>();
           // Enrollments = new List<Enrollment>();
        }
    }
}
