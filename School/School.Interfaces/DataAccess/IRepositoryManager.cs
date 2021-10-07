

namespace School.Interfaces.DataAccess
{
    public interface IRepositoryManager
    {
        IStudentsRepository StudentsRepository { get; }
        ICoursesRepository CoursesRepository { get; }
        IEnrollmentsRepository EnrollmentsRepository { get; }
        void Save();
    }
}
