using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public int CodigoCompra { get; set; }
        public string NomeProd { get; set; }
        public decimal PrecoProd { get; set; }

        public string DescricaoProd { get; set; }

        public long QtdProd { get; set; }

        public string CategoriaProd { get; set; }

        public Produto Produtos { get; set; }



        

    }
}
