using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
       
        public Compra Compras { get; set; }

        public string FormaPagamento { get; set; }
        


        public Pagamento Pagamentos { get; set; }

    }
}
