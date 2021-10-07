using School.DomainObjects;
using School.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repositories
{
    public class EnrollmentsRepository : RepositoryBase<Enrollment>, IEnrollmentsRepository
    {
        public EnrollmentsRepository(MyDBContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
