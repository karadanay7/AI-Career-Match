using BE.Application.Common.FluentValidation.BaseValidators;
using BE.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserChangePassword
{
    public class UserChangePasswordCommandValidator : UserValidatioBase<UserChangePasswordCommand>
    {
        public UserChangePasswordCommandValidator(IIdentityService identityService) : base(identityService)
        {
            RuleFor(x => x.CurrentPassword)
               .NotEmpty().WithMessage("Password is required")
               .MinimumLength(6).WithMessage("Password must be at least 6 characters");


            RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
               .NotEmpty().WithMessage("Confirm Password is required")
               .Equal(x => x.NewPassword).WithMessage("Passwords do not match");
        }
    }
}
