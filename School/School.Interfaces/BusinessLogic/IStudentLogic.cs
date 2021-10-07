using School.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Interfaces.BusinessLogic
{
    /// <summary>
    /// Esta nueva interfaz me permite definir operaciones mas especificas sobre estudiantes.
    /// Con lo que habiamos visto hasta el momento, ILogic<T> era suficiente. Pero necesitamo mas.
    /// </summary>
    public interface IStudentLogic : ILogic<Student>
    {
        //TODO: Interfaz nueva

        OperationResult EnrollToCourse(string StudentId, int CourseId);
    }
}
