
using School.DomainObjects;
using System.Linq;

namespace School.Interfaces.DataAccess
{
    public interface IStudentsRepository : IRepositoryBase<Student>
    {
        //TODO: Empezamos a definir algunos metodos especificos en las interfaces "mas concretas" de los repositorios

        /// <summary>
        /// Devuelve la lista de estudiantes, incluyendo los cursos a los que esten inscriptos
        /// </summary>
        /// <returns></returns>
        IQueryable<Student> GetAllStudentsWithCoursesEnrolled();

        Student FindByStudentIdWithCourses(string studentId);
    }
}
