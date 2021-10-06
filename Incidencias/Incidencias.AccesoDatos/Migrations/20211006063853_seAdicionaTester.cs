using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidencias.AccesoDatos.Migrations
{
    public partial class seAdicionaTester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DesarrolladorId", "EstatusIncidencia", "TesterId" },
                values: new object[] { 3, 2, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 3,
                column: "TesterId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 5,
                column: "TesterId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 9,
                column: "TesterId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DesarrolladorId", "EstatusIncidencia", "TesterId" },
                values: new object[] { 3, 2, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 12,
                column: "TesterId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 13,
                column: "TesterId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 21,
                column: "TesterId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 3, 6 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 5 });

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

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Email", "Estatus", "Nombre", "Password", "PerfilId", "Username" },
                values: new object[] { 6, "Perez", "silvina@gsoft.com.uy", 1, "Silvina", "AQAAAAEAACcQAAAAEDQZw/655u8YyXe3TDm2sb3LgzHBVOdYZriGphAUgZ7FM2ULzUNe4b9nbRQtjqRiYA==", 3, "silvina" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DesarrolladorId", "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 3,
                column: "TesterId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 5,
                column: "TesterId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 9,
                column: "TesterId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DesarrolladorId", "EstatusIncidencia", "TesterId" },
                values: new object[] { 2, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 12,
                column: "TesterId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 13,
                column: "TesterId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 21,
                column: "TesterId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DesarrolladorId", "TesterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Incidencias",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EstatusIncidencia", "TesterId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 619, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 620, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 620, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1515));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "UsuariosProyectos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2021, 10, 6, 0, 3, 14, 621, DateTimeKind.Local).AddTicks(1569));
        }
    }
}
