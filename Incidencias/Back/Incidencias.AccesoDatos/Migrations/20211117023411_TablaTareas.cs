using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidencias.AccesoDatos.Migrations
{
    public partial class TablaTareas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 427, DateTimeKind.Local).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 428, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 428, DateTimeKind.Local).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 428, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 34, 11, 429, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_ProyectoId",
                table: "Tareas",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 931, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 932, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 932, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2766));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 1, 38, 52, 933, DateTimeKind.Local).AddTicks(2810));
        }
    }
}
