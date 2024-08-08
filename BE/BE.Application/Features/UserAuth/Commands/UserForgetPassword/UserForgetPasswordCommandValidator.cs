using BE.Application.Common.FluentValidation.BaseValidators;
using BE.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserForgetPassword
{
    public class UserForgetPasswordCommandValidator : UserValidatioBase<UserForgetPasswordCommand>
    {
        public UserForgetPasswordCommandValidator(IIdentityService identityService) : base(identityService)
        {
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Email is required")
               .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Email)
                .MustAsync(CheckIfUserExists)
                .WithMessage("User with this email already exists");

            RuleFor(x => x.Email)
                .MustAsync(CheckIfEmailVerifiedAsync)
                .WithMessage("Email is not verified. Please verify your  email");
        }

        private async Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
        {
            return await _identityService.IsEmailExistsAsync(email, cancellationToken);

        }

        private Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken)
        {
            return _identityService.CheckIfEmailVerifiedAsync(email, cancellationToken);
        }

    }
}
