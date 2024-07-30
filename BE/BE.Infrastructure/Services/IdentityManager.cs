using BE.Application.Features.UserAuth.Commands.UserRegister;
using BE.Application.Interfaces;
using BE.Application.Models;
using BE.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Infrastructure.Services
{
    public class IdentityManager : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public IdentityManager(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }


        public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user is not null)
            {
                return true;
            }

            return false;
        }

        public async Task<UserEmployeeRegisterResponseDto> RegisterAsync(UserEmployeeRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserEmployeeRegisterCommand.ToUser(command);

            var result= await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User registration failed");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return new UserEmployeeRegisterResponseDto(user.Id, user.Email, user.FirstName, token);


        }
    }
}
