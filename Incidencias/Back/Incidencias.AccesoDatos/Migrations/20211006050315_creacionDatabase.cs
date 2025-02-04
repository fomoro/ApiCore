﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidencias.AccesoDatos.Migrations
{
    public partial class creacionDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstatusProyecto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstatusIncidencia = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<float>(type: "real", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    DesarrolladorId = table.Column<int>(type: "int", nullable: false),
                    TesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidencias_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosProyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosProyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosProyectos_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosProyectos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Perfiles",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Desarrollador" },
                    { 3, "Tester" }
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "EstatusProyecto", "FechaActualizacion", "FechaRegistro", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2021, 10, 6, 0, 3, 14, 619, DateTimeKind.Local).AddTicks(7716), "Facturacion" },
                    { 2, 1, null, new DateTime(2021, 10, 6, 0, 3, 14, 620, DateTimeKind.Local).AddTicks(5099), "Financiero" },
                    { 3, 1, null, new DateTime(2021, 10, 6, 0, 3, 14, 620, DateTimeKind.Local).AddTicks(5133), "Salud" }
                });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "DesarrolladorId", "Descripcion", "EstatusIncidencia", "Nombre", "ProyectoId", "TesterId", "Version" },
                values: new object[,]
                {
                    { 10, 2, " carreta ", 1, "incidencia 564", 2, 3, 1f },
                    { 18, 2, " carreta ", 1, "incidencia a963", 3, 3, 1f },
                    { 17, 2, " carreta ", 1, "incidencia a369", 3, 3, 1f },
                    { 16, 2, " carreta ", 1, "incidencia a598", 3, 3, 1f },
                    { 15, 2, " carreta ", 1, "incidencia aww", 3, 3, 1f },
                    { 25, 2, " carreta ", 1, "incidencia tes", 2, 3, 1f },
                    { 24, 2, " carreta ", 1, "incidencia casa", 2, 3, 1f },
                    { 23, 2, " carreta ", 1, "incidencia politico", 2, 3, 1f },
                    { 22, 2, " carreta ", 1, "incidencia tejado", 2, 3, 1f },
                    { 21, 2, " carreta ", 1, "incidencia carro", 2, 3, 1f },
                    { 14, 2, " carreta ", 1, "incidencia afw", 2, 3, 1f },
                    { 13, 2, " carreta ", 1, "incidencia aew", 2, 3, 1f },
                    { 12, 2, " carreta ", 1, "incidencia ol", 2, 3, 1f },
                    { 11, 2, " carreta ", 1, "incidencia d1f", 2, 3, 1f },
                    { 20, 2, " carreta ", 1, "incidencia 74568", 3, 3, 1f },
                    { 9, 2, " carreta ", 1, "incidencia g", 2, 3, 1f },
                    { 8, 2, " carreta ", 1, "incidencia 40", 1, 3, 1f },
                    { 7, 2, " carreta ", 1, "incidencia 1", 1, 3, 1f },
                    { 6, 2, " carreta ", 1, "incidencia df", 1, 3, 1f },
                    { 5, 2, " carreta ", 1, "incidencia e", 1, 3, 1f },
                    { 4, 2, " carreta ", 1, "incidencia ad", 1, 3, 1f },
                    { 3, 2, " carreta ", 1, "incidencia c", 1, 3, 1f },
                    { 2, 2, " carreta ", 1, "incidencia b", 1, 3, 1f },
                    { 1, 2, " carreta ", 1, "incidencia a", 1, 3, 1f },
                    { 19, 2, " carreta ", 1, "incidencia a1244", 3, 3, 1f }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Estatus", "Nombre", "Password", "PerfilId", "Username" },
                values: new object[,]
                {
                    { 5, "Perez", "juan@gsoft.com.uy", 1, "Juan", "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", 3, "juan" },
                    { 4, "Martinez", "pedro@gsoft.com.uy", 1, "Pedro", "AQAAAAEAACcQAAAAEM1iOjAS1temRkV5aBawLp/25jvLduRRT8Slq4NS7O1mflpPnKPIHwGgbZXth0ArxA==", 2, "pedro" },
                    { 3, "Lopez", "maria@gsoft.com.uy", 1, "Maria", "AQAAAAEAACcQAAAAEBX72IRr5qgnJMxFPoqCs84fycEJ4AzZ2XD9UOKtoGpgO2Gs6CIiRj3Oqp5/HMeZjA==", 2, "maria" },
                    { 2, "Valente", "viviana@gsoft.com.uy", 1, "Viviana", "AQAAAAEAACcQAAAAEMy3YQfQdwes/BqOqePlK/BJD7BZYWQqZg6Yj3m2V5EsgByW1/NfrqCWeUBLg7V3bw==", 2, "viviana" },
                    { 1, "Somma", "agustina@gsoft.com.uy", 1, "Agustina", "AQAAAAEAACcQAAAAEPJ3eDQ+/KM98+2ezT+bdj/AVVy9AgvIDfeFcwLACyl8Xx9n6Z8PDxyWgU/ea2PaGg==", 1, "agustina" }
                });

            migrationBuilder.InsertData(
                table: "UsuariosProyectos",
                columns: new[] { "Id", "FechaRegistro", "ProyectoId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(610), 1, 1 },
                    { 9, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1541), 3, 1 },
                    { 2, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1432), 2, 2 },
                    { 4, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1470), 1, 2 },
                    { 5, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1484), 2, 2 },
                    { 6, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1501), 2, 3 },
                    { 7, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1515), 2, 4 },
                    { 10, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1556), 3, 4 },
                    { 3, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1455), 3, 5 },
                    { 8, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1528), 2, 5 },
                    { 11, new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1569), 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_ProyectoId",
                table: "Incidencias",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosProyectos_ProyectoId",
                table: "UsuariosProyectos",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosProyectos_UsuarioId",
                table: "UsuariosProyectos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "UsuariosProyectos");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perfiles");
        }
    }
}
