using BE.Application.Common.FluentValidation.BaseValidators;
using BE.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserResetPassword
{
    public class UserResetPasswordCommandValidator : UserValidatioBase<UserResetPasswordCommand>
    {
        public UserResetPasswordCommandValidator(IIdentityService identityService) : base(identityService)
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid")
                .MustAsync(CheckIfUserExist).WithMessage("User with this email does not exist")
                .MustAsync(CheckIfEmailVerifiedAsync).WithMessage("Email is not verified. Please verify your emil");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be least 6 characters");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password is requires")
                .Equal(x => x.Password).WithMessage("Passwords do not mach");
        }

        private async Task<bool> CheckIfUserExist(string email,CancellationToken cancellationToken)
        {
            return await _identityService.IsEmailExistsAsync(email, cancellationToken);
        }

        private Task<bool> CheckIfEmailVerifiedAsync(string email,CancellationToken cancellationToken)
        {
            return _identityService.CheckIfEmailVerifiedAsync(email, cancellationToken);
        }
    }
}
