using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class NotaFiscal 
    {
        public int Id { get; set; }
        public int NumeroNota { get; set; }
        public DateTimeOffset DataEmissao { get; set; }

        public Produto Produtos { get; set; }

       
        public Pagamento Pagamentos { get; set; }

        public ItemComprado ItemsComprados { get; set; }

    }
}
