using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Infra.Resources;

namespace Restaurante.Service.Validators
{
    public class ProfileValidator : AbstractValidator<ProfileRequest>
    {
        public ProfileValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x => throw new ArgumentNullException(MessagesAPI.OBJECT_INVALID));

            RuleFor(c => c.Description)
               .NotEmpty().WithMessage(MessagesAPI.DESCRIPTION_REQUIRED)
               .NotNull().WithMessage(MessagesAPI.DESCRIPTION_REQUIRED);
         
        }
    }
}
