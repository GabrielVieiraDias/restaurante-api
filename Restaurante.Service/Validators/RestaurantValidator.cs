using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Infra.Resources;

namespace Restaurante.Service.Validators
{
    public class RestaurantValidator : AbstractValidator<RestaurantRequest>
    {
        public RestaurantValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x => throw new ArgumentNullException(MessagesAPI.OBJECT_INVALID));

            RuleFor(c => c.Name)
               .NotEmpty().WithMessage(MessagesAPI.NAME_REQUIRED)
               .NotNull().WithMessage(MessagesAPI.NAME_REQUIRED)
               .Length(1, 100).WithMessage(MessagesAPI.NAME_MIN_MAX);
        }
    }
}
