using Microsoft.EntityFrameworkCore;
using School.DataAccess;
using School.DomainObjects;

namespace Students.DataAccess.Tests
{
    public class BaseRepositoryTest
    {
        protected MyDBContext DBContext
        {
            get;
            private set;
        }
          
        /// <summary>
        /// Inicializacion y carga de datos del DB Context "In Memory" que usaramos para estos tests
        /// </summary>
        public void SetupInMemoryDatabase()
        {
            //Hago el Setup de mi DB Context
            var options = new DbContextOptionsBuilder<MyDBContext>().UseInMemoryDatabase(databaseName: "SchoolDB").Options;
            DBContext = new MyDBContext(options);


            //creo datos de estudiantes
            Student s1 = new Student()
            {
                Name = "Estudiante 1",
                LastName = "Primer Estudiante",
                StudentId = "std1"
            };
            Student s2 = new Student()
            {
                Name = "Estudiante 2",
                LastName = "Segundo Estudiante",
                StudentId = "std2"
            };
            Student s3 = new Student()
            {
                Name = "Estudiante 3",
                LastName = "Tercer estuiante",
                StudentId = "std3"
            };

            //Creo datos de cursos
            Course c1 = new Course()
            {
                Name = "Curso 1",
                Semester = 1
            };
            Course c2 = new Course()
            {
                Name = "Curso 2",
                Semester = 1
            };

            //Relaciono los datos, agregando cursos a la lista de cursos de cada estudiante
            //Como tengo una relacion N a N, tambien podria hacerlo al reves!
            s1.Courses.Add(c1);
            s1.Courses.Add(c2);
            s2.Courses.Add(c1);
            s3.Courses.Add(c2);

            DBContext.Add(s1);
            DBContext.Add(s2);
            DBContext.Add(s3);

            DBContext.SaveChanges();
        }

        protected void CleanupInMemoryDatabase()
        {
            DBContext.Database.EnsureDeleted();
        }

    }
}
