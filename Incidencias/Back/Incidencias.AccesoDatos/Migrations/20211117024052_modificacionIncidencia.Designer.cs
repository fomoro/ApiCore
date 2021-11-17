﻿// <auto-generated />
using System;
using Incidencias.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Incidencias.AccesoDatos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211117024052_modificacionIncidencia")]
    partial class modificacionIncidencia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Incidencias.Modelos.Incidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DesarrolladorId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<int>("EstatusIncidencia")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("TesterId")
                        .HasColumnType("int");

                    b.Property<float>("Version")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Incidencias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia a",
                            ProyectoId = 1,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 2,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia b",
                            ProyectoId = 1,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 3,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia c",
                            ProyectoId = 1,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 4,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia ad",
                            ProyectoId = 1,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 5,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia e",
                            ProyectoId = 1,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 6,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia df",
                            ProyectoId = 1,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 7,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia 1",
                            ProyectoId = 1,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 8,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia 40",
                            ProyectoId = 1,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 9,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia g",
                            ProyectoId = 2,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 10,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia 564",
                            ProyectoId = 2,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 11,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia d1f",
                            ProyectoId = 2,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 12,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia ol",
                            ProyectoId = 2,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 13,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia aew",
                            ProyectoId = 2,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 14,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia afw",
                            ProyectoId = 2,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 15,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia aww",
                            ProyectoId = 3,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 16,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia a598",
                            ProyectoId = 3,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 17,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia a369",
                            ProyectoId = 3,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 18,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia a963",
                            ProyectoId = 3,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 19,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia a1244",
                            ProyectoId = 3,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 20,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia 74568",
                            ProyectoId = 3,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 21,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia carro",
                            ProyectoId = 2,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 22,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia tejado",
                            ProyectoId = 2,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 23,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia politico",
                            ProyectoId = 2,
                            TesterId = 5,
                            Version = 1f
                        },
                        new
                        {
                            Id = 24,
                            DesarrolladorId = 3,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 1,
                            Nombre = "incidencia casa",
                            ProyectoId = 2,
                            TesterId = 6,
                            Version = 1f
                        },
                        new
                        {
                            Id = 25,
                            DesarrolladorId = 2,
                            Descripcion = " carreta ",
                            Duracion = 0,
                            EstatusIncidencia = 2,
                            Nombre = "incidencia tes",
                            ProyectoId = 2,
                            TesterId = 5,
                            Version = 1f
                        });
                });

            modelBuilder.Entity("Incidencias.Modelos.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Desarrollador"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Tester"
                        });
                });

            modelBuilder.Entity("Incidencias.Modelos.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstatusProyecto")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proyectos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EstatusProyecto = 1,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 60, DateTimeKind.Local).AddTicks(1569),
                            Nombre = "Facturacion"
                        },
                        new
                        {
                            Id = 2,
                            EstatusProyecto = 1,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 60, DateTimeKind.Local).AddTicks(9682),
                            Nombre = "Financiero"
                        },
                        new
                        {
                            Id = 3,
                            EstatusProyecto = 1,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 60, DateTimeKind.Local).AddTicks(9716),
                            Nombre = "Salud"
                        });
                });

            modelBuilder.Entity("Incidencias.Modelos.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("Incidencias.Modelos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CostoHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estatus")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Somma",
                            CostoHora = 0m,
                            Email = "agustina@gsoft.com.uy",
                            Estatus = 1,
                            Nombre = "Agustina",
                            Password = "AQAAAAEAACcQAAAAEPJ3eDQ+/KM98+2ezT+bdj/AVVy9AgvIDfeFcwLACyl8Xx9n6Z8PDxyWgU/ea2PaGg==",
                            PerfilId = 1,
                            Username = "agustina"
                        },
                        new
                        {
                            Id = 2,
                            Apellidos = "Valente",
                            CostoHora = 0m,
                            Email = "viviana@gsoft.com.uy",
                            Estatus = 1,
                            Nombre = "Viviana",
                            Password = "AQAAAAEAACcQAAAAEMy3YQfQdwes/BqOqePlK/BJD7BZYWQqZg6Yj3m2V5EsgByW1/NfrqCWeUBLg7V3bw==",
                            PerfilId = 2,
                            Username = "viviana"
                        },
                        new
                        {
                            Id = 3,
                            Apellidos = "Lopez",
                            CostoHora = 0m,
                            Email = "maria@gsoft.com.uy",
                            Estatus = 1,
                            Nombre = "Maria",
                            Password = "AQAAAAEAACcQAAAAEBX72IRr5qgnJMxFPoqCs84fycEJ4AzZ2XD9UOKtoGpgO2Gs6CIiRj3Oqp5/HMeZjA==",
                            PerfilId = 2,
                            Username = "maria"
                        },
                        new
                        {
                            Id = 4,
                            Apellidos = "Martinez",
                            CostoHora = 0m,
                            Email = "pedro@gsoft.com.uy",
                            Estatus = 1,
                            Nombre = "Pedro",
                            Password = "AQAAAAEAACcQAAAAEM1iOjAS1temRkV5aBawLp/25jvLduRRT8Slq4NS7O1mflpPnKPIHwGgbZXth0ArxA==",
                            PerfilId = 2,
                            Username = "pedro"
                        },
                        new
                        {
                            Id = 5,
                            Apellidos = "Perez",
                            CostoHora = 0m,
                            Email = "juan@gsoft.com.uy",
                            Estatus = 1,
                            Nombre = "Juan",
                            Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==",
                            PerfilId = 3,
                            Username = "juan"
                        },
                        new
                        {
                            Id = 6,
                            Apellidos = "Perez",
                            CostoHora = 0m,
                            Email = "silvina@gsoft.com.uy",
                            Estatus = 1,
                            Nombre = "Silvina",
                            Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==",
                            PerfilId = 3,
                            Username = "silvina"
                        });
                });

            modelBuilder.Entity("Incidencias.Modelos.UsuariosProyectos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosProyectos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(5216),
                            ProyectoId = 1,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6099),
                            ProyectoId = 2,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 3,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6123),
                            ProyectoId = 3,
                            UsuarioId = 5
                        },
                        new
                        {
                            Id = 4,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6138),
                            ProyectoId = 1,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 5,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6152),
                            ProyectoId = 2,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 6,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6168),
                            ProyectoId = 2,
                            UsuarioId = 3
                        },
                        new
                        {
                            Id = 7,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6182),
                            ProyectoId = 2,
                            UsuarioId = 4
                        },
                        new
                        {
                            Id = 8,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6195),
                            ProyectoId = 2,
                            UsuarioId = 5
                        },
                        new
                        {
                            Id = 9,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6209),
                            ProyectoId = 3,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 10,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6224),
                            ProyectoId = 3,
                            UsuarioId = 4
                        },
                        new
                        {
                            Id = 11,
                            FechaRegistro = new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6238),
                            ProyectoId = 3,
                            UsuarioId = 5
                        });
                });

            modelBuilder.Entity("Incidencias.Modelos.Incidencia", b =>
                {
                    b.HasOne("Incidencias.Modelos.Proyecto", "Proyecto")
                        .WithMany("Incidencias")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("Incidencias.Modelos.Tarea", b =>
                {
                    b.HasOne("Incidencias.Modelos.Proyecto", "Proyecto")
                        .WithMany("Tareas")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("Incidencias.Modelos.Usuario", b =>
                {
                    b.HasOne("Incidencias.Modelos.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("Incidencias.Modelos.UsuariosProyectos", b =>
                {
                    b.HasOne("Incidencias.Modelos.Proyecto", "Proyecto")
                        .WithMany("UsuariosProyectos")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Incidencias.Modelos.Usuario", "Usuario")
                        .WithMany("UsuariosProyectos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Incidencias.Modelos.Perfil", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Incidencias.Modelos.Proyecto", b =>
                {
                    b.Navigation("Incidencias");

                    b.Navigation("Tareas");

                    b.Navigation("UsuariosProyectos");
                });

            modelBuilder.Entity("Incidencias.Modelos.Usuario", b =>
                {
                    b.Navigation("UsuariosProyectos");
                });
#pragma warning restore 612, 618
        }
    }
}
