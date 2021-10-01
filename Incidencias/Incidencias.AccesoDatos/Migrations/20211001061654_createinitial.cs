using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidencias.AccesoDatos.Migrations
{
    public partial class createinitial : Migration
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
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstatusIncidencia = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<float>(type: "real", nullable: false)
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
                    { 1, 1, null, new DateTime(2021, 10, 1, 1, 16, 54, 186, DateTimeKind.Local).AddTicks(6832), "Alpina" },
                    { 2, 1, null, new DateTime(2021, 10, 1, 1, 16, 54, 187, DateTimeKind.Local).AddTicks(5104), "Bavaria" },
                    { 3, 1, null, new DateTime(2021, 10, 1, 1, 16, 54, 187, DateTimeKind.Local).AddTicks(5135), "Postobon" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Estatus", "Nombre", "Password", "PerfilId", "Username" },
                values: new object[,]
                {
                    { 1, "Somma", "agustina.somma@gsoft.com.uy", 1, "Agustina", null, 1, null },
                    { 2, "Valente", "valente@gsoft.com.uy", 1, "Viviana", null, 2, null },
                    { 3, "Wolfan", "valente@gsoft.com.uy", 1, "Jonathan", null, 2, null },
                    { 4, "Rozo", "valente@gsoft.com.uy", 1, "Ingri", null, 2, null },
                    { 5, "Perez", "test@gsoft.com.uy", 1, "Juan", null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "UsuariosProyectos",
                columns: new[] { "Id", "FechaRegistro", "ProyectoId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(1766), 1, 1 },
                    { 9, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2675), 3, 1 },
                    { 2, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2568), 2, 2 },
                    { 4, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2605), 1, 2 },
                    { 5, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2618), 2, 2 },
                    { 6, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2637), 2, 3 },
                    { 7, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2650), 2, 4 },
                    { 10, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2690), 3, 4 },
                    { 3, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2590), 3, 5 },
                    { 8, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2662), 2, 5 },
                    { 11, new DateTime(2021, 10, 1, 1, 16, 54, 188, DateTimeKind.Local).AddTicks(2703), 3, 5 }
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
