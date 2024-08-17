using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserRepository.Validation.FluentValidation
{
    internal class UserChangePasswordValidator : AbstractValidator<UserChangePasswordDto>
    {
        public UserChangePasswordValidator()
        {
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.NewPassword).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(p => p.NewPassword).Matches("[A-Z]").WithMessage("Şifre en az 1 adet büyük karakter içermelidir");
            RuleFor(p => p.NewPassword).Matches("[a-z]").WithMessage("Şifre en az 1 adet küçük karakter içermelidir");
            RuleFor(p => p.NewPassword).Matches("[0-9]").WithMessage("Şifre en az 1 adet rakam içermelidir");
            RuleFor(p => p.NewPassword).Matches("[^a-zA-Z0-9").WithMessage("Şifre en az 1 adet özel karakter içermelidir");


        }

    }
}
