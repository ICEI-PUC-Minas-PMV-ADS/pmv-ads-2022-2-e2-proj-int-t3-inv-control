using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeEstoque.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pagamentos_PagamentosId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuarios_UsuariosId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Fornecedor_FornecedorId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Fornecedor_FornecedoresId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Cliente_ClienteId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_FornecedoresId",
                table: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Compras_FornecedorId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_PagamentosId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_UsuariosId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "FornecedoresId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "PagamentosId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "UfCliente",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UfCliente",
                table: "Funcionarios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FornecedoresId",
                table: "Estoque",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PagamentosId",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BairroFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CepFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CidadeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodFornecedor = table.Column<int>(type: "int", nullable: false),
                    EnderecoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UfFornecedor = table.Column<string>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_FornecedoresId",
                table: "Estoque",
                column: "FornecedoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FornecedorId",
                table: "Compras",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PagamentosId",
                table: "Cliente",
                column: "PagamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuariosId",
                table: "Cliente",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pagamentos_PagamentosId",
                table: "Cliente",
                column: "PagamentosId",
                principalTable: "Pagamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Usuarios_UsuariosId",
                table: "Cliente",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Fornecedor_FornecedorId",
                table: "Compras",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Fornecedor_FornecedoresId",
                table: "Estoque",
                column: "FornecedoresId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorId",
                table: "Produto",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Cliente_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
