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
    [Migration("20211006020712_MigracionInicial")]
    partial class MigracionInicial
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

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstatusIncidencia")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProyectoId")
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
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia a",
                            ProyectoId = 1,
                            Version = 1f
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia b",
                            ProyectoId = 1,
                            Version = 1f
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia c",
                            ProyectoId = 1,
                            Version = 1f
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia ad",
                            ProyectoId = 1,
                            Version = 1f
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia e",
                            ProyectoId = 1,
                            Version = 1f
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia df",
                            ProyectoId = 1,
                            Version = 1f
                        },
                        new
                        {
                            Id = 7,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia 1",
                            ProyectoId = 1,
                            Version = 1f
                        },
                        new
                        {
                            Id = 8,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia 40",
                            ProyectoId = 1,
                            Version = 1f
                        },
                        new
                        {
                            Id = 9,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia g",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 10,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia 564",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 11,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia d1f",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 12,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia ol",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 13,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia aew",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 14,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia afw",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 15,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia aww",
                            ProyectoId = 3,
                            Version = 1f
                        },
                        new
                        {
                            Id = 16,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia a598",
                            ProyectoId = 3,
                            Version = 1f
                        },
                        new
                        {
                            Id = 17,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia a369",
                            ProyectoId = 3,
                            Version = 1f
                        },
                        new
                        {
                            Id = 18,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia a963",
                            ProyectoId = 3,
                            Version = 1f
                        },
                        new
                        {
                            Id = 19,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia a1244",
                            ProyectoId = 3,
                            Version = 1f
                        },
                        new
                        {
                            Id = 20,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia 74568",
                            ProyectoId = 3,
                            Version = 1f
                        },
                        new
                        {
                            Id = 21,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia carro",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 22,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia tejado",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 23,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia politico",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 24,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia casa",
                            ProyectoId = 2,
                            Version = 1f
                        },
                        new
                        {
                            Id = 25,
                            Descripcion = " carreta ",
                            EstatusIncidencia = 1,
                            Nombre = "incidencia tes",
                            ProyectoId = 2,
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
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 945, DateTimeKind.Local).AddTicks(9478),
                            Nombre = "Facturacion"
                        },
                        new
                        {
                            Id = 2,
                            EstatusProyecto = 1,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 947, DateTimeKind.Local).AddTicks(679),
                            Nombre = "Financiero"
                        },
                        new
                        {
                            Id = 3,
                            EstatusProyecto = 1,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 947, DateTimeKind.Local).AddTicks(734),
                            Nombre = "Salud"
                        });
                });

            modelBuilder.Entity("Incidencias.Modelos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

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
                            Email = "juan@gsoft.com.uy",
                            Estatus = 1,
                            Nombre = "Juan",
                            Password = "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==",
                            PerfilId = 3,
                            Username = "juan"
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
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(446),
                            ProyectoId = 1,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(1947),
                            ProyectoId = 2,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 3,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(1983),
                            ProyectoId = 3,
                            UsuarioId = 5
                        },
                        new
                        {
                            Id = 4,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(2007),
                            ProyectoId = 1,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 5,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(2030),
                            ProyectoId = 2,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 6,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(2058),
                            ProyectoId = 2,
                            UsuarioId = 3
                        },
                        new
                        {
                            Id = 7,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(2080),
                            ProyectoId = 2,
                            UsuarioId = 4
                        },
                        new
                        {
                            Id = 8,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(2103),
                            ProyectoId = 2,
                            UsuarioId = 5
                        },
                        new
                        {
                            Id = 9,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(2126),
                            ProyectoId = 3,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 10,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(2153),
                            ProyectoId = 3,
                            UsuarioId = 4
                        },
                        new
                        {
                            Id = 11,
                            FechaRegistro = new DateTime(2021, 10, 5, 21, 7, 11, 948, DateTimeKind.Local).AddTicks(2177),
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
