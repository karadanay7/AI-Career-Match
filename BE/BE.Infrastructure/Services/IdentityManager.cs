using BE.Application.Common.Interfaces;
using BE.Application.Common.Models;
using BE.Application.Common.Models.User;
using BE.Application.Features.UserAuth.Commands.UserEmployeeRegister;
using BE.Application.Features.UserAuth.Commands.UserEmployerRegister;
using BE.Application.Features.UserAuth.Commands.UserLogin;
using BE.Application.Features.UserAuth.Commands.UserResetPassword;
using BE.Application.Features.UserAuth.Commands.UserVerifyEmail;
using BE.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public async Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
            {
                throw new Exception("Password change failed");
            }

            return true;
        }

        public Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken)
        {
            return _userManager.Users.AnyAsync(x => x.Email == email && x.EmailConfirmed, cancellationToken);
        }

        public async  Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return false;
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<UserForgotPasswordResponseDto> ForgotPasswordAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return new UserForgotPasswordResponseDto(user.Id, user.Email, user.FirstName, token);
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

        public async Task<JwtDto> LoginAsync(UserLoginCommand userLoginCommand, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(userLoginCommand.Email);
            List<string> roles= new List<string> { user.UserType.ToString() };
            var jwtDto = await _jwtService.GenerateTokenAsync(user.Id, user.Email,roles,cancellationToken);
            return jwtDto;
        }

        public async Task<UserRegisterResponseDto> RegisterEmployeeAsync(UserEmployeeRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserEmployeeRegisterCommand.ToUser(command);

            var result= await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                //throw new Exception("User registration failed");
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                // Loglama yapılabilir, örneğin: 
                Console.WriteLine($"User registration failed: {errors}");
                throw new Exception($"User registration failed: {errors}");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return new UserRegisterResponseDto(user.Id, user.Email, user.FirstName, token);


        }

        public async Task<UserRegisterResponseDto> RegisterEmployerAsync(UserEmployerRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserEmployerRegisterCommand.ToUser(command);

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                //throw new Exception("User registration failed");
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                // Loglama yapılabilir, örneğin: 
                Console.WriteLine($"User registration failed: {errors}");
                throw new Exception($"User registration failed: {errors}");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return new UserRegisterResponseDto(user.Id, user.Email, user.FirstName, token);
        }

        public async Task<bool> ResetPasswordAsync(UserResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var user= await _userManager.FindByEmailAsync(command.Email);
            var decodedToken = HttpUtility.UrlEncode(command.Token);

            var result=await _userManager.ResetPasswordAsync(user, decodedToken,command.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Password reset failed");
            }

            return true;
        }

        public async Task<bool> VerifyEmailAsync(UserVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            var result = await _userManager.ConfirmEmailAsync(user, command.Token);

            if (!result.Succeeded)
            {
                throw new Exception("User's email verification failed");
            }

            return true;
        }


    }
}
