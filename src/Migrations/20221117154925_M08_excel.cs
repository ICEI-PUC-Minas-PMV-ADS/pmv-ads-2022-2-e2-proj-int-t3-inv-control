using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    public partial class M08_excel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "ItensComprados");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Compras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCompra = table.Column<int>(type: "int", nullable: false),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuariosId = table.Column<int>(type: "int", nullable: true),
                    CepFuncionario = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CidadeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneFuncionario = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UfFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItensComprados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprasId = table.Column<int>(type: "int", nullable: true),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    CodPedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensComprados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensComprados_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItensComprados_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprasId = table.Column<int>(type: "int", nullable: true),
                    PagamentosId = table.Column<int>(type: "int", nullable: true),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pagamentos_Pagamentos_PagamentosId",
                        column: x => x.PagamentosId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprasId = table.Column<int>(type: "int", nullable: true),
                    FuncionariosId = table.Column<int>(type: "int", nullable: true),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    CategoriaProd = table.Column<int>(type: "int", nullable: false),
                    CodigoCompra = table.Column<int>(type: "int", nullable: false),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estoque_Funcionarios_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estoque_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemsCompradosId = table.Column<int>(type: "int", nullable: true),
                    PagamentosId = table.Column<int>(type: "int", nullable: true),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    DataEmissao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NumeroNota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_ItensComprados_ItemsCompradosId",
                        column: x => x.ItemsCompradosId,
                        principalTable: "ItensComprados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Pagamentos_PagamentosId",
                        column: x => x.PagamentosId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ComprasId",
                table: "Estoque",
                column: "ComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_FuncionariosId",
                table: "Estoque",
                column: "FuncionariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutosId",
                table: "Estoque",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_UsuariosId",
                table: "Funcionarios",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensComprados_ComprasId",
                table: "ItensComprados",
                column: "ComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensComprados_ProdutosId",
                table: "ItensComprados",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_ItemsCompradosId",
                table: "NotasFiscais",
                column: "ItemsCompradosId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_PagamentosId",
                table: "NotasFiscais",
                column: "PagamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_ProdutosId",
                table: "NotasFiscais",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ComprasId",
                table: "Pagamentos",
                column: "ComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PagamentosId",
                table: "Pagamentos",
                column: "PagamentosId");
        }
    }
}
