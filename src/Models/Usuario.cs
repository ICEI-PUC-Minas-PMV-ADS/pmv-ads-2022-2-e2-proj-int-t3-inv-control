using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeEstoque.Models
{
    public class Usuario
    {
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Por favor, digite o email!")]
        [DataType(DataType.EmailAddress)]
        public string EmaildoUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o login!")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, preencha a senha!")]
        public string Senha { get; set; }

        [DisplayName("Perfil")]
        [Required(ErrorMessage = "Por favor, preencha o perfil do usuario!")]
        public PerfilUsuario PerfilUsuario { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Por favor preencha a data de cadastro!")]
        public DateTimeOffset DataCadastro { get; set; }

     }

    public enum PerfilUsuario
    {
        Administrador,
        Funcionario
    }
}
