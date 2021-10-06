using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidencias.AccesoDatos.Migrations
{
    public partial class createInitial : Migration
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
                    { 1, 1, null, new DateTime(2021, 10, 3, 21, 55, 8, 855, DateTimeKind.Local).AddTicks(9072), "Alpina" },
                    { 2, 1, null, new DateTime(2021, 10, 3, 21, 55, 8, 856, DateTimeKind.Local).AddTicks(6539), "Bavaria" },
                    { 3, 1, null, new DateTime(2021, 10, 3, 21, 55, 8, 856, DateTimeKind.Local).AddTicks(6574), "Postobon" }
                });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Descripcion", "EstatusIncidencia", "Nombre", "ProyectoId", "Version" },
                values: new object[,]
                {
                    { 10, " carreta ", 1, "incidencia 564", 2, 1f },
                    { 18, " carreta ", 1, "incidencia a963", 3, 1f },
                    { 17, " carreta ", 1, "incidencia a369", 3, 1f },
                    { 16, " carreta ", 1, "incidencia a598", 3, 1f },
                    { 15, " carreta ", 1, "incidencia aww", 3, 1f },
                    { 25, " carreta ", 1, "incidencia tes", 2, 1f },
                    { 24, " carreta ", 1, "incidencia casa", 2, 1f },
                    { 23, " carreta ", 1, "incidencia politico", 2, 1f },
                    { 22, " carreta ", 1, "incidencia tejado", 2, 1f },
                    { 21, " carreta ", 1, "incidencia carro", 2, 1f },
                    { 14, " carreta ", 1, "incidencia afw", 2, 1f },
                    { 13, " carreta ", 1, "incidencia aew", 2, 1f },
                    { 12, " carreta ", 1, "incidencia ol", 2, 1f },
                    { 11, " carreta ", 1, "incidencia d1f", 2, 1f },
                    { 20, " carreta ", 1, "incidencia 74568", 3, 1f },
                    { 9, " carreta ", 1, "incidencia g", 2, 1f },
                    { 8, " carreta ", 1, "incidencia 40", 1, 1f },
                    { 7, " carreta ", 1, "incidencia 1", 1, 1f },
                    { 6, " carreta ", 1, "incidencia df", 1, 1f },
                    { 5, " carreta ", 1, "incidencia e", 1, 1f },
                    { 4, " carreta ", 1, "incidencia ad", 1, 1f },
                    { 3, " carreta ", 1, "incidencia c", 1, 1f },
                    { 2, " carreta ", 1, "incidencia b", 1, 1f },
                    { 1, " carreta ", 1, "incidencia a", 1, 1f },
                    { 19, " carreta ", 1, "incidencia a1244", 3, 1f }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Estatus", "Nombre", "Password", "PerfilId", "Username" },
                values: new object[,]
                {
                    { 5, "Perez", "test@gsoft.com.uy", 1, "Juan", null, 3, null },
                    { 4, "Rozo", "valente@gsoft.com.uy", 1, "Ingri", null, 2, null },
                    { 3, "Wolfan", "valente@gsoft.com.uy", 1, "Jonathan", null, 2, null },
                    { 2, "Valente", "valente@gsoft.com.uy", 1, "Viviana", null, 2, null },
                    { 1, "Somma", "agustina.somma@gsoft.com.uy", 1, "Agustina", null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "UsuariosProyectos",
                columns: new[] { "Id", "FechaRegistro", "ProyectoId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(2301), 1, 1 },
                    { 9, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3228), 3, 1 },
                    { 2, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3120), 2, 2 },
                    { 4, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3157), 1, 2 },
                    { 5, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3171), 2, 2 },
                    { 6, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3187), 2, 3 },
                    { 7, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3201), 2, 4 },
                    { 10, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3243), 3, 4 },
                    { 3, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3142), 3, 5 },
                    { 8, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3214), 2, 5 },
                    { 11, new DateTime(2021, 10, 3, 21, 55, 8, 857, DateTimeKind.Local).AddTicks(3256), 3, 5 }
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
