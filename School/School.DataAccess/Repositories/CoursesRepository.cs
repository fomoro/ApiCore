using School.DataAccess;
using School.DomainObjects;
using School.Interfaces.DataAccess;

namespace School.DataAccess.Repositories
{
    public class CoursesRepository : RepositoryBase<Course>, ICoursesRepository
    {
        public CoursesRepository(MyDBContext repositoryContext) :base(repositoryContext)
        {
        }
    }
}
