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
    public class CustomFieldValidator<TValue> : AbstractValidator<CustomField<TValue>>
    {
        public CustomFieldValidator() 
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.Name)));

            RuleFor(f => f.Value)
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.Value)));
        }
    }
}
