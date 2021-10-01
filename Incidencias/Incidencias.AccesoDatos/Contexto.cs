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
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 1, Nombre = "Agustina", Apellidos = "Somma", Email = "agustina.somma@gsoft.com.uy", PerfilId = (int)TipPerfil.Administrador, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 2, Nombre = "Viviana", Apellidos = "Valente", Email = "valente@gsoft.com.uy", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 3, Nombre = "Jonathan", Apellidos = "Wolfan", Email = "valente@gsoft.com.uy", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 4, Nombre = "Ingri", Apellidos = "Rozo", Email = "valente@gsoft.com.uy", PerfilId = (int)TipPerfil.Desarrollador, Estatus = EstatusUsuario.Activo });
            builder.Entity<Usuario>().HasData(new Usuario() { Id = 5, Nombre = "Juan", Apellidos = "Perez", Email = "test@gsoft.com.uy", PerfilId = (int)TipPerfil.Tester, Estatus = EstatusUsuario.Activo });
        }

        private void AgregarProyectos(ModelBuilder builder)
        {
            builder.Entity<Proyecto>().HasData(new Proyecto() { Id = 1, Nombre = "Alpina", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo });
            builder.Entity<Proyecto>().HasData(new Proyecto() { Id = 2, Nombre = "Bavaria", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo });
            builder.Entity<Proyecto>().HasData(new Proyecto() { Id = 3, Nombre = "Postobon", FechaRegistro = DateTime.Now, EstatusProyecto = EstatusProyecto.Activo });
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

    }
}