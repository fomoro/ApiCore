using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidencias.AccesoDatos.Migrations
{
    public partial class modificacionIncidencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostoHora",
                table: "Usuarios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Duracion",
                table: "Incidencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 60, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 60, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 60, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6123));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6168));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6224));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 40, 52, 61, DateTimeKind.Local).AddTicks(6238));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoHora",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Incidencias");

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
        }
    }
}
