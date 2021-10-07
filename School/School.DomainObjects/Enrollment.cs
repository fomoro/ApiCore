using System;
using System.Collections.Generic;

namespace School.DomainObjects
{
    public class Enrollment
    {       
        public Student Student {get; set;}
        public Course Course { get; set; }
        public DateTime Date { get; set; }
    }
}
