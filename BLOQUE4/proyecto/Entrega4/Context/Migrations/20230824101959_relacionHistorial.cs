using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class relacionHistorial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "monedaDestino",
                table: "historial");

            migrationBuilder.DropColumn(
                name: "monedaOrigen",
                table: "historial");

            migrationBuilder.AddColumn<Guid>(
                name: "moneda1",
                table: "historial",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "moneda2",
                table: "historial",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_historial_idUsuario",
                table: "historial",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_historial_moneda1",
                table: "historial",
                column: "moneda1");

            migrationBuilder.CreateIndex(
                name: "IX_historial_moneda2",
                table: "historial",
                column: "moneda2");

            migrationBuilder.AddForeignKey(
                name: "FK_historial_monedas_moneda1",
                table: "historial",
                column: "moneda1",
                principalTable: "monedas",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_historial_monedas_moneda2",
                table: "historial",
                column: "moneda2",
                principalTable: "monedas",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_historial_usuarios_idUsuario",
                table: "historial",
                column: "idUsuario",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historial_monedas_moneda1",
                table: "historial");

            migrationBuilder.DropForeignKey(
                name: "FK_historial_monedas_moneda2",
                table: "historial");

            migrationBuilder.DropForeignKey(
                name: "FK_historial_usuarios_idUsuario",
                table: "historial");

            migrationBuilder.DropIndex(
                name: "IX_historial_idUsuario",
                table: "historial");

            migrationBuilder.DropIndex(
                name: "IX_historial_moneda1",
                table: "historial");

            migrationBuilder.DropIndex(
                name: "IX_historial_moneda2",
                table: "historial");

            migrationBuilder.DropColumn(
                name: "moneda1",
                table: "historial");

            migrationBuilder.DropColumn(
                name: "moneda2",
                table: "historial");

            migrationBuilder.AddColumn<string>(
                name: "monedaDestino",
                table: "historial",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "monedaOrigen",
                table: "historial",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
