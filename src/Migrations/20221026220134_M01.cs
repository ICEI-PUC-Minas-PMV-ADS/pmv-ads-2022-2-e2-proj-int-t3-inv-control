using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeEstoque.Migrations
{
    public partial class M01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Siglas",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "UfCliente",
                table: "Cliente",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UfCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Siglas",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
