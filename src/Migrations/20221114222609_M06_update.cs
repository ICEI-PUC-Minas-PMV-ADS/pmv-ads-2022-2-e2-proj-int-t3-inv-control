using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    public partial class M06_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Vendas_VendasId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasFiscais_Vendas_VendasId",
                table: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "ItensVendidos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_NotasFiscais_VendasId",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_VendasId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "VendasId",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "CnpjFornecedor",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "VendasId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "CodigoCliente",
                table: "Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendasId",
                table: "NotasFiscais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CnpjFornecedor",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VendasId",
                table: "Estoque",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    CategoriaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCompra = table.Column<int>(type: "int", nullable: false),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItensVendidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    VendasId = table.Column<int>(type: "int", nullable: true),
                    CategoriaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensVendidos_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItensVendidos_Vendas_VendasId",
                        column: x => x.VendasId,
                        principalTable: "Vendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_VendasId",
                table: "NotasFiscais",
                column: "VendasId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_VendasId",
                table: "Estoque",
                column: "VendasId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendidos_ProdutosId",
                table: "ItensVendidos",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendidos_VendasId",
                table: "ItensVendidos",
                column: "VendasId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProdutosId",
                table: "Vendas",
                column: "ProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Vendas_VendasId",
                table: "Estoque",
                column: "VendasId",
                principalTable: "Vendas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotasFiscais_Vendas_VendasId",
                table: "NotasFiscais",
                column: "VendasId",
                principalTable: "Vendas",
                principalColumn: "Id");
        }
    }
}
