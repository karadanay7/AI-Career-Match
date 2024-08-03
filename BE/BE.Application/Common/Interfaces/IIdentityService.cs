using BE.Application.Common.Models;
using BE.Application.Features.UserAuth.Commands.UserRegister;
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
        Task<UserEmployeeRegisterResponseDto> RegisterAsync(UserEmployeeRegisterCommand command, CancellationToken cancellationToken);

        Task<bool> VerifyEmailAsync(UserVerifyEmailCommand command, CancellationToken cancellationToken);
    }
}
