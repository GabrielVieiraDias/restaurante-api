using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Infra.Resources;

namespace Restaurante.Service.Validators
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x => throw new ArgumentNullException(MessagesAPI.OBJECT_INVALID));

            RuleFor(c => c.Email)
               .NotEmpty().WithMessage(MessagesAPI.EMAIL_REQUIRED)
               .NotNull().WithMessage(MessagesAPI.EMAIL_REQUIRED)
               .EmailAddress().WithMessage(MessagesAPI.EMAIL_INVALID);
               
            RuleFor(c => c.PasswordHash)
                .NotEmpty().WithMessage(MessagesAPI.PASSWORD_REQUIRED)
                .NotNull().WithMessage(MessagesAPI.PASSWORD_REQUIRED)
                .Length(5, 15).WithMessage(MessagesAPI.PASSWORD_MIN_MAX);

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage(MessagesAPI.FIRST_NAME_REQUIRED)
                .NotNull().WithMessage(MessagesAPI.FIRST_NAME_REQUIRED)
                .Length(1, 100).WithMessage(MessagesAPI.FIRST_NAME_MIN_MAX);

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage(MessagesAPI.LAST_NAME_REQUIRED)
                .NotNull().WithMessage(MessagesAPI.LAST_NAME_REQUIRED)
                .Length(1, 100).WithMessage(MessagesAPI.LAST_NAME_MIN_MAX);
        }
    }
}
