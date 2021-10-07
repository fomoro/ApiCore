using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School.DataAccess;
using School.DataAccess.Repositories;
using School.DomainObjects;
using School.Interfaces.DataAccess;
using System.Linq;

namespace Students.DataAccess.Tests
{
    [TestClass]
    public class StudentsRepositoryTests : BaseRepositoryTest
    {
        IRepositoryManager _repositoryManager;


        /// <summary>
        /// Se ejecuta antes de correr cada test en la clase.
        /// Realiza tareas de inicializacion
        /// </summary>
        [TestInitialize]        
        public void TestInitialie()
        {
            //Como queremos que los tests sean idempotentes, creamos una nueva base de datos en memoria y un nuevo RepositoryManager cada vez
            SetupInMemoryDatabase();
            _repositoryManager = new RepositoryManager(DBContext);
        }


        /// <summary>
        /// Se ejecuta luego de correr cada test en la clase
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            //Como queremos que los tests sean idempotentes, limpiamos los recursos luego de cada test.
            CleanupInMemoryDatabase();
            _repositoryManager = null;
        }


        [TestMethod]
        public void FindByCondion_Should_Return_1_Student_Enrolled_Into_Exactly_2_Courses()
        {
            //**** Act *****
            var students =  _repositoryManager.StudentsRepository.FindByCondition(s => s.Courses.Count == 2, false);

            //**** Assert ****
            Assert.AreEqual(1, students.Count());  
        }

        [TestMethod]
        public void FindByStudentIdWithCourses_Should_Return_Correct_Student_With_Courses()
        {
            //**** Arrange ****
            string studentId = "std1"; //Sabemos que existe y tiene cursos

            //**** Act ****
            var student = _repositoryManager.StudentsRepository.FindByStudentIdWithCourses(studentId);

            //**** Assert ****
            Assert.IsNotNull(student);
            Assert.IsTrue(student.Courses.Count > 0);
        }

        [TestMethod]
        public void Create_Should_Add_Student()
        {
            //**** Arrange ****
            Student s = new Student()
            {
                Name = "Estudiante 4",
                LastName = "Cuarto estudiante",
                StudentId = "std4"  
            };

            //**** Act ****
            _repositoryManager.StudentsRepository.Create(s);
            _repositoryManager.Save();

            //**** Assert ****
            Assert.IsTrue(s.Id > 0);
            bool studentWasAdded = _repositoryManager.StudentsRepository.Exists(s => s.StudentId == "std4");
            Assert.IsTrue(studentWasAdded);
        }

        [TestMethod]
        public void Exist_Should_Return_False_When_No_Students_Matches_Condition()
        {
            //**** Act *****
            bool existsAtLestOne = _repositoryManager.StudentsRepository.Exists(s => s.Name == "Estudiante10");

            //**** Assert ****
            Assert.IsFalse(existsAtLestOne);
        }

        [TestMethod]
        public void Delete_Should_Delete_Student()
        {
            //**** Arrange ****
            string studentId = "std1";
            Student studentToDelete = _repositoryManager.StudentsRepository.FindByCondition(s => s.StudentId == studentId ,true).FirstOrDefault();

            //**** Act ****
            _repositoryManager.StudentsRepository.Delete(studentToDelete);
            _repositoryManager.Save();

            //**** Assert ****
            bool exists =_repositoryManager.StudentsRepository.Exists(s => s.StudentId == studentId);
            Assert.IsFalse(exists);
        }
    }
}
