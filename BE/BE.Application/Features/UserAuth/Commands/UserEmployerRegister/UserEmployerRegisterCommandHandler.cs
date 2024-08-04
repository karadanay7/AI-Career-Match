using BE.Application.Common.Interfaces;
using BE.Application.Common.Models;
using BE.Application.Common.Models.EmailDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserEmployerRegister
{
    public class UserEmployerRegisterCommandHandler :IRequestHandler<UserEmployerRegisterCommand,ResponseDto<RegisterDto>>
    {

        private readonly IJwtService _jwtService;
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;


        public UserEmployerRegisterCommandHandler(IJwtService jwtService, IIdentityService identityService, IEmailService emailService)
        {
            _jwtService = jwtService;
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<RegisterDto>> Handle(UserEmployerRegisterCommand request, CancellationToken cancellationToken)
        {
            var response= await _identityService.RegisterEmployerAsync(request, cancellationToken);
            var roles = new List<string> { "Employer" };

            var jwtDtoTask= await _jwtService.GenerateTokenAsync(response.Id, response.Email, roles, cancellationToken);

            var emailDto = new EmailSendVerificationDto(response.Email, response.FirstName, response.EmailToken);
       
           await  _emailService.SendEmailVerificationAsync(emailDto, cancellationToken);

      

            return new ResponseDto<RegisterDto>(new RegisterDto
            {
                UserId = response.Id,
                JwtDto = jwtDtoTask
            }, "Welcome to AI-Career-Match");

        }


    }
}
