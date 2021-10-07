using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using School.BussinessLogic;
using School.BussinessLogic.Exceptions;
using School.DomainObjects;
using School.Interfaces.BusinessLogic;
using School.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogicTests
{
    [TestClass]
    public class StudentLogicTests
    {
        [TestMethod]
        public void Add_Should_Throw_Exception_When_Receives_Null_Object()
        {
            //**** Arrange *****
            var repositoryManagerMock = new Mock<IRepositoryManager>(MockBehavior.Strict);
            IStudentLogic sut = new StudentLogic(repositoryManagerMock.Object);
            ArgumentNullException expected = null;
            
            //**** Act ****
            try
            {
                sut.Add(null);
            }
            catch (ArgumentNullException ex)
            {
                expected = ex;
            }
            catch (Exception)
            {
                //Opcionalmente podria dejar este catch vacio. Si el metodo produce otra excepcion, el test no va a fallar de forma inesperada
            }

            //**** Assert ****
            //Quiero probar que la excepcion realmente ocurrio.
            Assert.IsNotNull(expected);
         
            //Assert.ThrowsException<InvalidObjectException>(() => sut.Add(null));
         }



        [TestMethod]
        public void Add_Should_Throw_Exception_When_StudentId_Already_Exists()
        {
            //**** Arrange ****
            //   1) Creo las dependencias necesarias para testear mi SUT (StudentsLogic) las cuales inyectare como dependencias.
            //      Son los mocks de "repositorios"
            //   2) Creo una una instancia de lo que quiero testear, inyectando las dependencias que requiere.

            var studentsRepositoryMock = new Mock<IStudentsRepository>(MockBehavior.Strict);

            //Configuro el metodo FindByCondition para que me devuelva lo que necesito para mis tests
            List<Student> students = new List<Student>();
            students.Add(new Student()); //No me interesan los datos en concreto
            var findByConditionReturns = (students).AsQueryable();
            studentsRepositoryMock.Setup(method =>
                 method.FindByCondition( //Cuando el test llame a FindByCondition...
                     It.IsAny<Expression<Func<Student, bool>>>(), //...Con cualquier criterio de busqueda
                     false))  //...y el segundo parametro en false
                .Returns(findByConditionReturns); //Quiero que retorne una instanca de IQueryable<Student> vacia, para simular que la busqueda
                                                  //no arrojo resultados.

            //Configuracion del metodo Create, simplemente para comprobar que despues NO se invoco durante el test.
            studentsRepositoryMock.Setup(method => method.Create(It.IsAny<Student>()));

            //Ahora armo el RepositoryManager al que le voy a "conectar" el objeto StudentRepository ya configurado.
            var repositoryManagerMock = new Mock<IRepositoryManager>(MockBehavior.Strict);

            //Configuracion la propiedad para acceder al repository desde el manager
            repositoryManagerMock.Setup(prop => prop.StudentsRepository).Returns(studentsRepositoryMock.Object);

            //Configuracion del metodo Save, simplemente para comprobar que despues NO se invoco durante el test
            repositoryManagerMock.Setup(method => method.Save());

            //**** Act ****
            // Creo la instancia del objeto que voy a probar, inyectando las dependencias que necesita.
            IStudentLogic sut = new StudentLogic(repositoryManagerMock.Object);
            DuplicatedObjectException expected = null;
            try
            {
                sut.Add(new Student()); //No me importan los datos
            }
            catch (DuplicatedObjectException ex)
            {
                expected = ex;
            }

            //**** Assert ****
            Assert.IsNotNull(expected); //Compruebo que se lanzo la excepcion que yo esperaba

            //Verifico que los metodos Create y Save NO fueron invocados
            studentsRepositoryMock.Verify(mock => mock.Create(It.IsAny<Student>()), Times.Never);
            repositoryManagerMock.Verify(mock => mock.Save(), Times.Never);
        }



        [TestMethod]
        public void Add_Should_Store_Data_When_Receives_Valid_Object()
        {
            //**** Arrange ****
            //   1) Creo las dependencias necesarias para testear mi SUT (StudentsLogic) las cuales inyectare como dependencias.
            //      Son los mocks de "repositorios"
            //   2) Creo una una instancia de lo que quiero testear, inyectando las dependencias que requiere.

            var studentsRepositoryMock = new Mock<IStudentsRepository>(MockBehavior.Strict);

            //Configuro el metodo FindByCondition para que me devuelva lo que necesito para mis tests
            var findByConditionReturns = (new List<Student>()).AsQueryable();
            studentsRepositoryMock.Setup(method =>
                 method.FindByCondition( //Cuando el test llame a FindByCondition...
                     It.IsAny<Expression<Func<Student, bool>>>(), //...Con cualquier criterio de busqueda
                     false))  //...y el segundo parametro en false
                .Returns(findByConditionReturns); //Quiero que retorne una instanca de IQueryable<Student> vacia, para simular que la busqueda
                                                  //no arrojo resultados.

            //Configuracion del metodo Create, simplemente para comprobar que despues se invoco durante el test.
            studentsRepositoryMock.Setup(method => method.Create(It.IsAny<Student>()));           
            
            //Ahora armo el RepositoryManager al que le voy a "conectar" el objeto StudentRepository ya configurado.
            var repositoryManagerMock = new Mock<IRepositoryManager>(MockBehavior.Strict);

            //Configuracion la propiedad para acceder al repository desde el manager
            repositoryManagerMock.Setup(prop => prop.StudentsRepository).Returns(studentsRepositoryMock.Object);

            //Configuracion del metodo Save, simplemente para comprobar que despues se invoco durante el test
            repositoryManagerMock.Setup(method => method.Save());


            //**** Act ****

            // Creo la instancia del objeto que voy a probar, inyectando las dependencias que necesita.
            IStudentLogic sut = new StudentLogic(repositoryManagerMock.Object);
            Student s = new Student(); //Ni siquiera me importa asignarle valores a sus propiedades. No lo necesito para este test!
            var studentAdded = sut.Add(s);


            //**** Assert ****

            Assert.IsNotNull(studentAdded);
           // Assert.IsInstanceOfType(studentAdded, typeof(Student));

            //Me aseguro que invoquen los metodos / propiedades que espero que se invoquen
            repositoryManagerMock.VerifyAll();  
            studentsRepositoryMock.VerifyAll();

        }
    }
}
