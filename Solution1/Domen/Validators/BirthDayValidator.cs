using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Entities;
using Domen.Primitivies;
using Domen.ValueObjects;
using FluentValidation;

namespace Domen.Validators
{
    public class BirthDayValidator : AbstractValidator<Pers>
    {
        public BirthDayValidator() 
        {
            RuleFor(f => f.BirthDay)
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.BirthDay)))
                .LessThanOrEqualTo(DateTime.Today).WithMessage(f => ValidationMessages.IsBirthdayFalse(nameof(f.BirthDay)))
                .GreaterThan(DateTime.Today.AddYears(-150)).WithMessage(f => ValidationMessages.IsBirthdayFalse(nameof(f.BirthDay)));
        }
    }
}
