using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class Funcionario
    {
        public int? Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = ("Por favor, digite o nome!"))]
        public string NomeFuncionario { get; set; }



        [DisplayName("Email")]
        [Required(ErrorMessage = "Por favor, digite o email!")]
        [DataType(DataType.EmailAddress)]
        public string EmailFuncionario { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Por favor, digite o endereço!")]
        public string EnderecoFuncionario { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Por favor, preencha o nome da sua cidade!")]
        public string CidadeFuncionario { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Por favor, preencha seu estado!")]
        public UfFuncionario UfFuncionario { get; set; }

        [MaxLength(9)]
        [DisplayName("CEP")]
        [Required(ErrorMessage = "Por favor, digite o CEP!")]
        public string CepFuncionario { get; set; }

        [MaxLength(15)]
        [DisplayName("Telefone")]
        [Required(ErrorMessage = "Por favor, digite o telefone!")]
        public string TelefoneFuncionario { get; set; }

        [DisplayName("Código")]
        [Required(ErrorMessage = "Por favor, digite o Código do funcionario!")]
        public string CodigoFuncionario { get; set; }

        public Usuario Usuarios { get; set; }
     }

    public enum UfFuncionario
    {
        MG,
        RJ,
        SP,
        RS
    }
}

