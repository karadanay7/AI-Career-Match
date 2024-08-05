using BE.Application.Common.FluentValidation.BaseValidators;
using BE.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserVerifyEmail
{
    public class UserVerifyEmailCommandValidatior : UserValidatioBase<UserVerifyEmailCommand>
    {
        public UserVerifyEmailCommandValidatior(IIdentityService identityService) : base(identityService)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} is not a valid email address");

            RuleFor(x => x.Email)
                .MustAsync(CheckIfUserExists)
                .WithMessage("User with this email does not exist.");

            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(10).WithMessage("{PRopertyName} must be at least 10 character long");


        }

        private Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
        {
            return _identityService.IsEmailExistsAsync(email, cancellationToken);
        }
    }
}
