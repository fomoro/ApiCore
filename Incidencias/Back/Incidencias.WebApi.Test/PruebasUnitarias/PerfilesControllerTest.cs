using AutoMapper;
using Incidencias.InterfacesAccesoDatos;
using Incidencias.Modelos;
using Incidencias.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Incidencias.WebApi.Test.PruebasUnitarias
{
    [TestClass]
    public class PerfilesControllerTest
    {
        [TestMethod]
        public void ElMetodoGetDebeRetornarOkCuandoElPerfilExiste()
        {
            //**** ARRANGE **** (Preparamos todo)           

            //Declaro el mock de studentLogic. Este behavior provoca una excepion si algo no se comporta como se espera.
            var perfilMock = new Mock<IRepositorioGenerico<Perfil>>(MockBehavior.Strict);

            //Lo configuro de modo que cuando se le invoque el metodo Get pasando por parametro
            //CUALQUIER entero, me devuelva un objeto Student(No me importa si es vacio, a los efectos de lo que quiero testear aca)
            //Noten lo que chequea el metodo Assert, simplemente que sea un objecto del tipo OkResult ;)
            perfilMock.Setup(x => x.ObtenerAsync(It.IsAny<int>())).Returns(Task.FromResult(new Perfil()));
                
            //Declaro el mock de mapper. Necesitamos agregar el paquete de automapper al proyecto para poder hacer referencia a la interfaz!
            //No me importa mucho el behavior en este caso, el metodo de controller que estoy testeando EN ESTE CASO no usa mapeos, pero de 
            //todas formas necesito un mock para pasarle al constructor del controller la dependencia.
            //Tampoco necesito configurarlo.
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<PerfilesController>>();

            //Creo el SUT (Subjet/System Under Test, o sea, el StudentController. Obviamente necesito referenciar al proyecto de WebApi
            PerfilesController sut = new PerfilesController(perfilMock.Object, loggerMock.Object, mapperMock.Object);


            //**** ACT **** (Ejecutamos el metodo que queremos probar)
            var result = sut.Get(1); //Recuerden que por como lo definimos, podemos pasar cualquier entero aca!


            //**** ASSERT **** (Comprobamos el resultado de nuestra prueba)

            //Verifico la "expectativa" sobre el mock de logica de negocios (que se haya invocado el metodo Get EXACTAMENTE una vez)
            perfilMock.Verify(mock => mock.ObtenerAsync(It.IsAny<int>()), Times.Exactly(1), "Cantidad incorrecta de invocaciones a Get(int)");

            //Intento convertir el resultado obtenido a un objeto del tipo OkResult, que es lo que espero del controller.
            //Tal como esta escrito el metodo, tambien podria obtener un Http 500, que es OTRO tipo de result.

            var okResult = result as OkObjectResult;            
            Assert.IsNotNull(okResult); //Veo si efectivamente logre hacer la conversion de arriba. Si no pude, tendre un null.                        
        }

    }
}
