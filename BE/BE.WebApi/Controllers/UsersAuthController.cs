using BE.Application.Features.UserAuth.Commands.UserChangePassword;
using BE.Application.Features.UserAuth.Commands.UserEmployeeRegister;
using BE.Application.Features.UserAuth.Commands.UserEmployerRegister;
using BE.Application.Features.UserAuth.Commands.UserForgetPassword;
using BE.Application.Features.UserAuth.Commands.UserLogin;
using BE.Application.Features.UserAuth.Commands.UserResetPassword;
using BE.Application.Features.UserAuth.Commands.UserVerifyEmail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly ISender _mediatr;

        public UsersAuthController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("register-employee")]
        public async Task<IActionResult> RegisterEmployeeAsync(UserEmployeeRegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }


        [HttpPost("register-employer")]
        public async Task<IActionResult> RegisterEmployerAsync(UserEmployerRegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpGet("verify-email")]

        public async Task<IActionResult> VerifyEmailAsync([FromQuery] UserVerifyEmailCommand command, CancellationToken cancellationToken)
        {

            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }


        [HttpGet("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync([FromQuery] UserForgetPasswordCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpGet("reset-password")]

        public async Task<IActionResult> ResetPasswordAsync([FromQuery] UserResetPasswordCommand command, CancellationToken cancellationToken)
        {

            return Ok(await _mediatr.Send(command, cancellationToken));

        }


        [Authorize(Roles = "Employee,Employer")]
        [HttpGet("change-password")]

        public async Task<IActionResult> ChangePasswordAsync([FromQuery] UserChangePasswordCommand command, CancellationToken cancellationToken)
        {

            return Ok(await _mediatr.Send(command, cancellationToken));

        }

    }
}
