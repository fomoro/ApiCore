using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidencias.AccesoDatos.Migrations
{
    public partial class insertarTareas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 607, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 607, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 607, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "Costo", "Duracion", "Nombre", "ProyectoId" },
                values: new object[,]
                {
                    { 1, 100m, 1, "Tarea a", 1 },
                    { 23, 660m, 5, "Tarea 21", 2 },
                    { 24, 550m, 1, "Tarea 22", 2 },
                    { 26, 10m, 3, "Tarea a2", 3 },
                    { 27, 10m, 14, "Tarea a3", 3 },
                    { 28, 10m, 15, "Tarea a4", 3 },
                    { 29, 10m, 11, "Tarea a5", 3 },
                    { 31, 10m, 9, "Tarea a7", 3 },
                    { 22, 770m, 6, "Tarea 20", 2 },
                    { 32, 10m, 8, "Tarea a8", 3 },
                    { 33, 10m, 7, "Tarea a9", 3 },
                    { 34, 10m, 6, "Tarea b1", 3 },
                    { 35, 10m, 1, "Tarea b2", 3 },
                    { 36, 10m, 4, "Tarea b3", 3 },
                    { 30, 10m, 10, "Tarea a6", 3 },
                    { 21, 880m, 7, "Tarea 19", 2 },
                    { 25, 10m, 2, "Tarea a1", 3 },
                    { 19, 120m, 10, "Tarea 17", 2 },
                    { 2, 300m, 2, "Tarea b", 1 },
                    { 3, 200m, 3, "Tarea c", 1 },
                    { 4, 30m, 4, "Tarea d", 1 },
                    { 5, 50m, 5, "Tarea e", 1 },
                    { 20, 990m, 8, "Tarea 18", 2 },
                    { 7, 130m, 11, "Tarea g", 1 },
                    { 8, 560m, 4, "Tarea h", 1 },
                    { 9, 60m, 3, "Tarea i", 1 },
                    { 10, 110m, 2, "Tarea j", 1 },
                    { 6, 120m, 10, "Tarea f", 1 },
                    { 12, 250m, 1, "Tarea l", 1 },
                    { 13, 60m, 11, "Tarea 11", 2 },
                    { 14, 710m, 2, "Tarea 12", 2 },
                    { 15, 80m, 3, "Tarea 13", 2 },
                    { 11, 210m, 5, "Tarea k", 1 },
                    { 16, 920m, 31, "Tarea 14", 2 },
                    { 17, 30m, 15, "Tarea 15", 2 },
                    { 18, 130m, 11, "Tarea 16", 2 }
                });

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2021, 11, 16, 21, 53, 22, 608, DateTimeKind.Local).AddTicks(6078));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 36);

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
    }
}
