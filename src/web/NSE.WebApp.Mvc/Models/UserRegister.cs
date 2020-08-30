using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.Mvc.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um email válido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve conter entre {2} e {1} caracteres")]
        public string Password { get; set; }

        [Display(Name = "Confirmar senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string PasswordConfirmation { get; set; }
    }
}