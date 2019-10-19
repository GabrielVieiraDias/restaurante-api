using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Infra.Resources;

namespace Restaurante.Service.Validators
{
    public class DishValidator : AbstractValidator<DishRequest>
    {
        public DishValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x => throw new ArgumentNullException(MessagesAPI.OBJECT_INVALID));

            RuleFor(c => c.Description)
               .NotEmpty().WithMessage(MessagesAPI.DESCRIPTION_REQUIRED)
               .NotNull().WithMessage(MessagesAPI.DESCRIPTION_REQUIRED)
               .Length(1, 100).WithMessage(MessagesAPI.DESCRIPTION_MIN_MAX);

            RuleFor(c => c.Price)
               .NotEmpty().WithMessage(MessagesAPI.PRICE_REQUIRED)
               .NotNull().WithMessage(MessagesAPI.PRICE_REQUIRED);

            RuleFor(c => c.RestaurantId)
               .NotEmpty().WithMessage(MessagesAPI.RESTAURANT_REQUIRED)
               .NotNull().WithMessage(MessagesAPI.RESTAURANT_REQUIRED)
               .GreaterThan(0).WithMessage(MessagesAPI.RESTAURANT_INVALID);
        }
    }
}
