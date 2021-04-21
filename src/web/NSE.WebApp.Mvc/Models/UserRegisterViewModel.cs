using NSE.WebApp.Mvc.Extensions;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.Mvc.Models
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [CpfValidation]
        public string Cpf { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um {0} válido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A {0} deve conter entre {2} e {1} caracteres")]
        public string Password { get; set; }

        [Display(Name = "Confirmar senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As Senhas não conferem")]
        public string PasswordConfirmation { get; set; }
    }
}