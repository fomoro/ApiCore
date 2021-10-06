using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Incidencias.AccesoDatos;
using Incidencias.AccesoDatos.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Incidencias.Modelos;

namespace Incidencias.AccesoDatosTest.PruebasUnitarias
{
    [TestClass]
    public class PerfilesRepositorioTest
    {

        /*public MovieDbContext MovieContext { get; private set; }

        public MovieSeedDataFixture()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>()
                .UseInMemoryDatabase("MovieListDatabase")
                .Options;

            MovieContext = new MovieDbContext(options);

            MovieContext.Movies.Add(new Movie { Id = 1, Title = "Movie 1", YearOfRelease = 2018, Genre = "Action" });
            MovieContext.Movies.Add(new Movie { Id = 2, Title = "Movie 2", YearOfRelease = 2018, Genre = "Action" });
            MovieContext.Movies.Add(new Movie { Id = 3, Title = "Movie 3", YearOfRelease = 2019, Genre = "Action" });
            MovieContext.SaveChanges();
        }

        public void Dispose()
        {
            MovieContext.Dispose();
        }*/


        private Contexto _context;
        private PerfilesRepositorio _perfilesRepositorio;

        [TestMethod]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<Contexto>().UseInMemoryDatabase("IncidenciasProjecto");
            _context = new Contexto(dbContextOptions.Options);
            _context.Database.EnsureCreated();

            _perfilesRepositorio = new PerfilesRepositorio(_context, null);
        }

        [TestMethod]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        
        public async Task CreaPerfil()
        {
            // Preparación
            var newPerfil = new Perfil
            {
                Id = 0,
                Nombre = "Administrador"
            };

            // Ejecución
            var entityId = await _perfilesRepositorio.Agregar(newPerfil);
            var perfil = await _context.Perfiles.FirstOrDefaultAsync(c => c.Id == entityId.Id);

            // Verificación
            Assert.AreEqual(newPerfil.Nombre, perfil.Nombre);
        }
    }
}