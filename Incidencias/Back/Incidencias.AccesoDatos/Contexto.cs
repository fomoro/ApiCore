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
        public virtual DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            AgregarPerfiles(modelBuilder);
            AgregarUsuarios(modelBuilder);
            AgregarProyectos(modelBuilder);
            AgregarUsuariosProyectos(modelBuilder);
            AgregarTareasProyectos(modelBuilder);
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
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 2, Nombre = "Viviana", Apellidos = "Valente", Email = "viviana@gsoft.com.uy", Username = "viviana", Password = "AQAAAAEAACcQAAAAEMy3YQfQdwes/BqOqePlK/BJD7BZYWQqZg6Yj3m2V5EsgByW1/NfrqCWeUBLg7V3bw==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo, CostoHora = 1000 });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 3, Nombre = "Maria", Apellidos = "Lopez", Email = "maria@gsoft.com.uy", Username = "maria", Password = "AQAAAAEAACcQAAAAEBX72IRr5qgnJMxFPoqCs84fycEJ4AzZ2XD9UOKtoGpgO2Gs6CIiRj3Oqp5/HMeZjA==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo, CostoHora = 1900 });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 4, Nombre = "Pedro", Apellidos = "Martinez", Email = "pedro@gsoft.com.uy", Username = "pedro", Password = "AQAAAAEAACcQAAAAEM1iOjAS1temRkV5aBawLp/25jvLduRRT8Slq4NS7O1mflpPnKPIHwGgbZXth0ArxA==", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo, CostoHora = 1800 });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 5, Nombre = "Juan", Apellidos = "Perez", Email = "juan@gsoft.com.uy", Username = "juan", Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo, CostoHora = 1400 });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 6, Nombre = "Silvina", Apellidos = "Perez", Email = "silvina@gsoft.com.uy", Username = "silvina", Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo, CostoHora = 1300 });
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

        private void AgregarTareasProyectos(ModelBuilder builder)
        {
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 1, Nombre = "Tarea a", Costo = 100, Duracion = 1, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 2, Nombre = "Tarea b", Costo = 300, Duracion = 2, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 3, Nombre = "Tarea c", Costo = 200, Duracion = 3, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 4, Nombre = "Tarea d", Costo = 30, Duracion = 4, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 5, Nombre = "Tarea e", Costo = 50, Duracion = 5, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 6, Nombre = "Tarea f", Costo = 120, Duracion = 10, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 7, Nombre = "Tarea g", Costo = 130, Duracion = 11, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 8, Nombre = "Tarea h", Costo = 560, Duracion = 4, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 9, Nombre = "Tarea i", Costo = 60, Duracion = 3, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 10, Nombre = "Tarea j", Costo = 110, Duracion = 2, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 11, Nombre = "Tarea k", Costo = 210, Duracion = 5, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 12, Nombre = "Tarea l", Costo = 250, Duracion = 1, ProyectoId = 1 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 13, Nombre = "Tarea 11", Costo = 60, Duracion = 11, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 14, Nombre = "Tarea 12", Costo = 710, Duracion = 2, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 15, Nombre = "Tarea 13", Costo = 80, Duracion = 3, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 16, Nombre = "Tarea 14", Costo = 920, Duracion = 31, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 17, Nombre = "Tarea 15", Costo = 30, Duracion = 15, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 18, Nombre = "Tarea 16", Costo = 130, Duracion = 11, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 19, Nombre = "Tarea 17", Costo = 120, Duracion = 10, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 20, Nombre = "Tarea 18", Costo = 990, Duracion = 8, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 21, Nombre = "Tarea 19", Costo = 880, Duracion = 7, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 22, Nombre = "Tarea 20", Costo = 770, Duracion = 6, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 23, Nombre = "Tarea 21", Costo = 660, Duracion = 5, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 24, Nombre = "Tarea 22", Costo = 550, Duracion = 1, ProyectoId = 2 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 25, Nombre = "Tarea a1", Costo = 10, Duracion = 2, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 26, Nombre = "Tarea a2", Costo = 10, Duracion = 3, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 27, Nombre = "Tarea a3", Costo = 10, Duracion = 14, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 28, Nombre = "Tarea a4", Costo = 10, Duracion = 15, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 29, Nombre = "Tarea a5", Costo = 10, Duracion = 11, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 30, Nombre = "Tarea a6", Costo = 10, Duracion = 10, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 31, Nombre = "Tarea a7", Costo = 10, Duracion = 9, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 32, Nombre = "Tarea a8", Costo = 10, Duracion = 8, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 33, Nombre = "Tarea a9", Costo = 10, Duracion = 7, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 34, Nombre = "Tarea b1", Costo = 10, Duracion = 6, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 35, Nombre = "Tarea b2", Costo = 10, Duracion = 1, ProyectoId = 3 });
            builder.Entity<Tarea>().HasData(new Tarea() { Id = 36, Nombre = "Tarea b3", Costo = 10, Duracion = 4, ProyectoId = 3 });
        }

        private void AgregarIncidencias(ModelBuilder builder)
        {
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 1, Nombre = "incidencia a", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5, Duracion = 2 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 2, Nombre = "incidencia b", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 3, TesterId = 5, Duracion = 3 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 3, Nombre = "incidencia c", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 5, Duracion = 4 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 4, Nombre = "incidencia ad", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6, Duracion = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 5, Nombre = "incidencia e", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6, Duracion = 1 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 6, Nombre = "incidencia df", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6, Duracion = 3 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 7, Nombre = "incidencia 1", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 6, Duracion = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 8, Nombre = "incidencia 40", Descripcion = " carreta ", ProyectoId = 1, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6, Duracion = 8 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 9, Nombre = "incidencia g", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6, Duracion = 2 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 10, Nombre = "incidencia 564", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6, Duracion = 4 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 11, Nombre = "incidencia d1f", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 3, TesterId = 6, Duracion = 3 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 12, Nombre = "incidencia ol", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6, Duracion = 4 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 13, Nombre = "incidencia aew", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 5, Duracion = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 14, Nombre = "incidencia afw", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5, Duracion = 7 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 15, Nombre = "incidencia aww", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5, Duracion = 8 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 16, Nombre = "incidencia a598", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5, Duracion = 1 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 17, Nombre = "incidencia a369", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5, Duracion = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 18, Nombre = "incidencia a963", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 5, Duracion = 6 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 19, Nombre = "incidencia a1244", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5, Duracion = 7 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 20, Nombre = "incidencia 74568", Descripcion = " carreta ", ProyectoId = 3, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6, Duracion = 8 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 21, Nombre = "incidencia carro", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 2, TesterId = 6, Duracion = 5 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 22, Nombre = "incidencia tejado", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6, Duracion = 8 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 23, Nombre = "incidencia politico", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5, Duracion = 2 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 24, Nombre = "incidencia casa", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Activo, DesarrolladorId = 3, TesterId = 6, Duracion = 3 });
            builder.Entity<Incidencia>().HasData(new Incidencia() { Id = 25, Nombre = "incidencia tes", Descripcion = " carreta ", ProyectoId = 2, Version = 1, EstatusIncidencia = EstatusIncidencia.Resuelto, DesarrolladorId = 2, TesterId = 5, Duracion = 4 });
        }
    }
}