using BE.Application.Common.FluentValidation.BaseValidators;
using BE.Application.Common.Interfaces;
using BE.Application.Features.UserAuth.Commands.UserRegister;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserEmployeeRegister
{
    public class UserEmployeeRegisterCommandValidator : UserValidatioBase<UserEmployeeRegisterCommand>
    {
        public UserEmployeeRegisterCommandValidator(IIdentityService identityService) : base(identityService)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is not valid");

            RuleFor(x => x.Email)
                .MustAsync(CheckIfUserExists)
                .WithMessage("User with this email already exits");

            RuleFor(x => x.Password)
              .NotEmpty().WithMessage("Password is required")
              .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Password do not match");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required");
        }

        private async Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
        {
            return !await _identityService.IsEmailExistsAsync(email, cancellationToken);
        }
    }
}
