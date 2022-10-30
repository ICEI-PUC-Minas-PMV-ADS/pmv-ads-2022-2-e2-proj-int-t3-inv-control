using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoque.Models
{
    public class ControleContext : DbContext
    { 
        public ControleContext(DbContextOptions<ControleContext>
           options ): base(options)
        {

        }

    
        public DbSet<Produto> Produto { get; set; }

      

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }

        public DbSet<ItemComprado> ItensComprados { get; set; }
        public DbSet<ItemVendido> ItensVendidos { get; set; }


        public DbSet<Pagamento> Pagamentos { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<Compra> Compras { get; set;  }

        public DbSet <Estoque> Estoque { get; set; }

        public DbSet <Funcionario> Funcionarios { get; set; }

        public DbSet <Fornecedor> Fornecedores { get; set; }
  


    }
}