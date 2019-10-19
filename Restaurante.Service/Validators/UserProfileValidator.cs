using FluentValidation;
using System;
using Restaurante.Domain.Request;
using Restaurante.Infra.Resources;

namespace Restaurante.Service.Validators
{
    public class UserProfileValidator : AbstractValidator<UserProfileRequest>
    {
        public UserProfileValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x => throw new ArgumentNullException(MessagesAPI.OBJECT_INVALID));

            RuleFor(c => c.UserId)
                .NotNull().WithMessage(MessagesAPI.USER_REQUIRED);
               
            RuleFor(c => c.ProfileId)
                .NotNull().WithMessage(MessagesAPI.PROFILE_REQUIRED);

        }
    }
}
