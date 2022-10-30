using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class ItemVendido
    {
        public int Id { get; set; }
        public string NomeProd { get; set; }
        public decimal PrecoProd { get; set; }

        public string DescricaoProd { get; set; }

        public long QtdProd { get; set; }

        public string CategoriaProd { get; set; }

        public Produto Produtos { get; set;  }

        public Venda Vendas { get; set; }

    }
}
