using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DomainObjects
{
    public class Course
    {
        //TODO: Obsevar las propiedades de colecciones

        public int Id { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }

        public ICollection<Student> Students { get; set; }
       
       // public ICollection<Enrollment> Enrollments { get; set; }

        public Course()
        {
            //Si no las tenemos instanciadas, al intentar hacer insert va a fallar
            Students = new List<Student>();
        //    Enrollments = new List<Enrollment>();
        }

    }

 
}
