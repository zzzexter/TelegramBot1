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
    public class GenderValidator : AbstractValidator<Pers>
    {
        public GenderValidator() 
        {
            RuleFor(f => f.Gender)
                .NotEmpty().WithMessage(f => ValidationMessages.IsGenderUndefined(nameof(f.Gender)));
        }
    }
}
