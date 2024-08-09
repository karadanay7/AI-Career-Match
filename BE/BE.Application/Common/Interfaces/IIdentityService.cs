using BE.Application.Common.Models;
using BE.Application.Common.Models.User;
using BE.Application.Features.UserAuth.Commands.UserEmployeeRegister;
using BE.Application.Features.UserAuth.Commands.UserEmployerRegister;
using BE.Application.Features.UserAuth.Commands.UserLogin;
using BE.Application.Features.UserAuth.Commands.UserResetPassword;
using BE.Application.Features.UserAuth.Commands.UserVerifyEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
        Task<UserRegisterResponseDto> RegisterEmployeeAsync(UserEmployeeRegisterCommand command, CancellationToken cancellationToken);

        Task<UserRegisterResponseDto> RegisterEmployerAsync(UserEmployerRegisterCommand command, CancellationToken cancellationToken);
        Task<bool> VerifyEmailAsync(UserVerifyEmailCommand command, CancellationToken cancellationToken);

        Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken);
        Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken);

        Task<JwtDto> LoginAsync(UserLoginCommand userLoginCommand, CancellationToken cancellationToken);

        Task<UserForgotPasswordResponseDto> ForgotPasswordAsync(string email, CancellationToken cancellationToken);
        Task<bool> ResetPasswordAsync (UserResetPasswordCommand command, CancellationToken cancellationToken);

    }
}
