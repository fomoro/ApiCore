using System.Collections.Generic;

namespace School.DomainObjects.DataTransferObjects
{
    public class StudentDTOWithCouresesForGet
    {
        public string StudentId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public ICollection<CourseDTOForGet> Courses { get; set; }
    }
}
