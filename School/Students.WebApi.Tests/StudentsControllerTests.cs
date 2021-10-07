using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using School.DomainObjects;
using School.Interfaces.BusinessLogic;
using School.WebApi.Controllers;
using System.Collections.Generic;

namespace Students.WebApi.Tests
{
    [TestClass]
    public class StudentsControllerTests
    {
        /* Dado que este proyecto es para probar la web api, necesitamos hacer referencia a asp.net core para poder
         * tener acceso a ciertas definiciones de clase que vamos a usar. Por ejemoplo, los distintos "Action Result",
         * Como es el caso de OkResult en el test de ejemplo */


        [TestMethod]
        public void GetMethod_Should_Return_Ok_When_Student_Exists()
        {    
            //**** ARRANGE **** (Preparamos todo)
            //Declaro el mock de studentLogic. Este behavior provoca una excepion si algo no se comporta como se espera.
            var studentsLogicMock = new Mock<IStudentLogic>(MockBehavior.Strict);
            
            //Lo configuro de modo que cuando se le invoque el metodo Get pasando por parametro
            //CUALQUIER entero, me devuelva un objeto Student(No me importa si es vacio, a los efectos de lo que quiero testear aca)
            //Noten lo que chequea el metodo Assert, simplemente que sea un objecto del tipo OkResult ;)
            studentsLogicMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new Student());

            //Declaro el mock de mapper. Necesitamos agregar el paquete de automapper al proyecto para poder hacer referencia a la interfaz!
            //No me importa mucho el behavior en este caso, el metodo de controller que estoy testeando EN ESTE CASO no usa mapeos, pero de 
            //todas formas necesito un mock para pasarle al constructor del controller la dependencia.
            //Tampoco necesito configurarlo.
            var mapperMock = new Mock<IMapper>();

            //Creo el SUT (Subjet/System Under Test, o sea, el StudentController. Obviamente necesito referenciar al proyecto de WebApi
            StudentsController sut = new StudentsController(studentsLogicMock.Object, mapperMock.Object);


            //**** ACT **** (Ejecutamos el metodo que queremos probar)
            var result = sut.Get(1); //Recuerden que por como lo definimos, podemos pasar cualquier entero aca!


            //**** ASSERT **** (Comprobamos el resultado de nuestra prueba)

            //Verifico la "expectativa" sobre el mock de logica de negocios (que se haya invocado el metodo Get EXACTAMENTE una vez)
            studentsLogicMock.Verify(mock => mock.Get(It.IsAny<int>()), Times.Exactly(1), "Cantidad incorrecta de invocaciones a Get(int)");

            //Intento convertir el resultado obtenido a un objeto del tipo OkResult, que es lo que espero del controller.
            //Tal como esta escrito el metodo, tambien podria obtener un Http 500, que es OTRO tipo de result.
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult); //Veo si efectivamente logre hacer la conversion de arriba. Si no pude, tendre un null.

        }
    }
}
