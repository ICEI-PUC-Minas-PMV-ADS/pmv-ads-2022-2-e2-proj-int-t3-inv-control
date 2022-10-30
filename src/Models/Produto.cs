using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class Produto
    {
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = ("Por favor, digite o nome!"))]
        public string NomeProd { get; set; }

        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = ("Por favor, digite o preço!"))]
        public decimal PrecoProd { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = ("Por favor, digite uma descrição para o produto!"))]
        public string DescricaoProd { get; set; }

        [DisplayName("Qtde")]
        [Required(ErrorMessage = ("Por favor, digite a quantidade!"))]
        public long QtdProd { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = ("Por favor, informe a categoria!"))]
        public Categoria CategoriaProd { get; set; }

        [DisplayName("Fornecedor")]
        public int FornecedorId { get; set; }

        [ForeignKey("FornecedorId")]
        public Fornecedor Fornecedor { get; set; }    
        

    }

    public enum Categoria
    {
        Hardware,
        Periferico
    }
}
