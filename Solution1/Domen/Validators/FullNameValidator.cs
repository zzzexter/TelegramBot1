using System;
using System.Collections.Generic;
using System.Text;
using Domen.Primitivies;
using Domen.ValueObjects;
using FluentValidation;

namespace Domen.Validators
{
    public class FullNameValidator : AbstractValidator<FullName>
    {
        public FullNameValidator()
        {
            RuleFor(f => f.FirstName)
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.FirstName)))
                .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(f => ValidationMessages.IsLetter(nameof(f.FirstName)));

            RuleFor(f => f.LastName)
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.LastName)))
                .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(f => ValidationMessages.IsLetter(nameof(f.LastName)));

            RuleFor(f => f.MiddleName)
                .Matches(@"^[a-zA-Zа-яА-Я]+$").When(f => !string.IsNullOrEmpty(f.MiddleName)).WithMessage(ValidationMessages.IsLetter(nameof(FullName.MiddleName)));
        }
    }
}
