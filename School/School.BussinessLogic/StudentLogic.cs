using School.BussinessLogic.Exceptions;
using School.DomainObjects;
using School.Interfaces;
using School.Interfaces.BusinessLogic;
using School.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.BussinessLogic
{
    public class StudentLogic : IStudentLogic 
    {
        private const string null_student = "Student";

        IRepositoryManager _repositoryManager;

        public StudentLogic(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Student Add(Student s)
        {
            //throw new Exception("test");

            //Validamos que el objeto no sea null
            if (s == null)
            {
                //O tambien si determino que el objeto es invalido mediante alguna otra regla....
                throw new ArgumentNullException(null_student); //Esto es solo una opcion, no necesariamente DEBE lanzarse una excepcion
            }

            /* Capturar y distinguir correctamente una excepcion de violacion de indice unico con EF Core no es tan directo, pero es posible, aunque el 
             * codigo termina quedano atado a analizar detalles de la excepcion de SQL Server y por lo tanto termino acoplando mi codigo a detalles del 
             * motor de base de datos.
             * 
             * Si en un caso asi quiero de todos quiero lanzar una excepcion a nivel de logica de negocios para representar este caso, una posible
             * alternativa mas sencilla sea buscar si el objeto existe en base de datos, y si es asi, lanzar la excepcion manualmente.
             * 
             * NOTA: En una aplicacion real podria pasarnos que buscamos y no encontramos un match, pero justo antes de que se ejecute nuestra instruccion
             * "save" alguien mas (otro usuario por ejemoplo) justo lo inserte, por lo cual no alcanzamos a lanzar la excepcion manualmente. En ese caso
             * nuestro codigo intentara insertar el objeto, pero de todos modos la base de datos sera quien termine de lanzar la excepcion la cual, en ultima
             * instancia, sera atrapada por el controller, si asi decidimos implementarlo */

            var studentInDB = _repositoryManager.StudentsRepository.FindByCondition(x => x.StudentId == s.StudentId, false).FirstOrDefault();
            if (studentInDB != null)
            {
                throw new DuplicatedObjectException($"Objeto duplicado. StudentId: {s.StudentId}");
            }
            _repositoryManager.StudentsRepository.Create(s);
            _repositoryManager.Save();

            return s;
        }

        public bool Remove(int id)
        {
            var st = Get(id);
            if (st == null)
            {
                return false;
            }
            _repositoryManager.StudentsRepository.Delete(st);
            _repositoryManager.Save();

            return true;
        }

        public Student Update(Student s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(null_student);
            }

            var studentInDB = _repositoryManager.StudentsRepository
                .FindByCondition(x => x.Id == s.Id, trackChanges: true).FirstOrDefault();

            if (studentInDB == null)
            {
                return null;
            }

            //Independientemente del objeto que ya cargue en memoria por Id, verifico que no voy a generar un duplicado por StudentId
            if (_repositoryManager.StudentsRepository.Exists(x => x.StudentId == s.StudentId & x.Id != s.Id))
            {
                throw new DuplicatedObjectException($"Un estudiante identificado como {s.StudentId} ya existe.");
            }

            studentInDB.Name = s.Name;
            studentInDB.StudentId = s.StudentId;

            _repositoryManager.Save();

            //Save
            return studentInDB;
        }

        public Student Get(int id)
        {
            var studentInDB = _repositoryManager.StudentsRepository.FindByCondition(s => s.Id == id, trackChanges: false).FirstOrDefault();
            return studentInDB;
        }

        public IEnumerable<Student> GetAll()
        {
            //throw new Exception();
            return _repositoryManager.StudentsRepository.GetAllStudentsWithCoursesEnrolled();            
        }

        public OperationResult EnrollToCourse(string studentId, int courseId)
        {
            //TODO: Nuevo metodo de logica de negocios.

            var studentInDB = _repositoryManager.StudentsRepository.FindByStudentIdWithCourses(studentId);

            //Verifico que el estudiante exista
            if (studentInDB == null)
            {
                return new OperationResult(false, $"Estudiante con Id {studentId} no existe.");
            }

            //Verifico que el curso exista
            var courseInDB = _repositoryManager.CoursesRepository.FindByCondition(c => c.Id == courseId, false).FirstOrDefault();
            if (courseInDB == null)
            {
                return new OperationResult(false, $"Curso con Id {courseId} no existe.");
            }

            //Si el estudiante y el curso existen, verifico que no este inscripto

            //--> Primera opcion
            if (studentInDB.Courses.Any(c => c.Id == courseInDB.Id))
            {
                return new OperationResult(false, "El estudiante ya esta inscripto a este curso");
            }


            //--> Segunda opcion, puedo ir por el lado del curso
            //if (courseInDB.Students.Any(s => s.StudentId == studentInDB.StudentId))
            //{
            //    return new OperationResult(false, "El estudiante ya esta inscripto a este curso");
            //}

            //--> Tercera opcion, podria preguntar por la lista de Enrollments en cualquier caso??

            //Si pasa todas las validaciones realizamos la inscripcion

            //--> Implementacion mediante "clase de relacion"
            //Enrollment enrollment = new Enrollment();
            //enrollment.Course = courseInDB;
            //enrollment.Student = studentInDB;
            //enrollment.Date = DateTime.Now;
            //_repositoryManager.EnrollmentsRepository.Create(enrollment);

            studentInDB.Courses.Add(courseInDB);
            _repositoryManager.Save();

            return new OperationResult(true, "Inscripcion exitosa.");
        }
    }
}