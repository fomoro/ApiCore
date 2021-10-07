using Microsoft.EntityFrameworkCore;
using School.DataAccess;
using School.DomainObjects;
using School.Interfaces.DataAccess;
using System.Linq;

namespace School.DataAccess.Repositories
{
    public class StudentsRepository : RepositoryBase<Student>, IStudentsRepository
    {
        public StudentsRepository(MyDBContext repositoryContext) :base(repositoryContext)
        {
        }

        public IQueryable<Student> GetAllStudentsWithCoursesEnrolled()
        {
            //TODO: Noten el uso del metodo include, para cargar los cursos a los que un estudiante se inscribio
            return RepositoryContext.Set<Student>(); //.Include(s => s.Courses); 
        }

        public Student FindByStudentIdWithCourses(string studentId)
        {
            //TODO: Noten el uso del metodo include, para cargar los cursos a los que un estudiante se inscribio
            return RepositoryContext.Set<Student>()
                 .Where(s => s.StudentId == studentId)
                 .Include(s => s.Courses)
                 .FirstOrDefault();
        }

        public void AddStudent(Student student)
        {
            this.Create(student);
        }
    }
}
