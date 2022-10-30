using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeEstoque.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodFornecedor = table.Column<int>(type: "int", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BairroFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CidadeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UfFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CepFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmaildoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCompra = table.Column<int>(type: "int", nullable: false),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FornecedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FornecedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CidadeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UfCliente = table.Column<long>(type: "bigint", nullable: false),
                    CepCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuariosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprasId = table.Column<int>(type: "int", nullable: true),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PagamentosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Pagamentos_PagamentosId",
                        column: x => x.PagamentosId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensComprados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    CodPedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensComprados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensComprados_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensComprados_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOuRazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UfCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastroCliente = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: true),
                    PagamentosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Pagamentos_PagamentosId",
                        column: x => x.PagamentosId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCompra = table.Column<int>(type: "int", nullable: false),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCompra = table.Column<int>(type: "int", nullable: false),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendasId = table.Column<int>(type: "int", nullable: true),
                    ComprasId = table.Column<int>(type: "int", nullable: true),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    FornecedoresId = table.Column<int>(type: "int", nullable: true),
                    FuncionariosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estoque_Fornecedor_FornecedoresId",
                        column: x => x.FornecedoresId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estoque_Funcionarios_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estoque_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estoque_Vendas_VendasId",
                        column: x => x.VendasId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensVendidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdProd = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    VendasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensVendidos_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensVendidos_Vendas_VendasId",
                        column: x => x.VendasId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroNota = table.Column<int>(type: "int", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    PagamentosId = table.Column<int>(type: "int", nullable: true),
                    ItemsCompradosId = table.Column<int>(type: "int", nullable: true),
                    VendasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_ItensComprados_ItemsCompradosId",
                        column: x => x.ItemsCompradosId,
                        principalTable: "ItensComprados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Pagamentos_PagamentosId",
                        column: x => x.PagamentosId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Vendas_VendasId",
                        column: x => x.VendasId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PagamentosId",
                table: "Cliente",
                column: "PagamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuariosId",
                table: "Cliente",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FornecedorId",
                table: "Compras",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ComprasId",
                table: "Estoque",
                column: "ComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_FornecedoresId",
                table: "Estoque",
                column: "FornecedoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_FuncionariosId",
                table: "Estoque",
                column: "FuncionariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutosId",
                table: "Estoque",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_VendasId",
                table: "Estoque",
                column: "VendasId");

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
                name: "IX_ItensVendidos_ProdutosId",
                table: "ItensVendidos",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendidos_VendasId",
                table: "ItensVendidos",
                column: "VendasId");

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
                name: "IX_NotasFiscais_VendasId",
                table: "NotasFiscais",
                column: "VendasId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ComprasId",
                table: "Pagamentos",
                column: "ComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PagamentosId",
                table: "Pagamentos",
                column: "PagamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProdutosId",
                table: "Vendas",
                column: "ProdutosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "ItensVendidos");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "ItensComprados");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
