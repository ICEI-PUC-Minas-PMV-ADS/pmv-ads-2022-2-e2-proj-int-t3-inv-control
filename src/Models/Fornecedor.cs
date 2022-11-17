using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.Models
{
    public class Fornecedor
    {
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Razão Social")]
        [Required(ErrorMessage = "Por favor, digite a Razão Social!")]
        public string RazaoSocial { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Por favor, digite o email!")]
        public string EmailFornecedor { get; set; }

        [MaxLength(15)]
        [DisplayName("Telefone")]
        [Required(ErrorMessage = "Por favor, digite o telefone!")]
        public string TelefoneFornecedor { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Por favor, preencha o nome da sua cidade!")]
        public string CidadeFornecedor { get; set; }    

        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Por favor preencha a data de cadastro!")]
        public DateTimeOffset DataCadastroFornecedor { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Por favor preencha o estado!")]
        public UfFornecedor UfFornecedor { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }

    public enum UfFornecedor
    {
        AC,
        AL,
        AP,
        AM,
        BA,
        CE,
        DF,
        ES,
        GO,
        MA,
        MT,
        MS,
        MG,
        PA,
        PB,
        PR,
        PE,
        PI,
        RJ,
        RN,
        RS,
        RO,
        RR,
        SC,
        SP,
        SE,
        TO
    }


}
