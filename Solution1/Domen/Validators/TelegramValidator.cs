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
    public class TelegramValidator : AbstractValidator<Pers>
    {
        public TelegramValidator() 
        {
            RuleFor(f => f.Telegram)
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.Telegram)))
                .MaximumLength(20).WithMessage(f => ValidationMessages.IsTelegramFalse(nameof(f.Telegram)))
                .Must(t => t.Contains("@")).WithMessage(f => ValidationMessages.IsTelegramFalse(nameof(f.Telegram)));
        }
    }
}
