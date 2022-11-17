using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class Cliente
    {
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Nome/Razão social")]
        [Required(ErrorMessage =("Por favor, digite o nome!"))]
        public string NomeOuRazaoSocial { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage ="Por favor, digite o endereço!")]
        public string EnderecoCliente { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage ="Por favor, digite o email!")]
        [DataType(DataType.EmailAddress)]
        public string EmailCliente { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage ="Por favor, preencha o nome da sua cidade!")]
        public string CidadeCliente { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Por favor, preencha seu estado!")]
        public string UfCliente { get; set; }

        [MaxLength(9)]
        [DisplayName("CEP")]
        [Required(ErrorMessage = "Por favor, digite o CEP!")]
        public string CepCliente { get; set; }

        [MaxLength(15)]
        [DisplayName("Telefone")]
        [Required(ErrorMessage = "Por favor, digite o telefone!")]
        public string TelefoneCliente { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Por favor preencha a data de cadastro!")]
        public DateTimeOffset DataCadastroCliente { get; set; }

        [NotMapped]
        public Usuario Usuarios { get; set; }


    }
}
