using System.ComponentModel.DataAnnotations;

namespace NSE.Identity.API.Dtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve conter entre {2} e {1} caracteres")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string PasswordConfirmation { get; set; }
    }
}