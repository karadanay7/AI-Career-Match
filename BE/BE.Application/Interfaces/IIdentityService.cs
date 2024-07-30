using BE.Application.Features.UserAuth.Commands.UserRegister;
using BE.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> IsEmailExistsAsync(string email,CancellationToken cancellationToken);
        Task<UserEmployeeRegisterResponseDto> RegisterAsync(UserEmployeeRegisterCommand command, CancellationToken cancellationToken);
    }
}
