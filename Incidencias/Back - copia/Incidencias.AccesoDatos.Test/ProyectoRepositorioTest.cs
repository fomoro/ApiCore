using Incidencias.AccesoDatos.Repositorios;
using Incidencias.Interfaces;
using Incidencias.Interfaces.AccesoDatos;
using Incidencias.Modelos;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Incidencias.AccesoDatos.Test
{
    [TestClass]
    public class ProyectoRepositorioTest : BaseRepositoryTest
    {
        IRepositorioGenerico<Proyecto> _repositoryManager;
        private readonly ILogger<ProyectosRepositorio> _logger;


        [TestInitialize]
        public void TestInitialie()
        {
            SetupInMemoryDatabase();
            _repositoryManager = new ProyectosRepositorio(DBContext, _logger);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //Como queremos que los tests sean idempotentes, limpiamos los recursos luego de cada test.
            CleanupInMemoryDatabase();
            _repositoryManager = null;
        }

        [TestMethod]
        public void BuscamosSiEncuentraUnProyecto()
        {
            //**** Arrange ****
            var id = 1;

            //**** Act *****
            var proyecto = _repositoryManager.ObtenerPorId(id);

            //**** Assert ****
            Assert.AreEqual(1, proyecto.Result.Id);
        }

        [TestMethod]
        public void ComprobamamosQueTraigaTodosLosProyectos()
        {
            //**** Arrange ****
            //int Id = "std1"; 

            //**** Act ****
            var proyectos = _repositoryManager.ObtenerTodos();

            //**** Assert ****
            Assert.IsNotNull(proyectos.Result);
            Assert.IsTrue(proyectos.Result != null);
        }

        [TestMethod]
        public void CrearProyectoNuevo()
        {
            //**** Arrange ****
            Proyecto otro = new Proyecto()
            {
                Nombre = "Juegos"
            };

            //**** Act ****
            _repositoryManager.Agregar(otro);

            //**** Assert ****
            Assert.IsTrue(otro.Id > 0);
            var proyectoAgregado = _repositoryManager.ObtenerPorId(otro.Id);
            Assert.IsTrue(proyectoAgregado.Id > 0);
        }


        [TestMethod]
        public void EliminarUnProyecto()
        {
            //**** Arrange ****
            int Id = 1;
            var proyectoEliminado = _repositoryManager.ObtenerPorId(Id);

            //**** Act ****
            _repositoryManager.Eliminar(proyectoEliminado.Result.Id);

            //**** Assert ****
            var exists = _repositoryManager.ObtenerPorId(Id);
            Assert.IsFalse(exists.Id != Id);
        }
    }
}

