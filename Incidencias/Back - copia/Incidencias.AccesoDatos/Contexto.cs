using Incidencias.Modelos;
using Incidencias.Modelos.Enum;
using Microsoft.EntityFrameworkCore;
using System;

namespace Incidencias.AccesoDatos
{
    public partial class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opciones) : base(opciones)
        {
        }
        public virtual DbSet<Perfil> Perfiles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuariosProyectos> UsuariosProyectos { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Incidencia> Incidencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            AgregarPerfiles(modelBuilder);
            AgregarUsuarios(modelBuilder);
            AgregarProyectos(modelBuilder);
            AgregarUsuariosProyectos(modelBuilder);
            AgregarIncidencias(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void AgregarPerfiles(ModelBuilder builder)
        {
            builder.Entity<Perfil>().HasData(new Perfil() { Id = (int)TipPerfil.Administrador, Nombre = "Administrador" });
            builder.Entity<Perfil>().HasData(new Perfil() { Id = (int)TipPerfil.Desarrollador, Nombre = "Desarrollador" });
            builder.Entity<Perfil>().HasData(new Perfil() { Id = (int)TipPerfil.Tester, Nombre = "Tester" });
        }

        private void AgregarUsuarios(ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 1, Nombre = "Agustina", Apellidos = "Somma", Email = "agustina@gsoft.com.uy", Username = "agustina", Password = "AQAAAAEAACcQAAAAEPJ3eDQ+/KM98+2ezT+bdj/AVVy9AgvIDfeFcwLACyl8Xx9n6Z8PDxyWgU/ea2PaGg==", PerfilId = (int)TipPerfil.Administrador, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 2, Nombre = "Viviana", Apellidos = "Valente", Email = "viviana@gsoft.com.uy", Username = "viviana", Password = "AQAAAAEAACcQAAAAEMy3YQfQdwes/BqOqePlK/BJD7BZYWQqZg6Yj3m2V5EsgByW1/NfrqCWeUBLg7V3bw==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 3, Nombre = "Maria", Apellidos = "Lopez", Email = "maria@gsoft.com.uy", Username = "maria", Password = "AQAAAAEAACcQAAAAEBX72IRr5qgnJMxFPoqCs84fycEJ4AzZ2XD9UOKtoGpgO2Gs6CIiRj3Oqp5/HMeZjA==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 4, Nombre = "Pedro", Apellidos = "Martinez", Email = "pedro@gsoft.com.uy", Username = "pedro", Password = "AQAAAAEAACcQAAAAEM1iOjAS1temRkV5aBawLp/25jvLduRRT8Slq4NS7O1mflpPnKPIHwGgbZXth0ArxA==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 5, Nombre = "Juan", Apellidos = "Perez", Email = "juan@gsoft.com.uy", Username = "juan", Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 6, Nombre = "Silvina", Apellidos = "Perez", Email = "silvina@gsoft.com.uy", Username = "silvina", Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo });
        }

        private void AgregarProyectos(ModelBuilder builder)
        {
            builder.Entity<Proyecto>().HasData(new Proyecto() { Id = 1, Nombre = "Facturacion", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo });
            builder.Entity<Proyecto>().HasData(new Proyecto() { Id = 2, Nombre = "Financiero", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo });
            builder.Entity<Proyecto>().HasData(new Proyecto() { Id = 3, Nombre = "Salud", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo });
        }

        private void AgregarUsuariosProyectos(ModelBuilder builder)
        {

            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 1, FechaRegistro = DateTime.Now, ProyectoId = 1, UsuarioId = 1 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 2, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 2 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 3, FechaRegistro = DateTime.Now, ProyectoId = 3, UsuarioId = 5 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 4, FechaRegistro = DateTime.Now, ProyectoId = 1, UsuarioId = 2 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 5, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 2 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 6, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 3 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 7, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 4 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 8, FechaRegistro = DateTime.Now, ProyectoId = 2, UsuarioId = 5 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 9, FechaRegistro = DateTime.Now, ProyectoId = 3, UsuarioId = 1 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 10, FechaRegistro = DateTime.Now, ProyectoId = 3, UsuarioId = 4 });
            builder.Entity<UsuariosProyectos>().HasData(new UsuariosProyectos() { Id = 11, FechaRegistro = DateTime.Now, ProyectoId = 3, UsuarioId = 5 });
        }

        private void AgregarIncidencias(ModelBuilder builder)
        {
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 1, Nombre = "incidencia a", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 2, Nombre = "incidencia b", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 3, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 3, Nombre = "incidencia c", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 4, Nombre = "incidencia ad", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 5, Nombre = "incidencia e", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 6, Nombre = "incidencia df", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 7, Nombre = "incidencia 1", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 8, Nombre = "incidencia 40", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 9, Nombre = "incidencia g", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 10, Nombre = "incidencia 564", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 11, Nombre = "incidencia d1f", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 3, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 12, Nombre = "incidencia ol", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 13, Nombre = "incidencia aew", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 14, Nombre = "incidencia afw", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 15, Nombre = "incidencia aww", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 16, Nombre = "incidencia a598", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 17, Nombre = "incidencia a369", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 18, Nombre = "incidencia a963", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 19, Nombre = "incidencia a1244", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 20, Nombre = "incidencia 74568", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 21, Nombre = "incidencia carro", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 22, Nombre = "incidencia tejado", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 23, Nombre = "incidencia politico", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 24, Nombre = "incidencia casa", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 25, Nombre = "incidencia tes", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5 });
        }
    }
}