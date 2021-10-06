using AutoMapper;
using Incidencias.AccesoDatos.Contratos;
using Incidencias.Modelos;
using Incidencias.WebApi.Controllers;
using Incidencias.WebApi.ViewModels;
using Incidencias.WebApiTest.Mocks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.WebApiTest.PruebasUnitarias
{
    [TestClass]
    public class PerfilesControllerTest
    {
        [TestMethod]
        public async Task Test()
        {

            // Preparación 
            PerfilVM perfil = new PerfilVM() { Id = 1, Nombre = "Anonimus" };
            
            /*
            var _perfilesRepositorioMock = new PerfilesRepositorioMock();
            _perfilesRepositorioMock.Resultado = true;
            await _perfilesRepositorioMock.Agregar(nuevoPerfil);
            */
                                    
            var _perfilesRepositorioMock = new Mock<IRepositorioGenerico<Perfil>>();
            //_perfilesRepositorioMock.Setup(x => x.Actualizar(perfil))
                //.Returns(Task.FromResult(false));
           
            var _loggerMock = new Mock<ILogger<PerfilesController>>();
            var _mapperMock = new Mock<IMapper>();

            var perfilesController = new PerfilesController(_perfilesRepositorioMock.Object, _loggerMock.Object, _mapperMock.Object);
          
            // Ejecución
            var resultado = await perfilesController.Put(perfil.Id, perfil);

            // Verificación
            Assert.AreEqual(perfil.Nombre, resultado.Value.Nombre);
        }
    }
}
