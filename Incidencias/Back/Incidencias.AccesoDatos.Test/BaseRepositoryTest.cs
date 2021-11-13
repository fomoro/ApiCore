using Incidencias.Modelos;
using Incidencias.Modelos.Enum;
using Microsoft.EntityFrameworkCore;

namespace Incidencias.AccesoDatos.Test
{
    public class BaseRepositoryTest
    {
        protected Contexto DBContext
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
            var options = new DbContextOptionsBuilder<Contexto>().UseInMemoryDatabase(databaseName: "IncidenciasAdmin").Options;
            DBContext = new Contexto(options);


            //creo datos de perfiles
            Perfil administrador = new Perfil() { Id = (int)TipPerfil.Administrador, Nombre = "Administrador" };
            Perfil desarrollador = new Perfil() { Id = (int)TipPerfil.Desarrollador, Nombre = "Desarrollador" };
            Perfil tester = new Perfil() { Id = (int)TipPerfil.Tester, Nombre = "Tester" };


            //Creo datos de cursos
            Usuario agustina = new Usuario() { Id = 1, Nombre = "Agustina", Apellidos = "Somma", Email = "agustina@gsoft.com.uy", Username = "agustina", Password = "AQAAAAEAACcQAAAAEPJ3eDQ+/KM98+2ezT+bdj/AVVy9AgvIDfeFcwLACyl8Xx9n6Z8PDxyWgU/ea2PaGg==", PerfilId = (int)TipPerfil.Administrador, Estatus = EstatusUsuario.Activo };
            Usuario viviana = new Usuario() { Id = 2, Nombre = "Viviana", Apellidos = "Valente", Email = "viviana@gsoft.com.uy", Username = "viviana", Password = "AQAAAAEAACcQAAAAEMy3YQfQdwes/BqOqePlK/BJD7BZYWQqZg6Yj3m2V5EsgByW1/NfrqCWeUBLg7V3bw==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo };
            Usuario maria = new Usuario() { Id = 3, Nombre = "Maria", Apellidos = "Lopez", Email = "maria@gsoft.com.uy", Username = "maria", Password = "AQAAAAEAACcQAAAAEBX72IRr5qgnJMxFPoqCs84fycEJ4AzZ2XD9UOKtoGpgO2Gs6CIiRj3Oqp5/HMeZjA==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo };
            Usuario pedro = new Usuario() { Id = 4, Nombre = "Pedro", Apellidos = "Martinez", Email = "pedro@gsoft.com.uy", Username = "pedro", Password = "AQAAAAEAACcQAAAAEM1iOjAS1temRkV5aBawLp/25jvLduRRT8Slq4NS7O1mflpPnKPIHwGgbZXth0ArxA==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo };
            Usuario juan = new Usuario() { Id = 5, Nombre = "Juan", Apellidos = "Perez", Email = "juan@gsoft.com.uy", Username = "juan", Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo };
            Usuario silvina = new Usuario() { Id = 6, Nombre = "Silvina", Apellidos = "Perez", Email = "silvina@gsoft.com.uy", Username = "silvina", Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo };

            //Relaciono los datos, agregando cursos a la lista de cursos de cada estudiante
            //Como tengo una relacion N a N, tambien podria hacerlo al reves!
            administrador.Usuarios.Add(agustina);
            desarrollador.Usuarios.Add(viviana);
            desarrollador.Usuarios.Add(maria);
            desarrollador.Usuarios.Add(pedro);
            tester.Usuarios.Add(juan);
            tester.Usuarios.Add(silvina);

            DBContext.Add(administrador);
            DBContext.Add(desarrollador);
            DBContext.Add(tester);

            DBContext.SaveChanges();
        }

        protected void CleanupInMemoryDatabase()
        {
            DBContext.Database.EnsureDeleted();
        }

    }
}
