using BE.Application.Common.Interfaces;
using BE.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.UserAuth.Commands.UserResetPassword
{
    public class UserResetPasswordCommandHandler : IRequestHandler<UserResetPasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;


        public UserResetPasswordCommandHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<bool>> Handle(UserResetPasswordCommand request, CancellationToken cancellationToken)
        {
            await _identityService.ResetPasswordAsync(request, cancellationToken);
            await _emailService.SendPasswordChangedNotificationAsync(request.Email, cancellationToken);

            return new ResponseDto<bool>(true,"Password reseted successfully");
        }
    }
}
