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
        public DbSet <Fornecedor> Fornecedores { get; set; }
    }
}