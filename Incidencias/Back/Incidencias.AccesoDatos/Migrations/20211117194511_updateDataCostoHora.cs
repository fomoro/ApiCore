using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidencias.AccesoDatos.Migrations
{
    public partial class updateDataCostoHora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 478, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CostoHora",
                value: 1000m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CostoHora",
                value: 1900m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CostoHora",
                value: 1800m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "CostoHora",
                value: 1400m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                column: "CostoHora",
                value: 1300m);

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 45, 10, 479, DateTimeKind.Local).AddTicks(8450));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 52, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CostoHora",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CostoHora",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CostoHora",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "CostoHora",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                column: "CostoHora",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 17, 14, 39, 30, 53, DateTimeKind.Local).AddTicks(9357));
        }
    }
}
