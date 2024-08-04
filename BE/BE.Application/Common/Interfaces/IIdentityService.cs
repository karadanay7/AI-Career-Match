using BE.Application.Common.Models;
using BE.Application.Features.UserAuth.Commands.UserEmployeeRegister;
using BE.Application.Features.UserAuth.Commands.UserEmployerRegister;
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
    }
}
