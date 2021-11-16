using System;
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


            //Creo datos de usuarios
            Usuario agustina = new Usuario() { Id = 1, Nombre = "Agustina", Apellidos = "Somma", Email = "agustina@gsoft.com.uy", Username = "agustina", Password = "AQAAAAEAACcQAAAAEPJ3eDQ+/KM98+2ezT+bdj/AVVy9AgvIDfeFcwLACyl8Xx9n6Z8PDxyWgU/ea2PaGg==", PerfilId = (int)TipPerfil.Administrador, Estatus = EstatusUsuario.Activo };
            Usuario viviana = new Usuario() { Id = 2, Nombre = "Viviana", Apellidos = "Valente", Email = "viviana@gsoft.com.uy", Username = "viviana", Password = "AQAAAAEAACcQAAAAEMy3YQfQdwes/BqOqePlK/BJD7BZYWQqZg6Yj3m2V5EsgByW1/NfrqCWeUBLg7V3bw==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo };
            Usuario maria = new Usuario() { Id = 3, Nombre = "Maria", Apellidos = "Lopez", Email = "maria@gsoft.com.uy", Username = "maria", Password = "AQAAAAEAACcQAAAAEBX72IRr5qgnJMxFPoqCs84fycEJ4AzZ2XD9UOKtoGpgO2Gs6CIiRj3Oqp5/HMeZjA==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo };
            Usuario pedro = new Usuario() { Id = 4, Nombre = "Pedro", Apellidos = "Martinez", Email = "pedro@gsoft.com.uy", Username = "pedro", Password = "AQAAAAEAACcQAAAAEM1iOjAS1temRkV5aBawLp/25jvLduRRT8Slq4NS7O1mflpPnKPIHwGgbZXth0ArxA==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo };
            Usuario juan = new Usuario() { Id = 5, Nombre = "Juan", Apellidos = "Perez", Email = "juan@gsoft.com.uy", Username = "juan", Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo };
            Usuario silvina = new Usuario() { Id = 6, Nombre = "Silvina", Apellidos = "Perez", Email = "silvina@gsoft.com.uy", Username = "silvina", Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo };

            //Relaciono los datos, agregando perfiles a la lista de perfiles de cada usuario
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

            //creo datos de proyectos
            Proyecto facturacion = new Proyecto() { Id = 1, Nombre = "Facturacion", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo};
            Proyecto financiero = new Proyecto() { Id = 2, Nombre = "Financiero", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo};
            Proyecto salud = new Proyecto() { Id = 3, Nombre = "Salud", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo};

            DBContext.Add(facturacion);
            DBContext.Add(financiero);
            DBContext.Add(salud);

            //UsuariosProyectos
            UsuariosProyectos u1 = new UsuariosProyectos() { Id = 1, FechaRegistro = DateTime.Now, ProyectoId = 1, UsuarioId = 1 };
            UsuariosProyectos u2 = new UsuariosProyectos() { Id = 2, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 2 };
            UsuariosProyectos u3 = new UsuariosProyectos() { Id = 3, FechaRegistro = DateTime.Now, ProyectoId = 3, UsuarioId = 5 };
            UsuariosProyectos u4 = new UsuariosProyectos() { Id = 4, FechaRegistro = DateTime.Now, ProyectoId = 1, UsuarioId = 2 };
            UsuariosProyectos u5 = new UsuariosProyectos() { Id = 5, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 2 };
            UsuariosProyectos u6 = new UsuariosProyectos() { Id = 6, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 3 };
            UsuariosProyectos u7 = new UsuariosProyectos() { Id = 7, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 4 };
            UsuariosProyectos u8 = new UsuariosProyectos() { Id = 8, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 5 };
            UsuariosProyectos u9 = new UsuariosProyectos() { Id = 9, FechaRegistro = DateTime.Now, ProyectoId = 3, UsuarioId = 1 };
            UsuariosProyectos u10 = new UsuariosProyectos() { Id = 10, FechaRegistro = DateTime.Now, ProyectoId = 3, UsuarioId = 4 };
            UsuariosProyectos u11 = new UsuariosProyectos() { Id = 11, FechaRegistro = DateTime.Now, ProyectoId = 3, UsuarioId = 5 };

            //creo las incidencias
            Incidencia i1 = new Incidencia() { Id = 1, Nombre = "incidencia a", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 };
            Incidencia i2 = new Incidencia() { Id = 2, Nombre = "incidencia b", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 3, TesterId = 5 };
            Incidencia i3 = new Incidencia() { Id = 3, Nombre = "incidencia c", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 5 };
            Incidencia i4 = new Incidencia() { Id = 4, Nombre = "incidencia ad", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 };
            Incidencia i5 = new Incidencia() { Id = 5, Nombre = "incidencia e", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6 };
            Incidencia i6 = new Incidencia() { Id = 6, Nombre = "incidencia df", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 };
            Incidencia i7 = new Incidencia() { Id = 7, Nombre = "incidencia 1", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 6 };
            Incidencia i8 = new Incidencia() { Id = 8, Nombre = "incidencia 40", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 };
            Incidencia i9 = new Incidencia() { Id = 9, Nombre = "incidencia g", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6 };
            Incidencia i10 = new Incidencia() { Id = 10, Nombre = "incidencia 564", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 };
            Incidencia i11 = new Incidencia() { Id = 11, Nombre = "incidencia d1f", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 3, TesterId = 6 };
            Incidencia i12 = new Incidencia() { Id = 12, Nombre = "incidencia ol", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6 };
            Incidencia i13 = new Incidencia() { Id = 13, Nombre = "incidencia aew", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 5 };
            Incidencia i14 = new Incidencia() { Id = 14, Nombre = "incidencia afw", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5 };
            Incidencia i15 = new Incidencia() { Id = 15, Nombre = "incidencia aww", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 };
            Incidencia i16 = new Incidencia() { Id = 16, Nombre = "incidencia a598", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5 };
            Incidencia i17 = new Incidencia() { Id = 17, Nombre = "incidencia a369", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 };
            Incidencia i18 = new Incidencia() { Id = 18, Nombre = "incidencia a963", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5 };
            Incidencia i19 = new Incidencia() { Id = 19, Nombre = "incidencia a1244", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 };
            Incidencia i20 = new Incidencia() { Id = 20, Nombre = "incidencia 74568", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 };
            Incidencia i21 = new Incidencia() { Id = 21, Nombre = "incidencia carro", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6 };
            Incidencia i22 = new Incidencia() { Id = 22, Nombre = "incidencia tejado", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 };
            Incidencia i23 = new Incidencia() { Id = 23, Nombre = "incidencia politico", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 };
            Incidencia i24 = new Incidencia() { Id = 24, Nombre = "incidencia casa", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 };
            Incidencia i25 = new Incidencia() { Id = 25, Nombre = "incidencia tes", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 };

            DBContext.SaveChanges();
        }

        protected void CleanupInMemoryDatabase()
        {
            DBContext.Database.EnsureDeleted();
        }

    }
}
