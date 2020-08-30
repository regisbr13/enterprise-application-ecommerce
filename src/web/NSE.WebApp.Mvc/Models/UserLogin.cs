using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.Mvc.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um email válido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve conter entre {2} e {1} caracteres")]
        public string Password { get; set; }
    }
}