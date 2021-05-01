using Microsoft.AspNetCore.Identity;

namespace NSE.Identity.API.Extensions
{
    public class IdentityErrorMessagesToPortuguese : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
            => new()
            { Code = nameof(DefaultError), Description = "Ocorreu um erro desconhecido" };

        public override IdentityError PasswordRequiresDigit()
            => new()
            { Code = nameof(PasswordRequiresDigit), Description = "A senha deve conter pelo menos um dígito numérico" };

        public override IdentityError DuplicateUserName(string userName)
            => new()
            { Code = nameof(DuplicateUserName), Description = $"O nome de usuário {userName} já está em uso" };

        public override IdentityError DuplicateEmail(string email)
            => new()
            { Code = nameof(DuplicateEmail), Description = $"O email {email} já está em uso" };
    }
}