using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasWebMVC.Migrations
{
    public partial class AjusteCampoTabelaVendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vendedor",
                newName: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Vendedor",
                newName: "Name");
        }
    }
}
