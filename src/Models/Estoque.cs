using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class Estoque 
    {
        public int Id { get; set; }

        [DisplayName("Código de compra")]
        public int CodigoCompra { get; set; }

        [DisplayName("Nome")]
        public string NomeProd { get; set; }

        [DisplayName("Preço")]
        public decimal PrecoProd { get; set; }

        [DisplayName("Descrição")]
        public string DescricaoProd { get; set; }

        [DisplayName("Qtde")]
        public long QtdProd { get; set; }

        [DisplayName("Categoria")]
        public Categoria CategoriaProd { get; set; }

        public Compra Compras { get; set; }

        public Produto Produtos { get; set; }


        public Funcionario Funcionarios { get; set; }

    }
}
