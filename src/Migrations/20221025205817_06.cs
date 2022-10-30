using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeEstoque.Migrations
{
    public partial class _06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Siglas",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Siglas",
                table: "Cliente");
        }
    }
}
