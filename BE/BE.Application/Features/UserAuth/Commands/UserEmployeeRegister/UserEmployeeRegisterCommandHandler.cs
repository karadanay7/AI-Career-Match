using BE.Application.Common.Interfaces;
using BE.Application.Common.Models;
using BE.Application.Common.Models.EmailDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserEmployeeRegister
{
    public class UserEmployeeRegisterCommandHandler : IRequestHandler<UserEmployeeRegisterCommand, ResponseDto<RegisterDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        public UserEmployeeRegisterCommandHandler(IIdentityService identityService, IJwtService jwtService, IEmailService emailService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
            _emailService = emailService;
        }




        public async Task<ResponseDto<RegisterDto>> Handle(UserEmployeeRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.RegisterEmployeeAsync(request, cancellationToken);
            var roles = new List<string> { "Employee", };

            var jwtDtoTask = await _jwtService.GenerateTokenAsync(response.Id, response.Email, roles, cancellationToken);

            var emailDto = new EmailSendVerificationDto(response.Email, response.FirstName, response.EmailToken);
            await _emailService.SendEmailVerificationAsync(emailDto, cancellationToken);

         
            return new ResponseDto<RegisterDto>(new RegisterDto
            {
                UserId = response.Id,
                JwtDto = jwtDtoTask
            }, "Welcome to AI-Career-Match");

        }



    }
}
