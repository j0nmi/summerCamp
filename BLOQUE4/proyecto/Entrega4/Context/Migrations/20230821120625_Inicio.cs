using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "historial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<double>(type: "float", nullable: false),
                    monedaOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    monedaDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultado = table.Column<double>(type: "float", nullable: true),
                    fechaConversion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "monedas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    factor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monedas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paises",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bandera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idPais = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "paises",
                columns: new[] { "id", "bandera", "nombre" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b01"), "ESP", "Spain" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b02"), "PLN", "Poland" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b03"), "FR", "France" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "email", "fechaNacimiento", "idPais", "password" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b31"), "aaaa@aaaa.com", new DateTime(1980, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b06"), "123456" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b32"), "bbbb@bbbb.com", new DateTime(1990, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b05"), "123456" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b33"), "cccc@cccc.com", new DateTime(2000, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b04"), "123456" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historial");

            migrationBuilder.DropTable(
                name: "monedas");

            migrationBuilder.DropTable(
                name: "paises");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
