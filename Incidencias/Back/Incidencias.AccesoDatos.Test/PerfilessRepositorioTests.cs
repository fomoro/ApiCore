using Incidencias.AccesoDatos.Repositorios;
using Incidencias.InterfacesAccesoDatos;
using Incidencias.Modelos;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Incidencias.AccesoDatos.Test
{
    [TestClass]
    public class PerfilessRepositorioTests : BaseRepositoryTest
    {
        IRepositorioGenerico<Perfil> _repositoryManager;
        private readonly ILogger<PerfilesRepositorio> _logger;

        
        [TestInitialize]
        public void TestInitialie()
        {            
            SetupInMemoryDatabase();
            _repositoryManager = new PerfilesRepositorio(DBContext, _logger);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //Como queremos que los tests sean idempotentes, limpiamos los recursos luego de cada test.
            CleanupInMemoryDatabase();
            _repositoryManager = null;
        }

        [TestMethod]
        public void BuscamosSiEncuentraUnPefil()
        {
            //**** Arrange ****
            var id = 1;

            //**** Act *****
            var perfil = _repositoryManager.ObtenerAsync(id);

            //**** Assert ****
            Assert.AreEqual(1, perfil.Id);
        }

        [TestMethod]
        public void ComprobamamosQueTraigaTodosLosPerfiles()
        {
            //**** Arrange ****
            //int Id = "std1"; 

            //**** Act ****
            var perfiles = _repositoryManager.ObtenerTodosAsync();

            //**** Assert ****
            Assert.IsNotNull(perfiles.Result);
            Assert.IsTrue(perfiles.Result.FirstOrDefault().Usuarios.Count > 0);
        }

        [TestMethod]
        public void Create_Should_Add_Student()
        {
            //**** Arrange ****
            Perfil otro = new Perfil()
            {
                Nombre = "Invitado"
            };

            //**** Act ****
            _repositoryManager.Agregar(otro);            

            //**** Assert ****
            Assert.IsTrue(otro.Id > 0);
            var perfilAgregado = _repositoryManager.ObtenerAsync(otro.Id);
            Assert.IsTrue(perfilAgregado.Id > 0);
        }


        [TestMethod]
        public void Delete_Should_Delete_Student()
        {
            //**** Arrange ****
            int Id = 1;
            var perfilEliminado = _repositoryManager.ObtenerAsync(Id);

            //**** Act ****
            _repositoryManager.Eliminar(perfilEliminado.Result.Id);            

            //**** Assert ****
            var exists = _repositoryManager.ObtenerAsync(Id);
            Assert.IsFalse(exists.Result.Id == Id);
        }
    }
}
