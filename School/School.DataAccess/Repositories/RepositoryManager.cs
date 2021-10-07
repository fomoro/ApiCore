
using School.Interfaces.DataAccess;

namespace School.DataAccess.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private MyDBContext _myDBContext;
        private IStudentsRepository _studentsRepository;
        private ICoursesRepository _coursesRepository;
        private IEnrollmentsRepository _enrollmentsRepository;

        public RepositoryManager(MyDBContext repositoryContext)
        {
            _myDBContext = repositoryContext;
        }

        public void Save()
        {
            _myDBContext.SaveChanges();
        }

        public IStudentsRepository StudentsRepository
        {
            get
            {
                if (_studentsRepository == null)
                    _studentsRepository = new StudentsRepository(_myDBContext);

                return _studentsRepository;
            }
        }

        public ICoursesRepository CoursesRepository
        {
            get
            {
                if (_coursesRepository == null)
                    _coursesRepository = new CoursesRepository(_myDBContext);

                return _coursesRepository;
            }
        }

        //TODO: Nuevo repository para manejar inscripciones a cursos
        public IEnrollmentsRepository EnrollmentsRepository
        {
            get
            {
                if (_enrollmentsRepository == null)
                    _enrollmentsRepository = new EnrollmentsRepository(_myDBContext);

                return _enrollmentsRepository;
            }
        }
    }
}