using BE.Application.Common.Interfaces;
using BE.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserLogin
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;

        public UserLoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<JwtDto>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var jwtDto= await _identityService.LoginAsync(request,cancellationToken);

            return new ResponseDto<JwtDto>(jwtDto,"Welcome back");
        }
    }
}
