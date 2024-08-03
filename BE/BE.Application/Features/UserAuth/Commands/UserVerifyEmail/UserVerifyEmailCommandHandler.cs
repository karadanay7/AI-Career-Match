using BE.Application.Common.Interfaces;
using BE.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserVerifyEmail
{
    public class UserVerifyEmailCommandHandler : IRequestHandler<UserVerifyEmailCommand, ResponseDto<string>>
    {
        private readonly IIdentityService _identityService;

        public UserVerifyEmailCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<string>> Handle(UserVerifyEmailCommand request, CancellationToken cancellationToken)
        {
           await _identityService.VerifyEmailAsync(request, cancellationToken);
           return new ResponseDto<string>(request.Email, "Email verified successfully");
        }
    }
}
