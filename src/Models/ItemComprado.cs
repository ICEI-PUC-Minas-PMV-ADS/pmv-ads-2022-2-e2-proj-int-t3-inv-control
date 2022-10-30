using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class ItemComprado
    {
        public int Id { get; set; }
        public DateTimeOffset Data { get; set; }
        public Produto Produtos { get; set; }

        public string CodPedido { get; set; }

        public Compra Compras { get; set; }
             
    }
}
