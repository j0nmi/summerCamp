using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class CamposNuevos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resultado",
                table: "historial");

            migrationBuilder.AddColumn<float>(
                name: "resultadoConversion",
                table: "historial",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resultadoConversion",
                table: "historial");

            migrationBuilder.AddColumn<double>(
                name: "resultado",
                table: "historial",
                type: "float",
                nullable: true);
        }
    }
}
