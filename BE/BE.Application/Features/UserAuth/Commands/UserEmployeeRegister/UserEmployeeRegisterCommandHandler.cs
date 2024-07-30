using BE.Application.Features.UserAuth.Commands.UserRegister;
using BE.Application.Interfaces;
using BE.Application.Models;
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

        public UserEmployeeRegisterCommandHandler(IIdentityService identityService, IJwtService jwtService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
        }

        


        public async Task<ResponseDto<RegisterDto>> Handle(UserEmployeeRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.RegisterAsync(request, cancellationToken);
            var roles = new List<string> { "Employee", };
            var jwtDtoTask = await _jwtService.GenerateTokenAsync(response.Id, response.Email,roles, cancellationToken);

            return new ResponseDto<RegisterDto>(new RegisterDto
            {
                UserId = response.Id,
                JwtDto = jwtDtoTask,
            },"Welcome to AI-Career-Match");
         
        }


    }
}
