﻿using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator : AbstractValidator<RegisterAuthDto>
    {
        public AuthValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail adresi boş olamaz");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi yazınız");
            RuleFor(p => p.Image.FileName).NotEmpty().WithMessage("Kullanıcı resmi boş olamaz");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az 1 adet büyük karakter içermelidir");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az 1 adet küçük karakter içermelidir");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az 1 adet rakam içermelidir");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9").WithMessage("Şifre en az 1 adet özel karakter içermelidir");


        }

    }
}
