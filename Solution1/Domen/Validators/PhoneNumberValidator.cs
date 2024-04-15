using Domen.Entities;
using Domen.Primitivies;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Validators
{
    public class PhoneNumberValidator : AbstractValidator<Pers>
    {
        public PhoneNumberValidator() 
        {
            RuleFor(f => f.PhoneNumber)
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.PhoneNumber)))
                .Matches(@"^\+37377(?!.*[123])\d{6}$").WithMessage(f => ValidationMessages.IsPhoneNumberFalse(nameof(f.PhoneNumber)));
        }
    }
}
